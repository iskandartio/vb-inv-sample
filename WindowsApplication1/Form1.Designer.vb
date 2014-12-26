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
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.btnSelectParam = New System.Windows.Forms.Button()
        Me.txtTestCode = New System.Windows.Forms.TextBox()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.txtInput1 = New System.Windows.Forms.TextBox()
        Me.btnInsertFail = New System.Windows.Forms.Button()
        Me.txtInput2 = New System.Windows.Forms.TextBox()
        Me.btnInsertTransaction = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.btnDropTableTest = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnTruncateTableTest = New System.Windows.Forms.Button()
        Me.txtName1 = New System.Windows.Forms.TextBox()
        Me.txtName2 = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(8, 64)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 23)
        Me.btnSelect.TabIndex = 0
        Me.btnSelect.Text = "Select"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'btnSelectParam
        '
        Me.btnSelectParam.Location = New System.Drawing.Point(8, 96)
        Me.btnSelectParam.Name = "btnSelectParam"
        Me.btnSelectParam.Size = New System.Drawing.Size(160, 23)
        Me.btnSelectParam.TabIndex = 2
        Me.btnSelectParam.Text = "Select Param"
        Me.btnSelectParam.UseVisualStyleBackColor = True
        '
        'txtTestCode
        '
        Me.txtTestCode.Location = New System.Drawing.Point(176, 96)
        Me.txtTestCode.Name = "txtTestCode"
        Me.txtTestCode.Size = New System.Drawing.Size(100, 20)
        Me.txtTestCode.TabIndex = 3
        '
        'btnInsert
        '
        Me.btnInsert.Location = New System.Drawing.Point(8, 248)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(160, 23)
        Me.btnInsert.TabIndex = 4
        Me.btnInsert.Text = "Insert without Transaction"
        Me.btnInsert.UseVisualStyleBackColor = True
        '
        'txtInput
        '
        Me.txtInput.Location = New System.Drawing.Point(176, 248)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(100, 20)
        Me.txtInput.TabIndex = 5
        '
        'txtInput1
        '
        Me.txtInput1.Location = New System.Drawing.Point(16, 312)
        Me.txtInput1.Name = "txtInput1"
        Me.txtInput1.Size = New System.Drawing.Size(100, 20)
        Me.txtInput1.TabIndex = 6
        '
        'btnInsertFail
        '
        Me.btnInsertFail.Location = New System.Drawing.Point(8, 360)
        Me.btnInsertFail.Name = "btnInsertFail"
        Me.btnInsertFail.Size = New System.Drawing.Size(144, 23)
        Me.btnInsertFail.TabIndex = 7
        Me.btnInsertFail.Text = "Insert Transaction Fail"
        Me.btnInsertFail.UseVisualStyleBackColor = True
        '
        'txtInput2
        '
        Me.txtInput2.Location = New System.Drawing.Point(16, 336)
        Me.txtInput2.Name = "txtInput2"
        Me.txtInput2.Size = New System.Drawing.Size(100, 20)
        Me.txtInput2.TabIndex = 8
        '
        'btnInsertTransaction
        '
        Me.btnInsertTransaction.Location = New System.Drawing.Point(8, 384)
        Me.btnInsertTransaction.Name = "btnInsertTransaction"
        Me.btnInsertTransaction.Size = New System.Drawing.Size(144, 23)
        Me.btnInsertTransaction.TabIndex = 9
        Me.btnInsertTransaction.Text = "Insert Transaction Success"
        Me.btnInsertTransaction.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(8, 120)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(408, 120)
        Me.DataGridView1.TabIndex = 10
        '
        'btnCreate
        '
        Me.btnCreate.Location = New System.Drawing.Point(8, 40)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(136, 23)
        Me.btnCreate.TabIndex = 11
        Me.btnCreate.Text = "Create Table Test"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'btnDropTableTest
        '
        Me.btnDropTableTest.Location = New System.Drawing.Point(8, 16)
        Me.btnDropTableTest.Name = "btnDropTableTest"
        Me.btnDropTableTest.Size = New System.Drawing.Size(136, 23)
        Me.btnDropTableTest.TabIndex = 13
        Me.btnDropTableTest.Text = "Drop Table Test"
        Me.btnDropTableTest.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(128, 288)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(291, 20)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Click tombol Select buat lihat hasil insert"
        '
        'btnTruncateTableTest
        '
        Me.btnTruncateTableTest.Location = New System.Drawing.Point(152, 40)
        Me.btnTruncateTableTest.Name = "btnTruncateTableTest"
        Me.btnTruncateTableTest.Size = New System.Drawing.Size(136, 23)
        Me.btnTruncateTableTest.TabIndex = 16
        Me.btnTruncateTableTest.Text = "Truncate Table Test"
        Me.btnTruncateTableTest.UseVisualStyleBackColor = True
        '
        'txtName1
        '
        Me.txtName1.Location = New System.Drawing.Point(120, 312)
        Me.txtName1.Name = "txtName1"
        Me.txtName1.Size = New System.Drawing.Size(100, 20)
        Me.txtName1.TabIndex = 17
        '
        'txtName2
        '
        Me.txtName2.Location = New System.Drawing.Point(120, 336)
        Me.txtName2.Name = "txtName2"
        Me.txtName2.Size = New System.Drawing.Size(100, 20)
        Me.txtName2.TabIndex = 18
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(280, 248)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(100, 20)
        Me.txtName.TabIndex = 19
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 423)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtName2)
        Me.Controls.Add(Me.txtName1)
        Me.Controls.Add(Me.btnTruncateTableTest)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnDropTableTest)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnInsertTransaction)
        Me.Controls.Add(Me.txtInput2)
        Me.Controls.Add(Me.btnInsertFail)
        Me.Controls.Add(Me.txtInput1)
        Me.Controls.Add(Me.txtInput)
        Me.Controls.Add(Me.btnInsert)
        Me.Controls.Add(Me.txtTestCode)
        Me.Controls.Add(Me.btnSelectParam)
        Me.Controls.Add(Me.btnSelect)
        Me.IsMdiContainer = True
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents btnSelectParam As System.Windows.Forms.Button
    Friend WithEvents txtTestCode As System.Windows.Forms.TextBox
    Friend WithEvents btnInsert As System.Windows.Forms.Button
    Friend WithEvents txtInput As System.Windows.Forms.TextBox
    Friend WithEvents txtInput1 As System.Windows.Forms.TextBox
    Friend WithEvents btnInsertFail As System.Windows.Forms.Button
    Friend WithEvents txtInput2 As System.Windows.Forms.TextBox
    Friend WithEvents btnInsertTransaction As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents btnDropTableTest As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnTruncateTableTest As System.Windows.Forms.Button
    Friend WithEvents txtName1 As System.Windows.Forms.TextBox
    Friend WithEvents txtName2 As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox

End Class
