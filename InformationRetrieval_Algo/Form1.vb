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
            Dim quesNumNgram = n_gramMatching.main_nGrams(ques)

            ' METHOD 3: POS-Tagging Method
            MsgBox("Lets find the match by POS tagging method")
            Dim taggedDict = POSTagger.main_POS(ques)

            ' Concat the contents of Dictionary to create set of keywords
            Dim taggedSent As String = POSTagger.regexKeyword(taggedDict)

            ' Display the question on the screen
            Dim quesNumPOS = POSTagMatching(taggedSent)

            '--------------------------------------------------

            ' If Method 2 soln found and Method 3 soln not found
            If Not quesNumNgram = -1 And quesNumPOS = -1 Then
                ' Display the result on the screen
                retrieveAns(quesNumNgram)
            ElseIf quesNumNgram = -1 And Not quesNumPOS = -1 Then               ' If Method 2 soln not found and Method 3 soln found
                ' Display the result on the screen
                retrieveAns(quesNumPOS)
            ElseIf Not quesNumNgram = -1 And Not quesNumPOS = -1 Then           ' IF soln found for both method
                compareAns(quesNumNgram, quesNumPOS)
            Else ' If -1 returned
                MsgBox("Question not found by n-gram tokenizing method and POS-tagging Method")
            End If


        Else ' Display the answer found by the direct matching method
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
            Dim taggedSent As String = POSTagger.regexKeyword(taggedSentDict)

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

    ' Function to retrieve the answer from the database
    Private Sub retrieveAns(ByVal quesNumString As String)
        ' Split the string object in tokens
        Dim qNo() = Split(quesNumString, ",")

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
    End Sub

    ' Function to compare answer of two methods and display the best possible answer
    Private Sub compareAns(ByVal quesNgramStr As String, ByVal quesPOSStr As String)
        ' Split the string object in tokens
        Dim qNgramArr() = Split(quesNgramStr, ",")
        Dim qPOSArr() = Split(quesPOSStr, ",")

        ' Check if qNo array has more than one question number
        If qNgramArr.Length() > qPOSArr.Length() And qPOSArr.Length() > 1 Then
            ' Print each question number in the textbox for user to choose from
            For index As Integer = 0 To qPOSArr.Length() - 1
                answerTextBox.Text = String.Concat(answerTextBox.Text, questionMatching.question(Sample_Repo_TBLTableAdapter1, CInt(qPOSArr(index))), vbNewLine)
            Next
            MsgBox("Select question from one of the list.")
        ElseIf qNgramArr.Length() < qPOSArr.Length() And qNgramArr.Length() > 1 Then
            ' Print each question number in the textbox for user to choose from
            For index As Integer = 0 To qNgramArr.Length() - 1
                answerTextBox.Text = String.Concat(answerTextBox.Text, questionMatching.question(Sample_Repo_TBLTableAdapter1, CInt(qNgramArr(index))), vbNewLine)
            Next
            MsgBox("Select question from one of the list.")
        ElseIf qNgramArr.Length() = qPOSArr.Length() And qNgramArr.Length() > 1 Then
            ' Print each question number in the textbox for user to choose from
            For index As Integer = 0 To qNgramArr.Length() - 1
                answerTextBox.Text = String.Concat(answerTextBox.Text, questionMatching.question(Sample_Repo_TBLTableAdapter1, CInt(qNgramArr(index))), vbNewLine)
            Next
            MsgBox("Select question from one of the list.")
        ElseIf qPOSArr.Length() = 1 Then
            answerTextBox.Text = questionMatching.retrieveAnswer(Sample_Repo_TBLTableAdapter1, CInt(qPOSArr(0)))
        Else
            answerTextBox.Text = questionMatching.retrieveAnswer(Sample_Repo_TBLTableAdapter1, CInt(qNgramArr(0)))
        End If
    End Sub

    ' Function to display question found by POS tag method
    Function POSTagMatching(ByVal taggedInput As String)
        'MsgBox("Tagged Sentence: " & taggedInput)
        Dim keywordMatchCount As Integer                                        ' Variable to count the number of keywords match
        Dim keywordMatchDict As New Dictionary(Of Integer, List(Of Integer))    ' Dictionary to store the question number and their match count

        ' Split the tagged input based on commas
        Dim tagInputArr() As String = Split(taggedInput, ",")

        ' Open the input file 
        Dim path As String = "C:\Users\Admin\Documents\Visual Studio 2012\Projects\InformationRetrieval_Algo\InformationRetrieval_Algo\QuestionLog.txt"

        ' Open file to Read
        Dim file = My.Computer.FileSystem.OpenTextFileReader(path)

        Do Until file.EndOfStream
            ' Initialize the keyowrd count to zero
            keywordMatchCount = 0

            ' Read line from the file
            Dim dataString As String = file.ReadLine()

            ' Split the questionString into tokens based on space
            Dim dataArr() As String = Split(dataString, Space(5))

            'MsgBox("Tagged Data: " & dataArr(2))
            ' Split the keyword data string based on commas
            Dim keywordArr() As String = Split(dataArr(2), ",")

            ' Compare each keyword in input string with each keyword in data string
            For item As Integer = 0 To tagInputArr.Length - 2
                For index As Integer = 0 To keywordArr.Length - 2
                    If String.Compare(tagInputArr(item), keywordArr(index), True) = 0 Then
                        ' Increment the match count by 1
                        keywordMatchCount = keywordMatchCount + 1
                    End If
                Next
            Next

            ' Create a new list to store question number
            Dim questionNoList As New List(Of Integer)

            ' Add the question number associated with the question to the list
            questionNoList.Add(CInt(dataArr(0)))

            ' Check if key already present in the Dictionary
            If keywordMatchDict.ContainsKey(keywordMatchCount) Then
                ' Append the question number associated with it to the dictionary
                keywordMatchDict.Item(keywordMatchCount).Add(CInt(dataArr(0)))
            Else
                ' Create a new key and add the questio number list to the dictionary
                keywordMatchDict.Add(keywordMatchCount, questionNoList)
            End If
        Loop
        ' Close the file
        file.Close()

        ' Find the question number with maximum count
        Dim quesNumPOS = n_gramMatching.findQuestionNo(keywordMatchDict)

        Return quesNumPOS

    End Function

    ' Button to bnavigate to POS tagger form
    Private Sub POStaggerButton_Click(sender As Object, e As EventArgs) Handles POStaggerButton.Click
        POS_Tagger.Visible = True

    End Sub
End Class
