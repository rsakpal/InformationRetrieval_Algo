' Raghavi Sakpal
' Date: 08/22/2013
' Form1: To accept natural language query from the user and retrieve an answer based on our question matching algorthm

Imports System.IO.StreamWriter
Imports System.IO


Public Class Form1

    ' On form load import data from SQL to text file
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Read the data from the sql to the text file
        SQLtoText()
    End Sub
    ' On Button click accept the question and send it to the question matching algorithm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles queryButton.Click

        If questionTextBox.Text = "" Then
            MsgBox("Cant keep the text box enter")
        Else
            Dim question As String = questionTextBox.Text
            'Make a call to the algorithm to find the correct question
            IR(question)
        End If
    End Sub

    ' The main algorithm
    Private Sub IR(ByVal ques As String)
        ' METHOD 1: Direct Matching
        Dim quesNo As Integer = questionMatching.directMatchingFile(ques)

        ' If match not found break the question up
        If quesNo = -1 Then
            MsgBox("Question not found by direct matching.")

            ' METHOD 2: N-Gram matching
            Dim quesNum = n_gramMatching.main_nGrams(ques)
            MsgBox("Solutin: " & quesNum)

            ' If question match is found
            If Not quesNum = -1 Then

                ' Split the string object in tokens
                Dim qNo() = Split(quesNum, ",")

                ' Check if qNo array has more than one question number
                If qNo.Length() > 1 Then
                    ' Print each question number in the textbox for user to choose from
                    For index As Integer = 0 To qNo.Length() - 1
                        answerTextBox.Text = String.Concat(answerTextBox.Text, questionMatching.question(Sample_Repo_TBLTableAdapter1, CInt(qNo(index))), vbNewLine)
                    Next
                    MsgBox("Select question from one of the list.")
                Else
                    answerTextBox.Text = questionMatching.retrieveAnswer(Sample_Repo_TBLTableAdapter1, CInt(qNo(0)))
                End If
            Else ' If -1 returned
                MsgBox("Question not found by n-gram tokenizing method")
            End If

        Else
            MsgBox("Question Found: " & quesNo)
            answerTextBox.Text = questionMatching.retrieveAnswer(Sample_Repo_TBLTableAdapter1, quesNo)
        End If

    End Sub

    ' To Read data from SQL sever to the text file
    Private Sub SQLtoText()
        ' Create a text file to copy your data 
        Dim path As String = "C:\Users\Admin\Documents\Visual Studio 2012\Projects\InformationRetrieval_Algo\InformationRetrieval_Algo\QuestionLog.txt"

        ' Create or overwrite the file. 
        Dim File = My.Computer.FileSystem.OpenTextFileWriter(path, False)

        ' Retrieve questions from the database
        Dim quesCount = questionMatching.questionCount(Sample_Repo_TBLTableAdapter1)

        ' Retrieve each question from the database and write it down to the text file
        For index As Integer = 1 To quesCount

            ' Retrieve question from the database based on the question number
            Dim question = questionMatching.question(Sample_Repo_TBLTableAdapter1, index)

            Dim regexQuestion = questionMatching.regexQuestion(question)

            Dim taggedSentDict = POSTagger.main_POS(regexQuestion)

            ' Concat the contents of Dictionary to create set of keywords
            Dim taggedSent As String = ""

            For Each item As KeyValuePair(Of String, String) In taggedSentDict
                taggedSent = String.Concat(taggedSent, item.Key, "\", item.Value, " ")
            Next

            ' Add text to the file. 
            File.Write(index)
            File.Write(Space(5))
            File.Write(regexQuestion)
            File.Write(Space(5))
            File.Write(taggedSent)
            File.Write(vbNewLine)
        Next

        File.Close()

        MsgBox("File Created")
    End Sub

    
    Private Sub POStaggerButton_Click(sender As Object, e As EventArgs) Handles POStaggerButton.Click
        POS_Tagger.Visible = True

    End Sub
End Class
