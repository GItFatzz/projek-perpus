Imports System.Data
Imports System.Data.SqlClient
Public Class Form1
    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        If txtuser.Text = "" Then
            MsgBox("Masukkan Username!")
            txtuser.Focus()
            Exit Sub
        End If
        If txtpass.Text = "" Then
            MsgBox("Masukkan Password!")
            txtpass.Focus()
            Exit Sub
        End If
        If cmblogin.Text = "" Then
            MsgBox("Pilih Login Sebagai!")
            cmblogin.Focus()
            Exit Sub
        End If
        Try
            Dim koneksi As String = "Data Source=LAPTOP-DR1AN\SQLEXPRESSBARU;Initial Catalog=dblogin;Integrated Security=True;Encrypt=False"
            Using con As New SqlConnection(koneksi)
                con.Open()
                Dim query As String = "SELECT role FROM tb_login WHERE username = @user AND password = @pass"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@user", txtuser.Text.Trim())
                    cmd.Parameters.AddWithValue("@pass", txtpass.Text)
                    Dim role As Object = cmd.ExecuteScalar()
                    If role Is Nothing OrElse IsDBNull(role) Then
                        MsgBox("Username atau Password salah!")
                        txtpass.Clear()
                        txtuser.Focus()
                        Exit Sub
                    End If
                    If role.ToString().ToLower() <> cmblogin.Text.ToLower() Then
                        MsgBox("Login tidak sesuai!")
                        Exit Sub
                    End If
                    If role.ToString().ToLower() = "admin" Then
                        Form2.Show()
                        Me.Hide()
                    ElseIf role.ToString().ToLower() = "peminjam" Then
                        Userlogin = txtuser.Text.Trim()
                        Form3.Show()
                        Me.Hide()
                    Else
                        MsgBox("Role tidak ditemukan!")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Koneksi database gagal: " & ex.Message)
        End Try
    End Sub
    Private Sub btndaftar_Click(sender As Object, e As EventArgs) Handles btndaftar.Click
        Form4.ShowDialog()
    End Sub
End Class