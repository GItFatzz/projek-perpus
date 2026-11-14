Imports System.Data
Imports System.Data.SqlClient

Public Class Form2

    Dim koneksi As String = "Data Source=LAPTOP-DR1AN\SQLEXPRESSBARU;Initial Catalog=dblogin;Integrated Security=True"

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Tb_bukuTableAdapter2.Fill(DbloginDataSet.tb_buku)
        Tb_bukuTableAdapter.Fill(DbloginDataSet4.tb_buku)

        pnkategoribuku.Dock = DockStyle.Fill
        pnpeminjam.Dock = DockStyle.Fill
        pnlaporan.Dock = DockStyle.Fill

        TampilPeminjam("")
        TampilLaporan()
        TampilkanPanel(pnpeminjam)

    End Sub
    Private Sub btntambah_Click(sender As Object, e As EventArgs)

        If txtid.Text = "" Or txtjudul.Text = "" Or txtpenulis.Text = "" Or cmbkategori.Text = "" Or txtstok.Text = "" Then
            MessageBox.Show("Semua data harus diisi!")
            Exit Sub
        End If

        Dim stok As Integer

        If Not Integer.TryParse(txtstok.Text, stok) Then
            MessageBox.Show("Stok harus berupa angka!")
            Exit Sub
        End If

        Try
            Dim data As DataTable = DbloginDataSet4.tb_buku
            Dim baris As DataRow = data.NewRow()

            baris("ID Buku") = txtid.Text
            baris("Judul Buku") = txtjudul.Text
            baris("Penulis") = txtpenulis.Text
            baris("Kategori") = cmbkategori.Text
            baris("Stok Buku") = stok

            data.Rows.Add(baris)

            Tb_bukuTableAdapter.Update(DbloginDataSet4.tb_buku)
            Tb_bukuTableAdapter.Fill(DbloginDataSet4.tb_buku)
            Tb_bukuTableAdapter2.Fill(DbloginDataSet.tb_buku)

            MessageBox.Show("Data buku berhasil ditambahkan!")

            txtid.Clear()
            txtbuku.Clear()
            txtpenulis.Clear()
            txtstok.Clear()
            cmbkategori.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show("Gagal menambahkan buku: " & ex.Message)
        End Try

    End Sub
    Private Sub TampilPeminjam(Optional kataKunci As String = "")

        Try
            Using conn As New SqlConnection(koneksi)

                conn.Open()

                Dim sql As String = "SELECT username, role FROM dbo.tb_login " &
                                    "WHERE role = 'Peminjam' AND username LIKE @cari"

                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@cari", "%" & kataKunci.Trim() & "%")

                    Dim dt As New DataTable()
                    Dim da As New SqlDataAdapter(cmd)

                    da.Fill(dt)

                    dgvpeminjam.AutoGenerateColumns = True
                    dgvpeminjam.DataSource = Nothing
                    dgvpeminjam.Columns.Clear()
                    dgvpeminjam.DataSource = dt

                    lbltotalpeminjam.Text = dt.Rows.Count.ToString()

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Data peminjam gagal ditampilkan: " & ex.Message)
        End Try

    End Sub
    Private Sub btncari_Click(sender As Object, e As EventArgs)
        TampilPeminjam(txtcari.Text)
    End Sub

    Private Sub txtcari_KeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = Keys.Enter Then
            TampilPeminjam(txtcari.Text)
            e.SuppressKeyPress = True
        End If

    End Sub
    Private Sub btncarii_Click(sender As Object, e As EventArgs)
        TampilPeminjam(txtcari.Text)
    End Sub

    Private Sub txtcarii_KeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = Keys.Enter Then
            TampilPeminjam(txtcari.Text)
            e.SuppressKeyPress = True
        End If

    End Sub
    Private Sub TampilLaporan()

        Try
            Using conn As New SqlConnection(koneksi)

                conn.Open()

                Dim sql As String = "SELECT p.Username, b.[Judul Buku], " &
                                    "p.[Tanggal Pinjam], p.[Tanggal Kembali], p.Status " &
                                    "FROM dbo.tb_pinjam AS p " &
                                    "INNER JOIN dbo.tb_buku AS b " &
                                    "ON p.Id_Buku = b.[ID Buku]"

                Using da As New SqlDataAdapter(sql, conn)

                    Dim dt As New DataTable()
                    da.Fill(dt)

                    dgvlaporan.AutoGenerateColumns = True
                    dgvlaporan.DataSource = Nothing
                    dgvlaporan.Columns.Clear()
                    dgvlaporan.DataSource = dt

                    lbltotallaporan.Text = dt.Rows.Count.ToString()

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Laporan peminjam gagal ditampilkan: " & ex.Message)
        End Try

    End Sub
    Private Sub TampilkanPanel(panelPilihan As Panel)

        pnkategoribuku.Visible = False
        pnpeminjam.Visible = False
        pnlaporan.Visible = False

        panelPilihan.Visible = True
        panelPilihan.BringToFront()

    End Sub

    Private Sub btnkategori_Click(sender As Object, e As EventArgs) Handles btnkategori.Click
        TampilkanPanel(pnkategoribuku)
    End Sub

    Private Sub btnpeminjam_Click(sender As Object, e As EventArgs) Handles btnpeminjam.Click
        TampilkanPanel(pnpeminjam)
        TampilPeminjam(txtcari.Text)
    End Sub

    Private Sub btnlaporan_Click(sender As Object, e As EventArgs) Handles btnlaporan.Click
        TampilkanPanel(pnlaporan)
        TampilLaporan()
    End Sub
    Private Sub btnlogout_Click_2(sender As Object, e As EventArgs) Handles btnlogout.Click
        Form1.Show()
        Me.Hide()
    End Sub
End Class
