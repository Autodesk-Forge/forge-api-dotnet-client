using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Autodesk.Forge;
using Autodesk.Forge.Model;
using Autodesk.Forge.Client;

namespace forge._3legged_csharp {

	public partial class MainWindow : Window {
		public MainWindow () {
			InitializeComponent () ;
		}

		// Initialize the oAuth 2.0 client configuration fron enviroment variables
		// you can also hardcode them in the code if you want in the placeholders below
		private static string FORGE_CLIENT_ID =Environment.GetEnvironmentVariable ("FORGE_CLIENT_ID")?? "your_client_id" ;
		private static string FORGE_CLIENT_SECRET =Environment.GetEnvironmentVariable ("FORGE_CLIENT_SECRET")?? "your_client_secret" ;
		private static string PORT =Environment.GetEnvironmentVariable ("PORT")?? "3006" ;
		private static string FORGE_CALLBACK =Environment.GetEnvironmentVariable ("FORGE_CALLBACK")?? "http://localhost:" + PORT + "/oauth" ;
		private static Scope[] _scope =new Scope[] { Scope.DataRead, Scope.DataWrite } ;

		// Intialize the 3-legged oAuth 2.0 client.
		private static ThreeLeggedApi _threeLeggedApi =new ThreeLeggedApi () ;

		// Declare a local web listener to wait for the oAuth callback on the local machine.
		// Please read this article to configure your local machine properly
		// http://stackoverflow.com/questions/4019466/httplistener-access-denied
		//   ex: netsh http add urlacl url=http://+:3006/oauth user=cyrille
		// Embedded webviews are strongly discouraged for oAuth - https://developers.google.com/identity/protocols/OAuth2InstalledApp
		private static HttpListener _httpListener =null ;

		internal delegate void NewBearerDelegate (dynamic bearer) ;

		// For a synchronous example refer to the 2legged example

		// Asynchronous example (recommended)
		internal static void _3leggedAsync (NewBearerDelegate cb) {
			try {
				if ( !HttpListener.IsSupported )
					return ; // HttpListener is not supported on this platform.
				// Initialize our web listerner
				_httpListener =new HttpListener () ;
				_httpListener.Prefixes.Add (FORGE_CALLBACK.Replace ("localhost", "+") + "/") ;
				_httpListener.Start () ;
				//IAsyncResult result =_httpListener.BeginGetContext (new AsyncCallback (_3leggedAsyncWaitForCode), _httpListener) ;
				IAsyncResult result =_httpListener.BeginGetContext (_3leggedAsyncWaitForCode, cb) ;

				// Generate a URL page that asks for permissions for the specified scopes, and call our default web browser.
				string oauthUrl =_threeLeggedApi.Authorize (FORGE_CLIENT_ID, oAuthConstants.CODE, FORGE_CALLBACK, _scope) ;
				System.Diagnostics.Process.Start (new System.Diagnostics.ProcessStartInfo (oauthUrl)) ;

				//result.AsyncWaitHandle.WaitOne () ;
				//_httpListener.Stop () ;
			} catch ( Exception ex ) {
				Console.WriteLine (ex.Message) ;
			}
		}

		internal static async void _3leggedAsyncWaitForCode (IAsyncResult ar) {
			try {
				// Our local web listener was called back from the Autodesk oAuth server
				// That means the user logged properly and granted our application access
				// for the requested scope.
				// Let's grab the code fron the URL and request or final access_token

				//HttpListener listener =(HttpListener)result.AsyncState ;
				var context =_httpListener.EndGetContext (ar) ;
				string code =context.Request.QueryString [oAuthConstants.CODE] ;

				// The code is only to tell the user, he can close is web browser and return
				// to this application.
				var responseString ="<html><body>You can now close this window!</body></html>" ;
				byte[] buffer =Encoding.UTF8.GetBytes (responseString) ;
				var response =context.Response ;
				response.ContentType ="text/html" ;
				response.ContentLength64 =buffer.Length ;
				response.StatusCode =200 ;
				response.OutputStream.Write (buffer, 0, buffer.Length) ;
				response.OutputStream.Close () ;

				// Now request the final access_token
				if ( !string.IsNullOrEmpty (code) ) {
					// Call the asynchronous version of the 3-legged client with HTTP information
					// HTTP information will help you to verify if the call was successful as well
					// as read the HTTP transaction headers.
					ApiResponse<dynamic> bearer =await _threeLeggedApi.GettokenAsyncWithHttpInfo (FORGE_CLIENT_ID, FORGE_CLIENT_SECRET, oAuthConstants.AUTHORIZATION_CODE, code, FORGE_CALLBACK) ;
					//if ( bearer.StatusCode != 200 )
					//	throw new Exception ("Request failed! (with HTTP response " + bearer.StatusCode + ")") ;

					// The JSON response from the oAuth server is the Data variable and has been
					// already parsed into a DynamicDictionary object.

					//string token =bearer.Data.token_type + " " + bearer.Data.access_token ;
					//DateTime dt =DateTime.Now ;
					//dt.AddSeconds (double.Parse (bearer.Data.expires_in.ToString ())) ;

					((NewBearerDelegate)ar.AsyncState)?.Invoke (bearer.Data) ;
				} else {
					((NewBearerDelegate)ar.AsyncState)?.Invoke (null) ;
				}
			} catch ( Exception ex ) {
				Console.WriteLine (ex.Message) ;
				((NewBearerDelegate)ar.AsyncState)?.Invoke (null) ;
			} finally {
				_httpListener.Stop () ;
			}
		}

		private void Window_Initialized (object sender, EventArgs e) {
			_3leggedAsync (new NewBearerDelegate (gotit)) ;
		}

		// This is our application delegate. It is called upon success or failure
		// after the process completed
		static void gotit (dynamic bearer) {
			if ( bearer == null ) {
				MessageBox.Show ("Sorry, Authentication failed!", "3legged test", MessageBoxButton.OK, MessageBoxImage.Error) ;
				return ;
			}
			// The call returned successfully and you got a valid access_token.
			string token =bearer.token_type + " " + bearer.access_token ;
			DateTime dt =DateTime.Now ;
			dt.AddSeconds (double.Parse (bearer.expires_in.ToString ())) ;
			MessageBox.Show ("You are in!", "3legged test", MessageBoxButton.OK, MessageBoxImage.Information) ;
		}

	}

}
