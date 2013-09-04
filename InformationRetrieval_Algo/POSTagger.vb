' Raghavi Sakpal
' Date: 08/30/2013
' Module: To implement my POSTagger logic

Imports System.Text.RegularExpressions

Module POSTagger

    ' Function that handle the POS Tagger
    Function main_POS(ByVal input As String) As Dictionary(Of String, String)

        Dim POSDict As New Dictionary(Of String, String)    ' Dictionary to store the 
        Dim resultString As String = ""                     ' Variable to store the taged string

        ' Tokenize the input sentence
        Dim inputStringArr As String() = stringTokenizer(Trim(input))

        ' Get the length of the array
        If inputStringArr.Length() = 1 Then
            ' Find the tags associated with the input token
            Dim newlist = tokenPOSTag(inputStringArr(0))

            ' Store the resulting string
            'resultString = String.Concat(resultString, inputStringArr(0), "/", newlist(0), " ")

            ' Add token and POS tag to the POSDict
            POSDict.Add(inputStringArr(0), newlist(0))
        Else
            ' Display the contents of the token array
            For index As Integer = 0 To inputStringArr.Length() - 1
                'MsgBox(inputStringArr(index))
                ' Find the tags associated with the input token
                Dim newlist = tokenPOSTag(inputStringArr(index))

                ' Store the resulting string
                'resultString = String.Concat(resultString, inputStringArr(index), "/", newlist(0), " ")

                ' Add token and POS tag to the POSDict
                If Not POSDict.ContainsKey(inputStringArr(index)) Then
                    POSDict.Add(inputStringArr(index), newlist(0))
                End If
            Next
        End If

        'MsgBox(resultString)
        Return POSDict
    End Function

    ' Function to tokenize given string
    Function stringTokenizer(ByVal input As String) As String()

        ' Split the given string in tokens based on the space
        Dim stringTokenizerArr As String() = Split(input)

        Return stringTokenizerArr
    End Function

    ' Function to return the POS tags associated with each token from the lexicon text file 
    Function tokenPOSTag(ByVal token As String) As List(Of String)

        Dim tagList As New List(Of String)              ' Variable to store the list of tags
        Dim matchFound As Boolean = False               ' Variable to store if match found or not
       
        ' Return a regex token
        Dim regexToken = regexTokenizer(token)

        ' Open the lexicon file 
        Dim path As String = "C:\Users\Admin\Documents\Visual Studio 2012\Projects\InformationRetrieval_Algo\InformationRetrieval_Algo\lexicon_POS.txt"

        ' Open file to Read
        Dim file = My.Computer.FileSystem.OpenTextFileReader(path)


        Do Until matchFound = True Or file.EndOfStream
            ' Read file
            Dim dataQues As String = file.ReadLine()
           
            ' Break the line in tokens
            Dim lexiconArr() As String = Split(dataQues)

            ' Regex for lexicon token in the file
            'Dim regexLexToken = regexTokenizer(lexiconArr(0))

            ' Check to see if input token has a match in the lexicon text file
            If String.Compare(regexToken, lexiconArr(0), True) = 0 Then
                matchFound = True
                'MsgBox("Input Token: " & regexToken & " Lexicon Token: " & lexiconArr(0))

                ' Store the following the tags in the list
                For count As Integer = 1 To lexiconArr.Length() - 1
                    tagList.Add(lexiconArr(count))
                Next
            End If
        Loop

        ' If match not found for the input token then check for other rules
        If matchFound = False Then
            ' Check to see if the token is a cardinal
            Dim POSFound = checkForOtherPOS(regexToken)
            tagList.Add(POSFound)
        End If
            Return tagList
    End Function

    ' Function to write regular expression that clear spunctuations from words 
    Function regexTokenizer(ByVal token As String) As String

        Dim pattern As String = "^[^\w\s]|_$"           ' Pattern to search for punctuations
        Dim rgxPunct As New Regex(pattern)              ' Regular Expression
        Dim m As Match = rgxPunct.Match(token)          ' Match the token to the pattern to see if a match is found
        Dim rgsLM As New Regex("[0-9]+[\)\]]")          ' check if it is a List Marker
        Dim mLM As Match = rgsLM.Match(token)

        ' Check to see if the token matches a punctuation
        If m.Success Or mLM.Success Then
            Return token
        ElseIf token.Contains("-") Then
            ' Check to see if the token is a phrase
            Return token
        Else
            ' Apply regex to token to remove any punctuations
            Return questionMatching.regexQuestion(token)
        End If

    End Function

    ' Function to check if the token is cardinal or not
    Function checkForOtherPOS(ByVal token As String) As String
        Dim pattern As String = "^[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?$"              ' Pattern to check if token is a cardinal
        Dim rgx As New Regex(pattern)                                                   ' Regular Expression
        Dim m As Match = rgx.Match(token)                                               ' Match the token to the pattern to see if a match is found
        Dim rgxLM As New Regex("[0-9]+[\)\]]")                                          ' Pattern to check for list marker 
        Dim mLM As Match = rgxLM.Match(token)

        ' If token matches a number the return true for cardinal
        If m.Success Then
            Return "CD"
        ElseIf mLM.Success Then
            Return "LM"
        Else
            Return "NNP"
        End If
    End Function

    ' Function to accept sort out keywords from a given Dictionary of POS tags
    Function regexKeyword(ByVal newDict As Dictionary(Of String, String)) As String
        Dim patternKeyword As String = ""
    End Function
End Module
