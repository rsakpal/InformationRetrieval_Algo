' Raghavi Sakpal
' Date: 08/22/2013
' Description: Module to match to the correct question and retrieve the correct answer based on direct matching 

Imports System.Text.RegularExpressions

Module questionMatching

    ' Function to find the direct match of the question and return the match question number
    Function directQueryMatching(ByVal sampleTableAdapter As Patient_TBI_DBDataSetTableAdapters.Sample_Repo_TBLTableAdapter, ByVal data As String) As Integer
        ' Find a direct match to the question
        Try
            Dim quesNo = sampleTableAdapter.SelectQuestionNo(data)
            Return quesNo
        Catch
            Return -1
        End Try

    End Function

    ' Function to return number of questions from the database
    Function questionCount(ByVal sampleTableAdapter As Patient_TBI_DBDataSetTableAdapters.Sample_Repo_TBLTableAdapter)
        Return sampleTableAdapter.SelectRowCount()
    End Function

    ' Function to return question to write to text file
    Function question(ByVal sampleTableAdapter As Patient_TBI_DBDataSetTableAdapters.Sample_Repo_TBLTableAdapter, ByVal quesNo As Integer)
        Return sampleTableAdapter.SelectQuestion(quesNo)
    End Function

    ' Function to replace the punctuation with space in the question before returning to the text file
    Function regexQuestion(ByVal input As String)
        Dim pattern As String = "[^\w\s]|_"
        Dim replacement As String = ""
        Dim rgx As New Regex(pattern)
        Dim result As String = rgx.Replace(input, replacement)

        Return result
    End Function

    ' Function to find a direct match to the question in the text file
    Function directMatchingFile(ByVal input As String)
        Dim flag As Boolean = True
        Dim quesNo As Integer = -1

        MsgBox("Direct Matching Method")

        ' Apply Regex to the input to remove punctuations
        Dim regexInput As String = regexQuestion(input)

        ' Create a text file to copy your data 
        Dim path As String = "C:\Users\Admin\Documents\Visual Studio 2012\Projects\InformationRetrieval_Algo\InformationRetrieval_Algo\QuestionLog.txt"

        ' Open file to Read
        Dim file = My.Computer.FileSystem.OpenTextFileReader(path)

        Do Until file.EndOfStream Or flag = False
            Dim dataQues As String = file.ReadLine()
            Dim TestArray() As String = Split(dataQues, Space(5))

            MsgBox("Question: " & TestArray(1).ToLower() & "Input: " & regexInput.ToLower())
            ' Check to see if a match to the question is found
            If String.Compare(Trim(TestArray(1)), Trim(regexInput), True) = 0 Then
                ' Set flag to false to indiciae that match is found
                flag = False

                ' Store the question number found
                quesNo = CInt(TestArray(0))
            End If
        Loop

        ' Close the file
        file.Close()

        ' Return the question number to the main form
        Return quesNo
    End Function

    ' function to retrieve the answer based on the selected question number
    Function retrieveAnswer(ByVal sampleTableAdapter As Patient_TBI_DBDataSetTableAdapters.Sample_Repo_TBLTableAdapter, ByVal quesNo As Integer)
        Return sampleTableAdapter.SelectAnswer(quesNo)
    End Function
End Module
