' Raghavi Sakpal
' Date: 08/30/2013
' POS_tagger Form: To accept a sentence and show the tagged POS

Public Class POS_Tagger

    ' On click of button display the tagged data 
    Private Sub tagSentButton_Click(sender As Object, e As EventArgs) Handles tagSentButton.Click
        ' Check if sentence has been entered
        If sentTextBox.Text = "" Then
            MsgBox("Please enter a sentence that needs to be tagged.")
        Else
            Dim sentToTag As String = sentTextBox.Text
            Dim taggedSentDict = POSTagger.main_POS(sentToTag)

            ' Concat the contents of Dictionary to create a msg string to dislay
            Dim taggedSent As String = ""

            For Each item As KeyValuePair(Of String, String) In taggedSentDict

                taggedSent = String.Concat(taggedSent, item.Key, "\", item.Value, " ")
            Next

            ' Display the tagged sentence in textbox
            taggedSentTextBox.Text = taggedSent
        End If
    End Sub
End Class