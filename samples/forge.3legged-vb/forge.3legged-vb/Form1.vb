Option Strict Off
Imports System.Net
Imports System.Text
Imports System.Windows.Forms

Imports Autodesk.Forge
Imports Autodesk.Forge.Model
Imports Autodesk.Forge.Client

Public Class Form1

    Private Shared FORGE_CLIENT_ID As String = "" ' 'your_client_id'
    Private Shared FORGE_CLIENT_SECRET As String = "" ' 'your_client_secret'
    Private Shared FORGE_CALLBACK As String = "http://localhost:3006/oauth" ' 'http://localhost:' + PORT + '/oauth' ;
    Private Shared _scope As Scope() = New Scope() {Scope.DataRead, Scope.DataWrite}
    Private Shared _threeLeggedApi As ThreeLeggedApi = New ThreeLeggedApi()

    Private Shared _httpListener As HttpListener = Nothing

    ' For a Synchronous example refer to the 2legged example

    ' Asynchronous example (recommended)
    ' http://stackoverflow.com/questions/4019466/httplistener-access-denied
    '   ex: netsh http add urlacl url=http://+:3006/oauth user=cyrille
    ' Embedded webviews are strongly discouraged for oAuth - https://developers.google.com/identity/protocols/OAuth2InstalledApp

    Public Shared Sub _3legged(cb As NewBearerDelegate)
        Try
            If Not HttpListener.IsSupported Then
                Return ' HttpListener Is Not supported on this platform.
                _httpListener = New HttpListener()
                _httpListener.Prefixes.Add(FORGE_CALLBACK.Replace("localhost", "+") + "/")
                _httpListener.Start()
                Dim result As IAsyncResult = _httpListener.BeginGetContext(AddressOf _3leggedAsyncWaitForCode, cb)
            End If
        Catch ex As Exception
            Return
        End Try
    End Sub

    Private Shared Sub _3leggedAsync(cb As NewBearerDelegate)
        Try
            If Not HttpListener.IsSupported Then
                Return ' HttpListener Is Not supported on this platform.
            End If
            _httpListener = New HttpListener()
            _httpListener.Prefixes.Add(FORGE_CALLBACK.Replace("localhost", "+") + "/")
            _httpListener.Start()
            Dim result As IAsyncResult = _httpListener.BeginGetContext(AddressOf _3leggedAsyncWaitForCode, cb)

            ' Generate a URL page that asks for permissions for the specified scopes.
            Dim oauthUrl As String = _threeLeggedApi.Authorize(FORGE_CLIENT_ID, oAuthConstants.CODE, FORGE_CALLBACK, _scope)
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(oauthUrl))

            'result.AsyncWaitHandle.WaitOne()
            '_httpListener.Stop()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Shared Async Sub _3leggedAsyncWaitForCode(ar As IAsyncResult)
        Try
            'Dim listener As HttpListener = CType(ar.AsyncState, HttpListener)
            Dim context As HttpListenerContext = _httpListener.EndGetContext(ar)
            Dim code As String = context.Request.QueryString.Get(oAuthConstants.CODE)
            Dim responseString As String = "<html><body>You can now close this window!</body></html>"
            Dim buffer() As Byte = Encoding.UTF8.GetBytes(responseString)
            Dim response As HttpListenerResponse = context.Response
            response.ContentType = "text/html"
            response.ContentLength64 = buffer.Length
            response.StatusCode = 200
            response.OutputStream.Write(buffer, 0, buffer.Length)
            response.OutputStream.Close()

            If Not String.IsNullOrEmpty(code) Then
                Dim bearer As ApiResponse(Of Object) = Await _threeLeggedApi.GettokenAsyncWithHttpInfo(FORGE_CLIENT_ID, FORGE_CLIENT_SECRET, oAuthConstants.AUTHORIZATION_CODE, code, FORGE_CALLBACK)
                'Dim token As String = bearer.Data.token_type + " " + bearer.Data.access_token
                'Dim dt As DateTime = DateTime.Now
                'dt.AddSeconds(Double.Parse(bearer.Data.expires_in.ToString()))

                CType(ar.AsyncState, NewBearerDelegate)?.Invoke(bearer.Data)
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            CType(ar.AsyncState, NewBearerDelegate)?.Invoke(Nothing)
        Finally
            _httpListener.Stop()
        End Try
    End Sub

    Delegate Sub NewBearerDelegate(bearer As Object)

    Public Shared Sub TestAsync()
        _3leggedAsync(Nothing)
    End Sub

    Private Sub OnFormLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        _3leggedAsync(New NewBearerDelegate(AddressOf gotit))
    End Sub

    Private Shared Sub gotit(bearer As Object)
        If bearer Is Nothing Then
            MessageBox.Show("Sorry, Authentication failed!", "3legged test", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim token As String = bearer.token_type + " " + bearer.access_token
        Dim dt As DateTime = DateTime.Now
        dt.AddSeconds(Double.Parse(bearer.expires_in.ToString()))
        MessageBox.Show("You are in!", "3legged test", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class