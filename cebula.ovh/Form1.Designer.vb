<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.LB_Pending = New System.Windows.Forms.ListBox()
        Me.Lbl1 = New System.Windows.Forms.Label()
        Me.btn_SelectFile = New System.Windows.Forms.Button()
        Me.btn_Upload = New System.Windows.Forms.Button()
        Me.LB_Uploaded = New System.Windows.Forms.ListBox()
        Me.btn_Clear = New System.Windows.Forms.Button()
        Me.Lbl2 = New System.Windows.Forms.Label()
        Me.btn_Copy = New System.Windows.Forms.Button()
        Me.myBrowser = New System.Windows.Forms.WebBrowser()
        Me.lbl_Status = New System.Windows.Forms.Label()
        Me.ProgBar_Status = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Multiselect = True
        Me.OpenFileDialog1.Title = "Select files to upload..."
        '
        'LB_Pending
        '
        Me.LB_Pending.FormattingEnabled = True
        Me.LB_Pending.Location = New System.Drawing.Point(15, 29)
        Me.LB_Pending.Name = "LB_Pending"
        Me.LB_Pending.Size = New System.Drawing.Size(400, 69)
        Me.LB_Pending.TabIndex = 0
        '
        'Lbl1
        '
        Me.Lbl1.AutoSize = True
        Me.Lbl1.Location = New System.Drawing.Point(12, 13)
        Me.Lbl1.Name = "Lbl1"
        Me.Lbl1.Size = New System.Drawing.Size(78, 13)
        Me.Lbl1.TabIndex = 1
        Me.Lbl1.Text = "Files to upload:"
        '
        'btn_SelectFile
        '
        Me.btn_SelectFile.Location = New System.Drawing.Point(421, 29)
        Me.btn_SelectFile.Name = "btn_SelectFile"
        Me.btn_SelectFile.Size = New System.Drawing.Size(100, 30)
        Me.btn_SelectFile.TabIndex = 2
        Me.btn_SelectFile.Text = "Select files..."
        Me.btn_SelectFile.UseVisualStyleBackColor = True
        '
        'btn_Upload
        '
        Me.btn_Upload.Location = New System.Drawing.Point(421, 156)
        Me.btn_Upload.Name = "btn_Upload"
        Me.btn_Upload.Size = New System.Drawing.Size(100, 30)
        Me.btn_Upload.TabIndex = 3
        Me.btn_Upload.Text = "UPLOAD"
        Me.btn_Upload.UseVisualStyleBackColor = True
        '
        'LB_Uploaded
        '
        Me.LB_Uploaded.FormattingEnabled = True
        Me.LB_Uploaded.Location = New System.Drawing.Point(15, 117)
        Me.LB_Uploaded.Name = "LB_Uploaded"
        Me.LB_Uploaded.Size = New System.Drawing.Size(400, 69)
        Me.LB_Uploaded.TabIndex = 4
        '
        'btn_Clear
        '
        Me.btn_Clear.Location = New System.Drawing.Point(421, 68)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(100, 30)
        Me.btn_Clear.TabIndex = 5
        Me.btn_Clear.Text = "Clear"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'Lbl2
        '
        Me.Lbl2.AutoSize = True
        Me.Lbl2.Location = New System.Drawing.Point(12, 101)
        Me.Lbl2.Name = "Lbl2"
        Me.Lbl2.Size = New System.Drawing.Size(77, 13)
        Me.Lbl2.TabIndex = 6
        Me.Lbl2.Text = "Uploaded files:"
        '
        'btn_Copy
        '
        Me.btn_Copy.Location = New System.Drawing.Point(421, 117)
        Me.btn_Copy.Name = "btn_Copy"
        Me.btn_Copy.Size = New System.Drawing.Size(100, 30)
        Me.btn_Copy.TabIndex = 7
        Me.btn_Copy.Text = "Copy to Clipboard"
        Me.btn_Copy.UseVisualStyleBackColor = True
        '
        'myBrowser
        '
        Me.myBrowser.Location = New System.Drawing.Point(15, 29)
        Me.myBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.myBrowser.Name = "myBrowser"
        Me.myBrowser.Size = New System.Drawing.Size(400, 69)
        Me.myBrowser.TabIndex = 8
        Me.myBrowser.WebBrowserShortcutsEnabled = False
        '
        'lbl_Status
        '
        Me.lbl_Status.AutoSize = True
        Me.lbl_Status.Location = New System.Drawing.Point(12, 189)
        Me.lbl_Status.Name = "lbl_Status"
        Me.lbl_Status.Size = New System.Drawing.Size(74, 13)
        Me.lbl_Status.TabIndex = 9
        Me.lbl_Status.Text = "Status: Ready"
        '
        'ProgBar_Status
        '
        Me.ProgBar_Status.Location = New System.Drawing.Point(15, 205)
        Me.ProgBar_Status.Name = "ProgBar_Status"
        Me.ProgBar_Status.Size = New System.Drawing.Size(506, 23)
        Me.ProgBar_Status.TabIndex = 11
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 240)
        Me.Controls.Add(Me.ProgBar_Status)
        Me.Controls.Add(Me.lbl_Status)
        Me.Controls.Add(Me.btn_Copy)
        Me.Controls.Add(Me.Lbl2)
        Me.Controls.Add(Me.btn_Clear)
        Me.Controls.Add(Me.LB_Uploaded)
        Me.Controls.Add(Me.btn_Upload)
        Me.Controls.Add(Me.btn_SelectFile)
        Me.Controls.Add(Me.Lbl1)
        Me.Controls.Add(Me.LB_Pending)
        Me.Controls.Add(Me.myBrowser)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "cebula.ovh :: Uploader"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents LB_Pending As ListBox
    Friend WithEvents Lbl1 As Label
    Friend WithEvents btn_SelectFile As Button
    Friend WithEvents btn_Upload As Button
    Friend WithEvents LB_Uploaded As ListBox
    Friend WithEvents btn_Clear As Button
    Friend WithEvents Lbl2 As Label
    Friend WithEvents btn_Copy As Button
    Friend WithEvents myBrowser As WebBrowser
    Friend WithEvents lbl_Status As Label
    Friend WithEvents ProgBar_Status As ProgressBar
End Class
