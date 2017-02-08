'
' Copyright (c) 2017 Autodesk, Inc.
'
' Permission Is hereby granted, free of charge, to any person obtaining a copy
' of this software And associated documentation files (the "Software"), to deal
' in the Software without restriction, including without limitation the rights
' to use, copy, modify, merge, publish, distribute, sublicense, And/Or sell
' copies of the Software, And to permit persons to whom the Software Is
' furnished to do so, subject to the following conditions:
'
' The above copyright notice And this permission notice shall be included in all
' copies Or substantial portions of the Software.
'
' THE SOFTWARE Is PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS Or
' IMPLIED, INCLUDING BUT Not LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
' FITNESS FOR A PARTICULAR PURPOSE And NONINFRINGEMENT. IN NO EVENT SHALL THE
' AUTHORS Or COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES Or OTHER
' LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT Or OTHERWISE, ARISING FROM,
' OUT OF Or IN CONNECTION WITH THE SOFTWARE Or THE USE Or OTHER DEALINGS IN THE
' SOFTWARE.
'
Option Strict Off

Imports Autodesk.Forge
Imports Autodesk.Forge.Client
Imports Autodesk.Forge.Model

Module Module1

	Sub Main()
		' Run a synchronous code to obtain an access_token
		ForgeTest.Test()
		' Run an asynchronous code to obtain an access_token
		' This version does Not block UI updates on the system
		ForgeTest.TestAsync()

		Console.WriteLine("Press any key to exit...")
		Console.ReadKey()
	End Sub

	Public Class ForgeTest

		' Initialize the oAuth 2.0 client configuration fron enviroment variables
		' you can also hardcode them in the code if you want in the placeholders below
		Private Shared FORGE_CLIENT_ID As String = If(Environment.GetEnvironmentVariable("FORGE_CLIENT_ID"), "your_client_id")
		Private Shared FORGE_CLIENT_SECRET As String = If(Environment.GetEnvironmentVariable("FORGE_CLIENT_SECRET"), "your_client_secret")
		Private Shared _scope As Scope() = New Scope() {Scope.DataRead, Scope.DataWrite}

		' Intialize the 2-legged oAuth 2.0 client.
		Private Shared _twoLeggedApi As TwoLeggedApi = New TwoLeggedApi()

		' Synchronous example
		Public Shared Function _2leggedSynchronous() As Object
			Try
				' Call the synchronous version of the 2-legged client with HTTP information
				' HTTP information will help you to verify if the call was successful as well
				' as read the HTTP transaction headers.
				Dim bearer As ApiResponse(Of Object) = _twoLeggedApi.AuthenticateWithHttpInfo(FORGE_CLIENT_ID, FORGE_CLIENT_SECRET, oAuthConstants.CLIENT_CREDENTIALS, _scope)
				'If bearer.StatusCode <> 200 Then
				'	Throw New Exception("Request failed! (with HTTP response " + bearer.StatusCode + ")")
				'End If


				' The JSON response from the oAuth server Is the Data variable And has been
				' already parsed into a DynamicDictionary object.

				'Dim token As String = bearer.Data.token_type + " " + bearer.Data.access_token
				'Dim dt As DateTime = DateTime.Now
				'dt.AddSeconds(Double.Parse(bearer.Data.expires_in.ToString()))

				Return (bearer.Data)
			Catch ex As Exception
				Return (Nothing)
			End Try
		End Function

		Public Shared Sub Test()
			Dim bearer As Object = _2leggedSynchronous()
			If bearer Is Nothing Then
				Console.WriteLine("You were not granted a new access_token!")
				Return
			End If
			' The call returned successfully And you got a valid access_token.
			Dim token As String = bearer.token_type + " " + bearer.access_token
			Console.WriteLine("Your synchronous token test is: " + token)
		End Sub

		' Asynchronous example (recommended)
		Public Shared Async Function _2leggedAsync() As Task(Of Object)
			Try
				' Call the asynchronous version of the 2-legged client with HTTP information
				' HTTP information will help you to verify if the call was successful as well
				' as read the HTTP transaction headers.
				Dim bearer As ApiResponse(Of Object) = Await _twoLeggedApi.AuthenticateAsyncWithHttpInfo(FORGE_CLIENT_ID, FORGE_CLIENT_SECRET, oAuthConstants.CLIENT_CREDENTIALS, _scope)
				'If bearer.StatusCode <> 200 Then
				'	Throw New Exception("Request failed! (with HTTP response " + bearer.StatusCode + ")")
				'End If

				' The JSON response from the oAuth server Is the Data variable And has been
				' already parsed into a DynamicDictionary object.

				'Dim token As String = bearer.Data.token_type + " " + bearer.Data.access_token
				'Dim dt As DateTime = DateTime.Now
				'dt.AddSeconds(Double.Parse(bearer.Data.expires_in.ToString()))

				Return (bearer.Data)
			Catch ex As Exception
				Return (Nothing)
			End Try
		End Function

		Public Shared Async Sub TestAsync()
			Dim bearer As Object = Await _2leggedAsync()
			' The call returned successfully And you got a valid access_token.
			Dim token As String = bearer.token_type + " " + bearer.access_token
			Console.WriteLine("Your async token test is: " + token)
		End Sub

	End Class

End Module