Imports System.Data.SqlClient
Public Class Form3
    Dim koneksi As String = "Data Source=LAPTOP-DR1AN\SQLEXPRESSBARU;Initial Catalog=Dblogin;Integrated Security=True"
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pndaftarbuku.Dock = DockStyle.Fill
        pnbukudipinjam.Dock = DockStyle.Fill
        pnriwayat.Dock = DockStyle.Fill
        numjumlahbuku.Minimum = 1
        numjumlahbuku.Maximum = 10
        numjumlahbuku.Value = 1
        dtppinjam.Value = Date.Today
        dtpkembali.Value = Date.Today.AddDays(7)
        TampilkanPanel(pndaftarbuku)
        RefreshSemua()
    End Sub

    Public Sub RefreshSemua()
        Try
            Tb_bukuTableAdapter.Fill(DbloginDataSet2.tb_buku)
            Tb_pinjamTableAdapter.Fill(DbloginDataSet5.tb_pinjam)
            TbpinjamBindingSource.Filter = "Username = '" & Userlogin.Replace("'", "''") & "' AND Status = 'Dipinjam'"
            HitungData()
            LoadRiwayat()
        Catch ex As Exception
            MessageBox.Show("Gagal memperbarui data: " & ex.Message)
        End Try
    End Sub

    Private Sub HitungData()
        Try
            Using conn As New SqlConnection(koneksi)
                conn.Open()
                Using cmd As New SqlCommand("SELECT COUNT(*) FROM dbo.tb_buku", conn)
                    lbltotalbuku.Text = cmd.ExecuteScalar().ToString()
                End Using
                Using cmd As New SqlCommand("SELECT ISNULL(SUM(JumlahPinjam),0) FROM dbo.tb_pinjam WHERE Status='Dipinjam' AND Username=@u", conn)
                    cmd.Parameters.AddWithValue("@u", Userlogin)
                    lblbukudipinjam.Text = cmd.ExecuteScalar().ToString()
                End Using
                Using cmd As New SqlCommand("SELECT ISNULL(SUM(JumlahPinjam),0) FROM dbo.tb_pinjam WHERE Status='Dikembalikan' AND Username=@u", conn)
                    cmd.Parameters.AddWithValue("@u", Userlogin)
                    lblbukukembali.Text = cmd.ExecuteScalar().ToString()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal menghitung data: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadRiwayat()
        Try
            Using conn As New SqlConnection(koneksi)
                conn.Open()
                Dim sql As String = "SELECT p.Id_Peminjam, p.Username, p.Id_Buku, b.[Judul Buku], p.JumlahPinjam, p.[Tanggal Pinjam], p.[Tanggal Kembali], p.Status " &
                    "FROM dbo.tb_pinjam p INNER JOIN dbo.tb_buku b ON p.Id_Buku=b.[ID Buku] " &
                    "WHERE p.Username=@u ORDER BY p.Id_Peminjam DESC"
                Using da As New SqlDataAdapter(sql, conn)
                    da.SelectCommand.Parameters.AddWithValue("@u", Userlogin)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    dgvriwayat.AutoGenerateColumns = True
                    dgvriwayat.DataSource = dt
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat riwayat: " & ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex < 0 Then Return
        Dim r As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        If r.IsNewRow Then Return
        txtid.Text = Convert.ToString(r.Cells(0).Value)

        Dim stok As Integer = 0
        Integer.TryParse(Convert.ToString(r.Cells(4).Value), stok)
        If stok <= 0 Then
            numjumlahbuku.Maximum = 1
            numjumlahbuku.Value = 1
            MessageBox.Show("Stok buku ini habis.")
            Return
        End If
        numjumlahbuku.Minimum = 1
        numjumlahbuku.Maximum = Math.Min(stok, 10)
        numjumlahbuku.Value = 1
    End Sub

    Private Sub btntambahkan_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        If txtid.Text.Trim() = "" Then
            MessageBox.Show("Pilih buku dulu di tabel.")
            Return
        End If
        If dtpkembali.Value.Date <= dtppinjam.Value.Date Then
            MessageBox.Show("Tanggal kembali harus setelah tanggal pinjam.")
            Return
        End If

        Dim idBuku As Integer
        If Not Integer.TryParse(txtid.Text, idBuku) Then
            MessageBox.Show("ID buku tidak valid.")
            Return
        End If
        Dim jumlah As Integer = CInt(numjumlahbuku.Value)

        Try
            Using conn As New SqlConnection(koneksi)
                conn.Open()
                Using tr As SqlTransaction = conn.BeginTransaction()
                    Try
                        Using cmd As New SqlCommand("UPDATE dbo.tb_buku SET [Stok Buku]=[Stok Buku]-@j WHERE [ID Buku]=@b AND [Stok Buku]>=@j", conn, tr)
                            cmd.Parameters.AddWithValue("@j", jumlah)
                            cmd.Parameters.AddWithValue("@b", idBuku)
                            If cmd.ExecuteNonQuery() = 0 Then Throw New Exception("Stok tidak cukup atau ID buku tidak ditemukan.")
                        End Using

                        Dim sql As String = "INSERT INTO dbo.tb_pinjam (Id_Peminjam, Username, Id_Buku, [Tanggal Pinjam], [Tanggal Kembali], Status, JumlahPinjam) " &
                            "SELECT ISNULL(MAX(Id_Peminjam),0)+1, @u, @b, @tp, @tk, 'Dipinjam', @j FROM dbo.tb_pinjam"
                        Using cmd As New SqlCommand(sql, conn, tr)
                            cmd.Parameters.AddWithValue("@u", Userlogin)
                            cmd.Parameters.AddWithValue("@b", idBuku)
                            cmd.Parameters.AddWithValue("@tp", dtppinjam.Value.Date)
                            cmd.Parameters.AddWithValue("@tk", dtpkembali.Value.Date)
                            cmd.Parameters.AddWithValue("@j", jumlah)
                            cmd.ExecuteNonQuery()
                        End Using
                        tr.Commit()
                    Catch
                        tr.Rollback()
                        Throw
                    End Try
                End Using
            End Using

            MessageBox.Show("Buku berhasil dipinjam.")
            txtid.Clear()
            numjumlahbuku.Value = 1
            dtppinjam.Value = Date.Today
            dtpkembali.Value = Date.Today.AddDays(7)
            RefreshSemua()
        Catch ex As Exception
            MessageBox.Show("Gagal meminjam: " & ex.Message)
        End Try
    End Sub
    Private Sub btnKembalikan_Click(sender As Object, e As EventArgs) Handles btnkembali.Click
        If dgvriwayat.CurrentRow Is Nothing Then
            MessageBox.Show("Pilih data peminjaman di riwayat dulu.")
            Return
        End If
        Dim idPinjam As Integer
        If Not Integer.TryParse(Convert.ToString(dgvriwayat.CurrentRow.Cells("Id_Peminjam").Value), idPinjam) Then
            MessageBox.Show("ID peminjaman tidak valid.")
            Return
        End If
        Try
            Using conn As New SqlConnection(koneksi)
                conn.Open()
                Using tr As SqlTransaction = conn.BeginTransaction()
                    Try
                        Dim idBuku As Integer
                        Dim jumlah As Integer
                        Using cmd As New SqlCommand("SELECT Id_Buku, JumlahPinjam FROM dbo.tb_pinjam WHERE Id_Peminjam=@id AND Username=@u AND Status='Dipinjam'", conn, tr)
                            cmd.Parameters.AddWithValue("@id", idPinjam)
                            cmd.Parameters.AddWithValue("@u", Userlogin)
                            Using rd As SqlDataReader = cmd.ExecuteReader()
                                If Not rd.Read() Then Throw New Exception("Peminjaman tidak ditemukan atau sudah dikembalikan.")
                                idBuku = Convert.ToInt32(rd("Id_Buku"))
                                jumlah = Convert.ToInt32(rd("JumlahPinjam"))
                            End Using
                        End Using

                        Using cmd As New SqlCommand("UPDATE dbo.tb_buku SET [Stok Buku]=[Stok Buku]+@j WHERE [ID Buku]=@b", conn, tr)
                            cmd.Parameters.AddWithValue("@j", jumlah)
                            cmd.Parameters.AddWithValue("@b", idBuku)
                            If cmd.ExecuteNonQuery() = 0 Then Throw New Exception("Data buku tidak ditemukan.")
                        End Using

                        Using cmd As New SqlCommand("UPDATE dbo.tb_pinjam SET Status='Dikembalikan' WHERE Id_Peminjam=@id AND Username=@u AND Status='Dipinjam'", conn, tr)
                            cmd.Parameters.AddWithValue("@id", idPinjam)
                            cmd.Parameters.AddWithValue("@u", Userlogin)
                            If cmd.ExecuteNonQuery() = 0 Then Throw New Exception("Status gagal diperbarui.")
                        End Using
                        tr.Commit()
                    Catch
                        tr.Rollback()
                        Throw
                    End Try
                End Using
            End Using
            MessageBox.Show("Buku berhasil dikembalikan.")
            RefreshSemua()
        Catch ex As Exception
            MessageBox.Show("Gagal mengembalikan buku: " & ex.Message)
        End Try
    End Sub
    Private Sub TampilkanPanel(panelPilihan As Panel)
        pndaftarbuku.Visible = False
        pnbukudipinjam.Visible = False
        pnriwayat.Visible = False
        panelPilihan.Visible = True
        panelPilihan.BringToFront()
    End Sub
    Private Sub btndaftarbuku_Click(sender As Object, e As EventArgs) Handles btndaftarbuku.Click
        TampilkanPanel(pndaftarbuku)
    End Sub
    Private Sub btnpinjam_Click(sender As Object, e As EventArgs) Handles btnpinjam.Click
        TampilkanPanel(pnbukudipinjam)
    End Sub
    Private Sub btnriwayat_Click(sender As Object, e As EventArgs) Handles btnriwayat.Click
        TampilkanPanel(pnriwayat)
    End Sub
    Private Sub btnlogout_Click(sender As Object, e As EventArgs) Handles btnlogout.Click
        Form1.Show()
        Me.Hide()
    End Sub
End Class