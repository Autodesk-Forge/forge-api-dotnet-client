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
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow () {
			InitializeComponent ();
		}

		private static string FORGE_CLIENT_ID ="" ; // 'your_client_id'
		private static string FORGE_CLIENT_SECRET ="" ; // 'your_client_secret'
		private static string FORGE_CALLBACK ="http://localhost:3006/oauth" ; // 'http://localhost:' + PORT + '/oauth' ;
		private static Scope[] _scope =new Scope[] { Scope.DataRead, Scope.DataWrite } ;
		private static ThreeLeggedApi _threeLeggedApi =new ThreeLeggedApi () ;

        private static HttpListener _httpListener =null ;

		// For a Synchronous example refer to the 2legged example

		// Asynchronous example (recommended)
		// http://stackoverflow.com/questions/4019466/httplistener-access-denied
		internal static void _3leggedAsync (NewBearerDelegate cb) {
			try {
				if ( !HttpListener.IsSupported )
					return ; // HttpListener is not supported on this platform.
				_httpListener =new HttpListener () ;
				_httpListener.Prefixes.Add (FORGE_CALLBACK.Replace ("localhost", "+") + "/") ;
				_httpListener.Start () ;
				//IAsyncResult result =_httpListener.BeginGetContext (new AsyncCallback (_3leggedAsyncWaitForCode), _httpListener) ;
				IAsyncResult result =_httpListener.BeginGetContext (_3leggedAsyncWaitForCode, cb) ;

				// Generate a URL page that asks for permissions for the specified scopes.
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
				//HttpListener listener =(HttpListener)result.AsyncState ;
				var context =_httpListener.EndGetContext (ar) ;
				string code =context.Request.QueryString [oAuthConstants.CODE] ;

				var responseString ="<html><body>You can now close this window!</body></html>" ;
				byte[] buffer =Encoding.UTF8.GetBytes (responseString) ;
				var response =context.Response ;
				response.ContentType ="text/html" ;
				response.ContentLength64 =buffer.Length ;
				response.StatusCode =200 ;
				response.OutputStream.Write (buffer, 0, buffer.Length) ;
				response.OutputStream.Close () ;

				if ( !string.IsNullOrEmpty (code) ) {
					ApiResponse<dynamic> bearer =await _threeLeggedApi.GettokenAsyncWithHttpInfo (FORGE_CLIENT_ID, FORGE_CLIENT_SECRET, oAuthConstants.AUTHORIZATION_CODE, code, FORGE_CALLBACK) ;
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

		internal delegate void NewBearerDelegate (dynamic bearer) ;

		public void TestAsync () {
            _3leggedAsync (null) ;
        }

		private void Window_Initialized (object sender, EventArgs e) {
            _3leggedAsync (new NewBearerDelegate (gotit)) ;

		}

		static void gotit (dynamic bearer) {
			if ( bearer == null ) {
				MessageBox.Show ("Sorry, Authentication failed!", "3legged test", MessageBoxButton.OK, MessageBoxImage.Error) ;
				return ;
			}
			string token =bearer.token_type + " " + bearer.access_token ;
			DateTime dt =DateTime.Now ;
			dt.AddSeconds (double.Parse (bearer.expires_in.ToString ())) ;
			MessageBox.Show ("You are in!", "3legged test", MessageBoxButton.OK, MessageBoxImage.Information) ;
		}

	}

}
