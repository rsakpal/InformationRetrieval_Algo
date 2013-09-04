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
        Me.questionTextBox = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.POStaggerButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.queryButton = New System.Windows.Forms.Button()
        Me.answerTextBox = New System.Windows.Forms.TextBox()
        Me.Patient_TBI_DBDataSet = New InformationRetrieval_Algo.Patient_TBI_DBDataSet()
        Me.Sample_Repo_TBLTableAdapter1 = New InformationRetrieval_Algo.Patient_TBI_DBDataSetTableAdapters.Sample_Repo_TBLTableAdapter()
        Me.Panel1.SuspendLayout()
        CType(Me.Patient_TBI_DBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'questionTextBox
        '
        Me.questionTextBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.questionTextBox.Location = New System.Drawing.Point(32, 203)
        Me.questionTextBox.Multiline = True
        Me.questionTextBox.Name = "questionTextBox"
        Me.questionTextBox.Size = New System.Drawing.Size(334, 82)
        Me.questionTextBox.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.POStaggerButton)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.queryButton)
        Me.Panel1.Controls.Add(Me.answerTextBox)
        Me.Panel1.Controls.Add(Me.questionTextBox)
        Me.Panel1.Font = New System.Drawing.Font("Symbol", 8.25!)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(391, 353)
        Me.Panel1.TabIndex = 1
        '
        'POStaggerButton
        '
        Me.POStaggerButton.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.POStaggerButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.POStaggerButton.Location = New System.Drawing.Point(263, 306)
        Me.POStaggerButton.Name = "POStaggerButton"
        Me.POStaggerButton.Size = New System.Drawing.Size(103, 31)
        Me.POStaggerButton.TabIndex = 4
        Me.POStaggerButton.Text = "POS Tagger"
        Me.POStaggerButton.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe Marker", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(98, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(195, 24)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Information Retrieval"
        '
        'queryButton
        '
        Me.queryButton.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.queryButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.queryButton.Location = New System.Drawing.Point(32, 306)
        Me.queryButton.Name = "queryButton"
        Me.queryButton.Size = New System.Drawing.Size(99, 31)
        Me.queryButton.TabIndex = 2
        Me.queryButton.Text = "Enter "
        Me.queryButton.UseVisualStyleBackColor = False
        '
        'answerTextBox
        '
        Me.answerTextBox.BackColor = System.Drawing.Color.LightSteelBlue
        Me.answerTextBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.answerTextBox.Location = New System.Drawing.Point(32, 71)
        Me.answerTextBox.Multiline = True
        Me.answerTextBox.Name = "answerTextBox"
        Me.answerTextBox.Size = New System.Drawing.Size(334, 94)
        Me.answerTextBox.TabIndex = 1
        '
        'Patient_TBI_DBDataSet
        '
        Me.Patient_TBI_DBDataSet.DataSetName = "Patient_TBI_DBDataSet"
        Me.Patient_TBI_DBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Sample_Repo_TBLTableAdapter1
        '
        Me.Sample_Repo_TBLTableAdapter1.ClearBeforeFill = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(417, 378)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "Natural Language Dialog"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Patient_TBI_DBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents questionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents queryButton As System.Windows.Forms.Button
    Friend WithEvents answerTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Sample_Repo_TBLTableAdapter1 As InformationRetrieval_Algo.Patient_TBI_DBDataSetTableAdapters.Sample_Repo_TBLTableAdapter
    Friend WithEvents Patient_TBI_DBDataSet As InformationRetrieval_Algo.Patient_TBI_DBDataSet
    Friend WithEvents POStaggerButton As System.Windows.Forms.Button

End Class
