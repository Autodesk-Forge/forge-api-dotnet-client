Option Strict Off

Imports Autodesk.Forge
Imports Autodesk.Forge.Client
Imports Autodesk.Forge.Model

Module Module1

    Sub Main()
    End Sub

    Public Class Line

        Private Shared FORGE_CLIENT_ID As String = "" ' 'your_client_id'
        Private Shared FORGE_CLIENT_SECRET As String = "" ' 'your_client_secret'
        Private Shared _scope As Scope() = New Scope() {Scope.DataRead, Scope.DataWrite}
        Private Shared _twoLeggedApi As TwoLeggedApi = New TwoLeggedApi()

        ' Synchronous example
        Public Shared Function _2leggedSynchronous() As Object
            Try
                Dim bearer As ApiResponse(Of Object) = _twoLeggedApi.AuthenticateWithHttpInfo(FORGE_CLIENT_ID, FORGE_CLIENT_SECRET, oAuthConstants.CLIENT_CREDENTIALS, _scope)
                Dim token As String = bearer.Data.token_type + " " + bearer.Data.access_token
                Dim dt As DateTime = DateTime.Now
                dt.AddSeconds(Double.Parse(bearer.Data.expires_in.ToString()))
                Return (bearer.Data)
            Catch ex As Exception
				Return (Nothing)
			End Try
        End Function

        Public Shared Sub Test()
            Dim bearer As Object = _2leggedSynchronous()
            Dim token As String = bearer.token_type + " " + bearer.access_token
            ' ...
        End Sub

        ' Asynchronous example (recommended)
        Public Shared Async Function _2leggedAsync() As Task(Of Object)
            Try
                Dim bearer As ApiResponse(Of Object) = Await _twoLeggedApi.AuthenticateAsyncWithHttpInfo(FORGE_CLIENT_ID, FORGE_CLIENT_SECRET, oAuthConstants.CLIENT_CREDENTIALS, _scope)
                Dim token As String = bearer.Data.token_type + " " + bearer.Data.access_token
                Dim dt As DateTime = DateTime.Now
                dt.AddSeconds(Double.Parse(bearer.Data.expires_in.ToString()))
                Return (bearer.Data)
            Catch ex As Exception
				Return (Nothing)
			End Try
        End Function

        Public Shared Async Sub TestAsync()
            Dim bearer As Object = Await _2leggedAsync()
            Dim token As String = bearer.token_type + " " + bearer.access_token
            ' ...
        End Sub

    End Class

End Module