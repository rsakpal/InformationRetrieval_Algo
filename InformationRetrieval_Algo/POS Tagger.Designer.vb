<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class POS_Tagger
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
        Me.sentTextBox = New System.Windows.Forms.TextBox()
        Me.TagSentence = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.taggedSentTextBox = New System.Windows.Forms.TextBox()
        Me.tagSentButton = New System.Windows.Forms.Button()
        Me.TagSentence.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'sentTextBox
        '
        Me.sentTextBox.Location = New System.Drawing.Point(6, 19)
        Me.sentTextBox.Multiline = True
        Me.sentTextBox.Name = "sentTextBox"
        Me.sentTextBox.Size = New System.Drawing.Size(414, 79)
        Me.sentTextBox.TabIndex = 0
        '
        'TagSentence
        '
        Me.TagSentence.Controls.Add(Me.sentTextBox)
        Me.TagSentence.Location = New System.Drawing.Point(16, 12)
        Me.TagSentence.Name = "TagSentence"
        Me.TagSentence.Size = New System.Drawing.Size(426, 104)
        Me.TagSentence.TabIndex = 1
        Me.TagSentence.TabStop = False
        Me.TagSentence.Text = "Enter your sentence here"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.taggedSentTextBox)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 122)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(426, 100)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tagged Result"
        '
        'taggedSentTextBox
        '
        Me.taggedSentTextBox.BackColor = System.Drawing.Color.LightSteelBlue
        Me.taggedSentTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.taggedSentTextBox.Location = New System.Drawing.Point(6, 19)
        Me.taggedSentTextBox.Multiline = True
        Me.taggedSentTextBox.Name = "taggedSentTextBox"
        Me.taggedSentTextBox.Size = New System.Drawing.Size(414, 75)
        Me.taggedSentTextBox.TabIndex = 0
        '
        'tagSentButton
        '
        Me.tagSentButton.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.tagSentButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tagSentButton.Location = New System.Drawing.Point(349, 228)
        Me.tagSentButton.Name = "tagSentButton"
        Me.tagSentButton.Size = New System.Drawing.Size(93, 30)
        Me.tagSentButton.TabIndex = 3
        Me.tagSentButton.Text = "Enter"
        Me.tagSentButton.UseVisualStyleBackColor = False
        '
        'POS_Tagger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(454, 264)
        Me.Controls.Add(Me.tagSentButton)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TagSentence)
        Me.Name = "POS_Tagger"
        Me.Text = "POS_Tagger"
        Me.TagSentence.ResumeLayout(False)
        Me.TagSentence.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents sentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TagSentence As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents taggedSentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents tagSentButton As System.Windows.Forms.Button
End Class
