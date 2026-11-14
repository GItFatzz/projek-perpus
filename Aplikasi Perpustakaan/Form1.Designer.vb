<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnusername = New System.Windows.Forms.Label()
        Me.btnpassword = New System.Windows.Forms.Label()
        Me.txtpass = New System.Windows.Forms.TextBox()
        Me.txtuser = New System.Windows.Forms.TextBox()
        Me.btnlogin = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmblogin = New System.Windows.Forms.ComboBox()
        Me.btndaftar = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Baskerville Old Face", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(281, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "LIBRARY"
        '
        'btnusername
        '
        Me.btnusername.AutoSize = True
        Me.btnusername.Location = New System.Drawing.Point(119, 254)
        Me.btnusername.Name = "btnusername"
        Me.btnusername.Size = New System.Drawing.Size(90, 16)
        Me.btnusername.TabIndex = 1
        Me.btnusername.Text = "USERNAME :"
        '
        'btnpassword
        '
        Me.btnpassword.AutoSize = True
        Me.btnpassword.Location = New System.Drawing.Point(117, 341)
        Me.btnpassword.Name = "btnpassword"
        Me.btnpassword.Size = New System.Drawing.Size(92, 16)
        Me.btnpassword.TabIndex = 2
        Me.btnpassword.Text = "PASSWORD :"
        '
        'txtpass
        '
        Me.txtpass.Location = New System.Drawing.Point(273, 335)
        Me.txtpass.Name = "txtpass"
        Me.txtpass.Size = New System.Drawing.Size(171, 22)
        Me.txtpass.TabIndex = 3
        '
        'txtuser
        '
        Me.txtuser.Location = New System.Drawing.Point(273, 248)
        Me.txtuser.Name = "txtuser"
        Me.txtuser.Size = New System.Drawing.Size(171, 22)
        Me.txtuser.TabIndex = 4
        '
        'btnlogin
        '
        Me.btnlogin.BackColor = System.Drawing.Color.Blue
        Me.btnlogin.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlogin.ForeColor = System.Drawing.Color.White
        Me.btnlogin.Location = New System.Drawing.Point(103, 511)
        Me.btnlogin.Name = "btnlogin"
        Me.btnlogin.Size = New System.Drawing.Size(405, 40)
        Me.btnlogin.TabIndex = 5
        Me.btnlogin.Text = "LOGIN"
        Me.btnlogin.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.LOGIN_SQL.My.Resources.Resources.Download_blue_open_book_bookmark_academic_icon_white_background_for_free
        Me.PictureBox1.Location = New System.Drawing.Point(142, 52)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(119, 116)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(119, 413)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Login Sebagai :"
        '
        'cmblogin
        '
        Me.cmblogin.FormattingEnabled = True
        Me.cmblogin.Items.AddRange(New Object() {"Admin", "Peminjam"})
        Me.cmblogin.Location = New System.Drawing.Point(273, 410)
        Me.cmblogin.Name = "cmblogin"
        Me.cmblogin.Size = New System.Drawing.Size(171, 24)
        Me.cmblogin.TabIndex = 11
        '
        'btndaftar
        '
        Me.btndaftar.BackColor = System.Drawing.Color.White
        Me.btndaftar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btndaftar.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btndaftar.ForeColor = System.Drawing.Color.Blue
        Me.btndaftar.Location = New System.Drawing.Point(181, 567)
        Me.btndaftar.Name = "btndaftar"
        Me.btndaftar.Size = New System.Drawing.Size(240, 35)
        Me.btndaftar.TabIndex = 12
        Me.btndaftar.Text = "Belum ada akun? Daftar"
        Me.btndaftar.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(595, 727)
        Me.Controls.Add(Me.btndaftar)
        Me.Controls.Add(Me.cmblogin)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnlogin)
        Me.Controls.Add(Me.txtuser)
        Me.Controls.Add(Me.txtpass)
        Me.Controls.Add(Me.btnpassword)
        Me.Controls.Add(Me.btnusername)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnusername As Label
    Friend WithEvents btnpassword As Label
    Friend WithEvents txtpass As TextBox
    Friend WithEvents txtuser As TextBox
    Friend WithEvents btnlogin As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmblogin As ComboBox
    Friend WithEvents btndaftar As Button
End Class
