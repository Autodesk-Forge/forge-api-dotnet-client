using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace forge._2legged_csharp {
	class Program {
		static void Main (string [] args) {
			// Run a synchronous code to obtain an access_token
			Test () ;
			// Run an asynchronous code to obtain an access_token
			// This version does not block UI updates on the system
			TestAsync () ;

			Console.WriteLine ("Press any key to exit...") ;
			Console.ReadKey () ;
		}

		// Initialize the oAuth 2.0 client configuration fron enviroment variables
		// you can also hardcode them in the code if you want in the placeholders below
		private static string FORGE_CLIENT_ID =Environment.GetEnvironmentVariable ("FORGE_CLIENT_ID")?? "your_client_id" ;
        private static string FORGE_CLIENT_SECRET =Environment.GetEnvironmentVariable ("FORGE_CLIENT_SECRET")?? "your_client_secret" ;
        private static Scope[] _scope =new Scope[] { Scope.DataRead, Scope.DataWrite } ;

		// Intialize the 2-legged oAuth 2.0 client.
        private static TwoLeggedApi _twoLeggedApi =new TwoLeggedApi () ;

        // Synchronous example
        internal static dynamic _2leggedSynchronous () {
            try {
				// Call the synchronous version of the 2-legged client with HTTP information
				// HTTP information will help you to verify if the call was successful as well
				// as read the HTTP transaction headers.
                ApiResponse<dynamic> bearer =_twoLeggedApi.AuthenticateWithHttpInfo (FORGE_CLIENT_ID, FORGE_CLIENT_SECRET, oAuthConstants.CLIENT_CREDENTIALS, _scope) ;
				//if ( bearer.StatusCode != 200 )
				//	throw new Exception ("Request failed! (with HTTP response " + bearer.StatusCode + ")") ;

				// The JSON response from the oAuth server is the Data variable and has been
				// already parsed into a DynamicDictionary object.

                //string token =bearer.Data.token_type + " " + bearer.Data.access_token ;
                //DateTime dt =DateTime.Now ;
                //dt.AddSeconds (double.Parse (bearer.Data.expires_in.ToString ())) ;

                return (bearer.Data) ;
            } catch ( Exception ex ) {
				Console.WriteLine (ex.Message) ;
                return (null) ;
            }
        }

        public static void Test () {
            dynamic bearer =_2leggedSynchronous () ;
			if ( bearer == null ) {
				Console.WriteLine ("You were not granted a new access_token!") ;
				return ;
			}
			// The call returned successfully and you got a valid access_token.
            string token =bearer.token_type + " " + bearer.access_token ;
            Console.WriteLine ("Your synchronous token test is: " + token) ;
        }

        // Asynchronous example (recommended)
        internal static async Task<dynamic> _2leggedAsync () {
            try {
				// Call the asynchronous version of the 2-legged client with HTTP information
				// HTTP information will help you to verify if the call was successful as well
				// as read the HTTP transaction headers.
                ApiResponse<dynamic> bearer =await _twoLeggedApi.AuthenticateAsyncWithHttpInfo (FORGE_CLIENT_ID, FORGE_CLIENT_SECRET, oAuthConstants.CLIENT_CREDENTIALS, _scope) ;
				//if ( bearer.StatusCode != 200 )
				//	throw new Exception ("Request failed! (with HTTP response " + bearer.StatusCode + ")") ;

				// The JSON response from the oAuth server is the Data variable and has been
				// already parsed into a DynamicDictionary object.

                //string token =bearer.Data.token_type + " " + bearer.Data.access_token ;
                //DateTime dt =DateTime.Now ;
                //dt.AddSeconds (double.Parse (bearer.Data.expires_in.ToString ())) ;
                return (bearer.Data) ;
            } catch ( Exception ex ) {
				Console.WriteLine (ex.Message) ;
                return (null) ;
            }
        }

        public async static void TestAsync () {
            dynamic bearer =await _2leggedAsync () ;
			if ( bearer == null ) {
				Console.WriteLine ("You were not granted a new access_token!") ;
				return ;
			}
			// The call returned successfully and you got a valid access_token.
            string token =bearer.token_type + " " + bearer.access_token ;
            Console.WriteLine ("Your async token test is: " + token) ;
        }

	}

}
