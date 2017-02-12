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

Imports System.IO
Imports System.Threading

Imports Autodesk.Forge
Imports Autodesk.Forge.Model
Imports Autodesk.Forge.Client

Module Module1

	Public Class ForgeTest

		' Initialize the oAuth 2.0 client configuration fron enviroment variables
		' you can also hardcode them in the code if you want in the placeholders below
		Private Shared FORGE_CLIENT_ID As String = If(Environment.GetEnvironmentVariable("FORGE_CLIENT_ID"), "your_client_id")
		Private Shared FORGE_CLIENT_SECRET As String = If(Environment.GetEnvironmentVariable("FORGE_CLIENT_SECRET"), "your_client_secret")
		Private Shared BUCKET_KEY As String = "forge-csharp-sample-app-" + FORGE_CLIENT_ID.ToLower()
		Private Shared FILE_NAME As String = "my-elephant.obj"
		Private Shared FILE_PATH As String = "elephant.obj"

		' Initialize the relevant clients; in this example, the Objects, Buckets and Derivatives clients, which are part of the Data Management API and Model Derivatives API
		Private Shared bucketsApi As New BucketsApi()
		Private Shared objectsApi As New ObjectsApi()
		Private Shared derivativesApi As New DerivativesApi()

		Private Shared oauth2TwoLegged As TwoLeggedApi
		Private Shared twoLeggedCredentials As Object

		' Initialize the 2-legged OAuth 2.0 client, and optionally set specific scopes.
		Public Shared Sub initializeOAuth()
			' You must provide at least one valid scope
			Dim scopes() As Scope = New Scope() {Scope.DataRead, Scope.DataWrite, Scope.BucketCreate, Scope.BucketRead}

			oauth2TwoLegged = New TwoLeggedApi()
			twoLeggedCredentials = oauth2TwoLegged.Authenticate(FORGE_CLIENT_ID, FORGE_CLIENT_SECRET, oAuthConstants.CLIENT_CREDENTIALS, scopes)
			bucketsApi.Configuration.AccessToken = twoLeggedCredentials.access_token
			objectsApi.Configuration.AccessToken = twoLeggedCredentials.access_token
			derivativesApi.Configuration.AccessToken = twoLeggedCredentials.access_token
		End Sub

		' Example of how to create a new bucket using Forge SDK.
		' Uses the oauth2TwoLegged and twoLeggedCredentials objects that you retrieved previously.
		Public Shared Sub createBucket()
			Console.WriteLine("***** Sending createBucket request")
			Dim payload As New PostBucketsPayload(BUCKET_KEY, Nothing, PostBucketsPayload.PolicyKeyEnum.Persistent)
			Dim response As Object = bucketsApi.CreateBucket(payload, "US")
			Console.WriteLine("***** Response for createBucket: " + response.ToString())
		End Sub

		' Example of how to upload a file to the bucket.
		' Uses the oauth2TwoLegged and twoLeggedCredentials objects that you retrieved previously.
		Public Shared Function uploadFile() As Object
			Console.WriteLine("***** Sending uploadFile request")
			Dim path As String = FILE_PATH
			If Not File.Exists(path) Then
				path = Convert.ToString("..\..\..\") & FILE_PATH
			End If
			Using streamReader As New StreamReader(path)
				Dim response As Object = objectsApi.UploadObject(BUCKET_KEY, FILE_NAME, CInt(streamReader.BaseStream.Length), streamReader.BaseStream, "application/octet-stream")
				Console.WriteLine("***** Response for uploadFile: ")
				Console.WriteLine("Uploaded object Details - Location: " + response.location + ", Size: " + response.size.ToString())
				Return (response)
			End Using
		End Function

		' Example of how to send a translate to SVF job request.
		' Uses the oauth2TwoLegged and twoLeggedCredentials objects that you retrieved previously.
		' @param urn - the urn of the file to translate
		Public Shared Function translateToSVF(urn As String) As Object
			Console.WriteLine("***** Sending Derivative API translate request")
			Dim jobInput As New JobPayloadInput(System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(urn)))
			Dim jobOutput As New JobPayloadOutput(New List(Of JobPayloadItem)(New JobPayloadItem() {New JobPayloadItem(JobPayloadItem.TypeEnum.Svf, New List(Of JobPayloadItem.ViewsEnum)(New JobPayloadItem.ViewsEnum() {JobPayloadItem.ViewsEnum._3d}), Nothing)}))
			Dim job As New JobPayload(jobInput, jobOutput)
			Dim response As Object = derivativesApi.Translate(job, True)
			Console.WriteLine("***** Response for Translating File to SVF: " + response.ToString())
			Return (response)
		End Function

		' Example of how to query the status of a translate job.
		' Uses the oauth2TwoLegged and twoLeggedCredentials objects that you retrieved previously.
		' @param base64Urn - the urn of the file to translate in base 64 format
		Public Shared Function verifyJobComplete(base64Urn As String) As Object
			Console.WriteLine("***** Sending getManifest request")
			While True
				Dim response As Object = derivativesApi.GetManifest(base64Urn)
				If hasOwnProperty(response, "progress") AndAlso response.progress = "complete" Then
					Console.WriteLine("***** Finished translating your file to SVF - status: " + response.status + ", progress: " + response.progress)
					Return (response)
				Else
					Console.WriteLine("***** Haven't finished translating your file to SVF - status: " + response.status + ", progress: " + response.progress)
					Thread.Sleep(1000)
				End If
			End While
			Return (Nothing)
		End Function

		Public Shared Function hasOwnProperty(obj As Object, name As String) As Boolean
			Try
				Dim test = obj(name)
				Return (True)
			Catch ex As Exception
				Return (False)
			End Try
		End Function

		' Open translated SVF file in the viewer
		' Uses the twoLeggedCredentials object that you retrieved previously.
		' Opens the file statically from your hard drive with url parameters for the accessToken and for the urn of the file to show.
		' @param base64Urn
		Public Shared Sub openViewer(base64Urn As String)
			Console.WriteLine(Convert.ToString("***** Opening SVF file in viewer with urn:") & base64Urn)
			Dim st As String = _html.Replace("__URN__", base64Urn).Replace("__ACCESS_TOKEN__", twoLeggedCredentials.access_token)
			System.IO.File.WriteAllText("viewer.html", st)
			System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo("viewer.html"))
		End Sub

		' Example of how to delete a file that was uploaded by the application.
		' Uses the oauth2TwoLegged and twoLeggedCredentials objects that you retrieved previously.
		Public Shared Sub deleteFile()
			Console.WriteLine("***** Sending deleteFile request")
			Dim response As ApiResponse(Of Object) = objectsApi.DeleteObjectWithHttpInfo(BUCKET_KEY, FILE_NAME)
			Console.WriteLine("***** Response Code for deleting File: " + response.StatusCode)
		End Sub

#Region "Html"
		Private Shared ReadOnly _html As String = "<!DOCTYPE html>" & vbCr & vbLf & "<html>" & vbCr & vbLf & "<head>" & vbCr & vbLf & vbTab & "<meta charset=""UTF-8"">" & vbCr & vbLf & vbTab & "<script src=""https://developer.api.autodesk.com/viewingservice/v1/viewers/three.min.css""></script>" & vbCr & vbLf & vbTab & "<link rel=""stylesheet"" href=""https://developer.api.autodesk.com/viewingservice/v1/viewers/style.min.css"" />" & vbCr & vbLf & vbTab & "<script src=""https://developer.api.autodesk.com/viewingservice/v1/viewers/viewer3D.min.js""></script>" & vbCr & vbLf & "</head>" & vbCr & vbLf & "<body onload=""initialize()"">" & vbCr & vbLf & "<div id=""viewer"" style=""position:absolute; width:90%; height:90%;""></div>" & vbCr & vbLf & "<script>" & vbCr & vbLf & vbTab & "function authMe () { return ('__ACCESS_TOKEN__') ; }" & vbCr & vbLf & vbCr & vbLf & vbTab & "function initialize () {" & vbCr & vbLf & vbTab & vbTab & "var options ={" & vbCr & vbLf & vbTab & vbTab & vbTab & "'document' : ""urn:__URN__""," & vbCr & vbLf & vbTab & vbTab & vbTab & "'env': 'AutodeskProduction'," & vbCr & vbLf & vbTab & vbTab & vbTab & "'getAccessToken': authMe" & vbCr & vbLf & vbTab & vbTab & "} ;" & vbCr & vbLf & vbTab & vbTab & "var viewerElement =document.getElementById ('viewer') ;" & vbCr & vbLf & vbTab & vbTab & "//var viewer =new Autodesk.Viewing.Viewer3D (viewerElement, {}) ; / No toolbar" & vbCr & vbLf & vbTab & vbTab & "var viewer =new Autodesk.Viewing.Private.GuiViewer3D (viewerElement, {}) ; // With toolbar" & vbCr & vbLf & vbTab & vbTab & "Autodesk.Viewing.Initializer (options, function () {" & vbCr & vbLf & vbTab & vbTab & vbTab & "viewer.initialize () ;" & vbCr & vbLf & vbTab & vbTab & vbTab & "loadDocument (viewer, options.document) ;" & vbCr & vbLf & vbTab & vbTab & "}) ;" & vbCr & vbLf & vbTab & "}" & vbCr & vbLf & vbTab & "function loadDocument (viewer, documentId) {" & vbCr & vbLf & vbTab & vbTab & "// Find the first 3d geometry and load that." & vbCr & vbLf & vbTab & vbTab & "Autodesk.Viewing.Document.load (" & vbCr & vbLf & vbTab & vbTab & vbTab & "documentId," & vbCr & vbLf & vbTab & vbTab & vbTab & "function (doc) { // onLoadCallback" & vbCr & vbLf & vbTab & vbTab & vbTab & vbTab & "var geometryItems =[] ;" & vbCr & vbLf & vbTab & vbTab & vbTab & vbTab & "geometryItems =Autodesk.Viewing.Document.getSubItemsWithProperties (" & vbCr & vbLf & vbTab & vbTab & vbTab & vbTab & vbTab & "doc.getRootItem ()," & vbCr & vbLf & vbTab & vbTab & vbTab & vbTab & vbTab & "{ 'type' : 'geometry', 'role' : '3d' }," & vbCr & vbLf & vbTab & vbTab & vbTab & vbTab & vbTab & "true" & vbCr & vbLf & vbTab & vbTab & vbTab & vbTab & ") ;" & vbCr & vbLf & vbTab & vbTab & vbTab & vbTab & "if ( geometryItems.length <= 0 ) {" & vbCr & vbLf & vbTab & vbTab & vbTab & vbTab & vbTab & "geometryItems =Autodesk.Viewing.Document.getSubItemsWithProperties (" & vbCr & vbLf & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "doc.getRootItem ()," & vbCr & vbLf & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "{ 'type': 'geometry', 'role': '2d' }," & vbCr & vbLf & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "true" & vbCr & vbLf & vbTab & vbTab & vbTab & vbTab & vbTab & ") ;" & vbCr & vbLf & vbTab & vbTab & vbTab & vbTab & "}" & vbCr & vbLf & vbTab & vbTab & vbTab & vbTab & "if ( geometryItems.length > 0 )" & vbCr & vbLf & vbTab & vbTab & vbTab & vbTab & vbTab & "viewer.load (" & vbCr & vbLf & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "doc.getViewablePath (geometryItems [0])//," & vbCr & vbLf & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "//null, null, null," & vbCr & vbLf & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "//doc.acmSessionId /*session for DM*/" & vbCr & vbLf & vbTab & vbTab & vbTab & vbTab & vbTab & ") ;" & vbCr & vbLf & vbTab & vbTab & vbTab & "}," & vbCr & vbLf & vbTab & vbTab & vbTab & "function (errorMsg) { // onErrorCallback" & vbCr & vbLf & vbTab & vbTab & vbTab & vbTab & "alert(""Load Error: "" + errorMsg) ;" & vbCr & vbLf & vbTab & vbTab & vbTab & "}//," & vbCr & vbLf & vbTab & vbTab & vbTab & "//{" & vbCr & vbLf & "			//" & vbTab & "'oauth2AccessToken': authMe ()," & vbCr & vbLf & "			//" & vbTab & "'x-ads-acm-namespace': 'WIPDM'," & vbCr & vbLf & "			//" & vbTab & "'x-ads-acm-check-groups': 'true'," & vbCr & vbLf & "		" & vbTab & "//}" & vbCr & vbLf & vbTab & vbTab & ") ;" & vbCr & vbLf & vbTab & "}" & vbCr & vbLf & "</script>" & vbCr & vbLf & "</body>" & vbCr & vbLf & "</html>"

#End Region

	End Class

	Sub Main()
		Try
			ForgeTest.initializeOAuth()

			Try
				ForgeTest.createBucket()
			Catch ex As Exception
				Console.WriteLine("Error creating bucket : " + ex.Message)
			End Try

			Try
				Dim uploadedObject As Object = ForgeTest.uploadFile()

				Try
					Dim job As Object = ForgeTest.translateToSVF(uploadedObject.objectId)

					If job.result = "success" OrElse job.result = "created" Then
						Dim base64Urn As String = job.urn

						Dim manifest As Object = ForgeTest.verifyJobComplete(base64Urn)
						If manifest.status = "success" Then
							ForgeTest.openViewer(manifest.urn)
						End If
					End If
				Catch ex As Exception
					Console.WriteLine("Error translating file : " + ex.Message)
				End Try
			Catch ex As Exception
				Console.WriteLine("Error uploading file : " + ex.Message)
			End Try
		Catch ex As Exception
			Console.WriteLine("Error Initializing OAuth client : " + ex.Message)
		End Try
	End Sub

End Module
