<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Me.txtusername = New System.Windows.Forms.TextBox()
        Me.txtpassword = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtkonfirm = New System.Windows.Forms.TextBox()
        Me.btndaftar = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtusername
        '
        Me.txtusername.Location = New System.Drawing.Point(301, 252)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Size = New System.Drawing.Size(181, 22)
        Me.txtusername.TabIndex = 13
        '
        'txtpassword
        '
        Me.txtpassword.Location = New System.Drawing.Point(301, 342)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.Size = New System.Drawing.Size(181, 22)
        Me.txtpassword.TabIndex = 12
        Me.txtpassword.UseSystemPasswordChar = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(107, 345)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "PASSWORD :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(109, 255)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "USERNAME :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Baskerville Old Face", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(277, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 32)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "LIBRARY"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.LOGIN_SQL.My.Resources.Resources.Download_blue_open_book_bookmark_academic_icon_white_background_for_free
        Me.PictureBox1.Location = New System.Drawing.Point(144, 56)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(119, 116)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(107, 439)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(176, 16)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "KONFIRMASI PASSWORD :"
        '
        'txtkonfirm
        '
        Me.txtkonfirm.Location = New System.Drawing.Point(301, 433)
        Me.txtkonfirm.Name = "txtkonfirm"
        Me.txtkonfirm.Size = New System.Drawing.Size(181, 22)
        Me.txtkonfirm.TabIndex = 16
        Me.txtkonfirm.UseSystemPasswordChar = True
        '
        'btndaftar
        '
        Me.btndaftar.BackColor = System.Drawing.Color.Blue
        Me.btndaftar.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btndaftar.ForeColor = System.Drawing.Color.White
        Me.btndaftar.Location = New System.Drawing.Point(93, 532)
        Me.btndaftar.Name = "btndaftar"
        Me.btndaftar.Size = New System.Drawing.Size(405, 40)
        Me.btndaftar.TabIndex = 17
        Me.btndaftar.Text = "DAFTAR"
        Me.btndaftar.UseVisualStyleBackColor = False
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(595, 727)
        Me.Controls.Add(Me.btndaftar)
        Me.Controls.Add(Me.txtkonfirm)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtusername)
        Me.Controls.Add(Me.txtpassword)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Name = "Form4"
        Me.Text = "Form4"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtusername As TextBox
    Friend WithEvents txtpassword As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtkonfirm As TextBox
    Friend WithEvents btndaftar As Button
End Class
