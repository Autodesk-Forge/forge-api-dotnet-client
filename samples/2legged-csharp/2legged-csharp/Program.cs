using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace ConsoleApplication3 {
	class Program {
		static void Main (string [] args) {
			Test () ;
			TestAsync () ;
			Console.WriteLine ("Press any key to exit...") ;
			Console.ReadKey () ;
		}

		private static string FORGE_CLIENT_ID ="" ; // 'your_client_id'
        private static string FORGE_CLIENT_SECRET ="" ; // 'your_client_secret'
        private static Scope[] _scope =new Scope[] { Scope.DataRead, Scope.DataWrite } ;
        private static TwoLeggedApi _twoLeggedApi =new TwoLeggedApi () ;

        // Synchronous example
        internal static dynamic _2leggedSynchronous () {
            try {
                ApiResponse<dynamic> bearer =_twoLeggedApi.AuthenticateWithHttpInfo (FORGE_CLIENT_ID, FORGE_CLIENT_SECRET, oAuthConstants.CLIENT_CREDENTIALS, _scope) ;
                //string token =bearer.Data.token_type + " " + bearer.Data.access_token ;
                //DateTime dt =DateTime.Now ;
                //dt.AddSeconds (double.Parse (bearer.Data.expires_in.ToString ())) ;
                return (bearer.Data) ;
            } catch ( Exception /*ex*/ ) {
                return (null) ;
            }
        }

        public static void Test () {
            dynamic bearer =_2leggedSynchronous () ;
            string token =bearer.token_type + " " + bearer.access_token ;
            Console.WriteLine("Your synchronous token test is: " + token)
        }

        // Asynchronous example (recommended)
        internal static async Task<dynamic> _2leggedAsync () {
            try {
                ApiResponse<dynamic> bearer =await _twoLeggedApi.AuthenticateAsyncWithHttpInfo (FORGE_CLIENT_ID, FORGE_CLIENT_SECRET, oAuthConstants.CLIENT_CREDENTIALS, _scope) ;
                //string token =bearer.Data.token_type + " " + bearer.Data.access_token ;
                //DateTime dt =DateTime.Now ;
                //dt.AddSeconds (double.Parse (bearer.Data.expires_in.ToString ())) ;
                return (bearer.Data) ;
            } catch ( Exception /*ex*/ ) {
                return (null) ;
            }
        }

        public async static void TestAsync () {
            dynamic bearer =await _2leggedAsync () ;
            string token =bearer.token_type + " " + bearer.access_token ;
            Console.WriteLine("Your async token test is: " + token)
        }

	}

}
