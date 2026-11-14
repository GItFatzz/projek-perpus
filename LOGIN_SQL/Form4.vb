Imports System.Data.SqlClient
Public Class Form4
    Private Sub btndaftar_Click(sender As Object, e As EventArgs) Handles btndaftar.Click
        If txtusername.Text.Trim() = "" Or
           txtpassword.Text = "" Or
           txtkonfirm.Text = "" Then

            MsgBox("Lengkapi semua data terlebih dahulu!")
            Exit Sub
        End If
        If txtpassword.Text <> txtkonfirm.Text Then
            MsgBox("Password tidak cocok!")
            txtkonfirm.Clear()
            txtkonfirm.Focus()
            Exit Sub
        End If
        Try
            Dim koneksi As String = "Data Source=LAPTOP-DR1AN\SQLEXPRESSBARU;Initial Catalog=dblogin;Integrated Security=True;Encrypt=False"
            Using con As New SqlConnection(koneksi)
                con.Open()
                Dim query As String = "SELECT COUNT(*) FROM tb_login WHERE username = @user"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@user", txtusername.Text.Trim())
                    If CInt(cmd.ExecuteScalar()) > 0 Then
                        MsgBox("Username sudah dipakai!")
                        Exit Sub
                    End If
                End Using
                query = "INSERT INTO tb_login (username, password, role) VALUES (@user, @pass, @role)"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@user", txtusername.Text.Trim())
                    cmd.Parameters.AddWithValue("@pass", txtpassword.Text)
                    cmd.Parameters.AddWithValue("@role", "Peminjam")
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MsgBox("Akun berhasil dibuat! Silakan login.")
            Me.Close()
        Catch ex As Exception
            MsgBox("Gagal membuat akun: " & ex.Message)
        End Try
    End Sub
End Class