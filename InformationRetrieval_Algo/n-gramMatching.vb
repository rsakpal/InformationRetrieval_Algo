' Raghavi Sakpal
' Date: 08/28/2013
' Description: Module to implement n-gram matching. Breaking down questions in trigrams, bigrams and unigrams to find answer match

Module n_gramMatching

    ' Function to make a call to match based on trigrams, bigrams or unigrams
    Function main_nGrams(ByVal input As String)
        ' Variable to store the value returned from executing each n-gram method
        Dim solnFound = 0
        Dim ngramSoln = "0"

        ' Varibale to store the lenght of the token array
        Dim inputTokenArrLength As Integer

        ' Split the input into tokens to check which n-gram method to start with
        Dim inputTokenArr() = Split(input)

        If (inputTokenArr(inputTokenArr.Length() - 1) = "") Then
            inputTokenArrLength = inputTokenArr.Length() - 1
        Else
            inputTokenArrLength = inputTokenArr.Length()
        End If

        ' Check which n-gram method we can apply
        If inputTokenArrLength >= 3 Then
            ' Call to trigram method
            MsgBox("Lets try to find a match based on trigrams method.")
            ngramSoln = nGrams(input, 3)
            If ngramSoln = -1 Then
                solnFound = -1
            End If
        End If

        If inputTokenArrLength = 2 Or solnFound = -1 Then
            ' Call to bigram method
            MsgBox("No solution found by trigrams method. Lets try to find a match based on bigrams method.")
            ngramSoln = nGrams(input, 2)
            If ngramSoln = -1 Then
                solnFound = -1
            End If
        End If

        If inputTokenArrLength = 1 Or solnFound = -1 Then
            ' Call to unigram method
            MsgBox("No solution found by bigrams method. Lets try to find a match based on unigrams method.")
            ngramSoln = nGrams(input, 1)
            If ngramSoln = -1 Then
                solnFound = -1
            End If
        End If

        Return ngramSoln
    End Function

    ' Function to implement the nGrams method of information retrieval
    Function nGrams(ByVal input As String, ByVal nGramType As Integer)
        ' Create a dictionary of integers, with integer keys
        Dim ngramDict As New Dictionary(Of Integer, List(Of Integer))
        Dim inputNgram
        Dim questionNgram

        ' Apply regex to remove punctuations from the string
        Dim regexInput As String = questionMatching.regexQuestion(input)

        ' Convert the input to lowerCase
        input = regexInput.ToLower()

        ' Create ngrams for the input string based on the nGramType
        If nGramType = 3 Then
            inputNgram = createTrigrams(input)
        ElseIf nGramType = 2 Then
            inputNgram = createBigrams(input)
        Else
            inputNgram = createUnigrams(input)
        End If

        ' Open question text file and create trigrams for each questions
        Dim path As String = "C:\Users\Admin\Documents\Visual Studio 2012\Projects\InformationRetrieval_Algo\InformationRetrieval_Algo\QuestionLog.txt"

        ' Open file to Read
        Dim file = My.Computer.FileSystem.OpenTextFileReader(path)

        Do Until file.EndOfStream
            Dim dataQues As String = file.ReadLine()
            Dim TestArray() As String = Split(dataQues, Space(5))

            ' Create ngrams for the input string based on the nGramType
            If nGramType = 3 Then
                questionNgram = createTrigrams(TestArray(1))
            ElseIf nGramType = 2 Then
                questionNgram = createBigrams(TestArray(1))
            Else
                questionNgram = createUnigrams(TestArray(1))
            End If

            ' Match the input trigrams with the question trigram and return the match count
            Dim matchCount = findNgramMatchCount(inputNgram, questionNgram)

            ' Create a new list to store question number
            Dim questionNoList As New List(Of Integer)

            ' Add the question number associated with the question to the list
            questionNoList.Add(CInt(TestArray(0)))

            ' Check if key already present in the Dictionary
            If ngramDict.ContainsKey(matchCount) Then
                ' Append the question number associated with it to the dictionary
                ngramDict.Item(matchCount).Add(CInt(TestArray(0)))
            Else
                ' Create a new key and add the questio number list to the dictionary
                ngramDict.Add(matchCount, questionNoList)
            End If
        Loop

        ' Close the file
        file.Close()

        'Return the list of question number found
        Dim quesString = findQuestionNo(ngramDict)
        'MsgBox("Soln2: " & quesString)
        Return quesString
    End Function

    ' Function to break string into trigrams
    Function createTrigrams(ByVal input As String)

        Dim index As Integer = 0

        ' Flag to keep a check for end of array length
        Dim flag As Boolean = True

        ' Create an array to hold the list of trigrams
        Dim trigramList As New List(Of String)

        ' Create a token array
        Dim tokenArr() As String = Split(input, Space(1))

        ' Create tigrams 
        While Not (index = tokenArr.Length - 1) And flag = True And Not (tokenArr(index + 2) = "")
            ' MsgBox("Creating Trigrams")

            ' Create a list of strings
            Dim tokenList As New List(Of String)
            tokenList.Add(tokenArr(index))
            tokenList.Add(tokenArr(index + 1))
            tokenList.Add(tokenArr(index + 2))

            ' Save this list to a list 
            trigramList.Add(String.Join(",", tokenList.ToArray))

            ' Check if end of tokenArr has reached
            If index + 2 = tokenArr.Length() - 1 Then
                flag = False
            Else    ' Increment the index count
                index = index + 1
            End If
        End While

        Return trigramList
    End Function

    ' Function to find match and save the match count and question number
    Function findNgramMatchCount(ByVal inputNgram As List(Of String), ByVal questionNgram As List(Of String))
        ' Variable to count number of matches from input to question
        Dim matchCount As Integer = 0

        ' Compare trigrams to keep a count of matching items
        For Each item In inputNgram
            For Each newItem In questionNgram
                'MsgBox("Input: " & item & "Q: " & newItem)
                If String.Compare(item, newItem) = 0 Then
                    matchCount = matchCount + 1
                    'MsgBox(matchCount)
                End If
            Next
        Next
        Return matchCount
    End Function

    ' Function to find the list of question numbers
    Function findQuestionNo(ByVal newDict As Dictionary(Of Integer, List(Of Integer)))
        ' Variable to store maximum key
        Dim maxKey As Integer = 0

        ' Go through each key and find the highest key
        For Each pair In newDict
            If pair.Key() > maxKey Then
                maxKey = pair.Key()
            End If
        Next

        ' Return the list of questions
        If maxKey = 0 Then
            Return -1
        Else
            Dim newString = String.Join(",", newDict.Item(maxKey).ToArray())
            'MsgBox("Soln1:" & newString)
            Return newString
        End If

    End Function

    ' Function to break string into bigrams
    Function createBigrams(ByVal input As String)
        Dim index As Integer = 0

        ' Flag to keep a check for end of array length
        Dim flag As Boolean = True

        ' Create an array to hold the list of bigrams
        Dim bigramList As New List(Of String)

        ' Create a token array
        Dim tokenArr() As String = Split(input, Space(1))

        ' Create tigrams 
        While Not (index = tokenArr.Length - 1) And flag = True And Not (tokenArr(index + 1) = "")
            ' MsgBox("Creating Trigrams")

            ' Create a list of strings
            Dim tokenList As New List(Of String)
            tokenList.Add(tokenArr(index))
            tokenList.Add(tokenArr(index + 1))

            ' Save this list to a list 
            bigramList.Add(String.Join(",", tokenList.ToArray))

            ' Check if end of tokenArr has reached
            If index + 1 = tokenArr.Length() - 1 Then
                flag = False
            Else    ' Increment the index count
                index = index + 1
            End If
        End While

        Return bigramList
    End Function

    ' Function to break string into unigrams
    Function createUnigrams(ByVal input As String)
        Dim index As Integer = 0
        Dim arrLength

        ' Flag to keep a check for end of array length
        Dim flag As Boolean = True

        ' Create an array to hold the list of trigrams
        Dim unigramList As New List(Of String)

        ' Create a token array
        Dim tokenArr() As String = Split(input, Space(1))

        If tokenArr.Length() = 1 Then
            arrLength = 1
        Else
            arrLength = tokenArr.Length() - 1
        End If

        ' Create tigrams 
        While Not (index = arrLength) And flag = True ' And Not (tokenArr(index) = "")
            ' MsgBox("Creating Trigrams")

            ' Create a list of strings
            Dim tokenList As New List(Of String)
            tokenList.Add(tokenArr(index))

            ' Save this list to a list 
            unigramList.Add(String.Join(",", tokenList.ToArray))

            ' Check if end of tokenArr has reached
            If index = tokenArr.Length() - 1 Then
                flag = False
            Else    ' Increment the index count
                index = index + 1
            End If
        End While

        Return unigramList
    End Function

End Module
