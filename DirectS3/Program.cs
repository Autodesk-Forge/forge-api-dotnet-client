/* 
 * Forge SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk
 * cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Contact: forge.help@autodesk.com
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace DirectS3 {

	internal class Program {

		#region Enums & Consts
		public enum Region {
			US,
			EMEA
		};

		#endregion

		#region Fields & Properties
		private static string FORGE_CLIENT_ID { get; set; } = "";
		private static string FORGE_CLIENT_SECRET { get; set; } = "";
		private static readonly Scope [] SCOPES = new Scope [] {
			Scope.DataRead, Scope.DataWrite, Scope.DataCreate, Scope.DataSearch,
			Scope.BucketCreate, Scope.BucketRead, Scope.BucketUpdate, Scope.BucketDelete
		};
		protected static string BucketKey { get { return ("forge_sample_" + FORGE_CLIENT_ID.ToLower () + "-" + region.ToString ().ToLower ()); } }
		protected static string ObjectKey { get { return ("test.nwd"); } }

		protected static Region region { get; set; } = Region.US;

		// We use the same Bearer token for upload and download here,
		// but we should usually have different bearers with different scopes
		protected static BucketsApi BucketAPI = new BucketsApi ();
		protected static ObjectsApi ObjectsAPI = new ObjectsApi ();

		#endregion

		#region Forge
		private async static Task<ApiResponse<dynamic>?> oauthExecAsync () {
			try {
				TwoLeggedApi _twoLeggedApi = new TwoLeggedApi ();
				ApiResponse<dynamic> bearer = await _twoLeggedApi.AuthenticateAsyncWithHttpInfo (FORGE_CLIENT_ID, FORGE_CLIENT_SECRET, oAuthConstants.CLIENT_CREDENTIALS, SCOPES);
				httpErrorHandler (bearer, "Failed to get your token");

				BucketAPI.Configuration.Bearer = new Bearer (bearer);
				ObjectsAPI.Configuration.Bearer = new Bearer (bearer);

				return (bearer);
			} catch ( Exception ex ) {
				Console.WriteLine ("Exception when calling TwoLeggedApi.AuthenticateAsyncWithHttpInfo : " + ex.Message);
				return (null);
			}
		}

		private async static Task<dynamic?> GetBucketDetails () {
			try {
				Console.WriteLine ("**** Getting bucket details for: " + BucketKey);
				var response = await BucketAPI.GetBucketDetailsAsync (BucketKey);
				return (response);
			} catch ( Exception ) {
				Console.WriteLine ("**** Failed getting bucket details for : " + BucketKey);
				return (null);
			}
		}

		private async static Task<dynamic?> CreateBucket () {
			try {
				Console.WriteLine ("**** Creating bucket: " + BucketKey);
				PostBucketsPayload.PolicyKeyEnum bucketType = PostBucketsPayload.PolicyKeyEnum.Persistent;
				PostBucketsPayload payload = new PostBucketsPayload (BucketKey, null, bucketType);
				dynamic response = await BucketAPI.CreateBucketAsync (payload, region.ToString ());
				return (response);
			} catch ( Exception ) {
				Console.WriteLine ("**** Failed creating bucket: " + BucketKey);
				return (null);
			}
		}

		private async static Task<bool> CreateBucketIfNotExist () {
			dynamic? response = await GetBucketDetails ();
			if ( response == null )
				response = await CreateBucket ();
			if ( response == null )
				Console.WriteLine ("*** Failed to create bucket: " + BucketKey);
			return (response != null);
		}

		private async static Task<bool> DeleteBucket () {
			try {
				Console.WriteLine ("**** Deleting bucket: " + BucketKey);
				await BucketAPI.DeleteBucketAsync (BucketKey);
				return (true);
			} catch ( Exception ) {
				Console.WriteLine ("**** Failed deleting bucket: " + BucketKey);
				return (false);
			}
		}

		private async static Task<dynamic?> GetObjectDetails () {
			try {
				Console.WriteLine ("**** Getting object details: " + ObjectKey);
				dynamic response = await ObjectsAPI.GetObjectDetailsAsync (BucketKey, ObjectKey);
				return (response);
			} catch ( Exception ) {
				Console.WriteLine ("**** Failed getting object details: " + ObjectKey);
				return (null);
			}
		}

		private async static Task<bool> UploadBinaryContent (string uploadURL, string fileName) {
			try {
				using ( FileStream fileStream = File.OpenRead (fileName) ) {
					HttpClient httpClient = new HttpClient ();
					StreamContent streamContent = new StreamContent (fileStream);
					HttpResponseMessage response = await httpClient.PutAsync (uploadURL, streamContent);
					return (response.StatusCode == System.Net.HttpStatusCode.OK);
				}
			} catch ( Exception ex ) {
				Console.WriteLine ("**** Failed to upload binary to S3 - " + ex.Message);
			}
			return (false);
		}

		private async static Task<string?> UploadObject2Bucket () {
			try {
				Console.WriteLine ("**** Uploading object: " + ObjectKey);
				dynamic response = await ObjectsAPI.getS3UploadURLAsyncWithHttpInfo (BucketKey, ObjectKey);
				httpErrorHandler (response, "Failed to request a upload url");
				//response.Data ['uploadKey']
				//response.Data ['urls'] [0]
				response = await UploadBinaryContent (response.Data ["urls"] [0], ObjectKey);
				if ( response != true )
					Console.WriteLine ("Failed to upload file");
				return (BuildURN (BucketKey, ObjectKey));
			} catch ( Exception ex ) {
				Console.WriteLine ("**** Failed to upload file - " + ex.Message);
				return (null);
			}
		}

		private async static Task<string?> UploadSampleFile () {
			dynamic? response = await GetObjectDetails ();
			//if ( response != null )
			//	return (response.objectId);
			response = await UploadObject2Bucket ();
			if ( response == null ) {
				Console.WriteLine ("*** Failed to upload sample file: " + ObjectKey);
				return (null);
			}
			return (response);
		}

		private async static Task<string?> GetBrowserURL2Download () {
			try {
				Console.WriteLine ("**** Getting Direct S3 URL: " + ObjectKey);

				ApiResponse<dynamic> response = await ObjectsAPI.getS3DownloadURLAsyncWithHttpInfo (
					BucketKey,
					ObjectKey
				);

				httpErrorHandler (response, "Failed to get Direct S3 URL");
				return (response.Data ["url"]);
			} catch ( Exception ex ) {
				Console.WriteLine ("**** Failed to get Direct S3 URL - " + ex.Message);
				return (null);
			}
		}

		private async static Task<string?> GetObjectURLs () {
			try {
				Console.WriteLine ("**** Getting Direct S3 URLs: " + ObjectKey);

				List<PostBatchSignedS3DownloadPayloadItem> items = new List<PostBatchSignedS3DownloadPayloadItem> () {
					new PostBatchSignedS3DownloadPayloadItem(ObjectKey)
				};
				PostBatchSignedS3DownloadPayload payload = new PostBatchSignedS3DownloadPayload (items);

				ApiResponse<dynamic> response = await ObjectsAPI.getS3DownloadURLsAsyncWithHttpInfo (
					BucketKey,
					payload
				);

				httpErrorHandler (response, "Failed to get Direct S3 URLs");
				return (response.Data ["results"] [ObjectKey] ["url"]);
			} catch ( Exception ex ) {
				Console.WriteLine ("**** Failed to get Direct S3 URLs - " + ex.Message);
				return (null);
			}
		}

		private async static Task<bool> DownloadBinaryContent (string downloadURL, string fileName) {
			Console.WriteLine ("**** Download file from Direct S3: " + fileName);
			try {
				using ( HttpClient httpClient = new HttpClient () ) {
					using Stream streamToReadFrom = await httpClient.GetStreamAsync (downloadURL);
					using Stream streamToWriteTo = File.Open ("_temp-" + fileName, FileMode.Create);
					await streamToReadFrom.CopyToAsync (streamToWriteTo);
				}
				return (true);
			} catch ( Exception ex ) {
				Console.WriteLine ("**** Failed to download binary from S3 - " + ex.Message);
			}
			return (false);
		}

		private static bool DeleteSampleFile () {
			try {
				Console.WriteLine ("**** Deleting object: " + ObjectKey);
				ObjectsAPI.DeleteObject (BucketKey, ObjectKey);
				return (true);
			} catch ( Exception ) {
				Console.WriteLine ("**** Failed deleting object: " + ObjectKey);
				return (false);
			}
		}

		#endregion

		#region Utils
		private static void readFromEnvOrSettings (string name, Action<string> setOutput) {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
			string st = Environment.GetEnvironmentVariable (name);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
			if ( !string.IsNullOrEmpty (st) )
				setOutput (st);
		}

		private static bool readConfigFromEnvOrSettings () {
			readFromEnvOrSettings ("FORGE_CLIENT_ID", value => FORGE_CLIENT_ID = value);
			readFromEnvOrSettings ("FORGE_CLIENT_SECRET", value => FORGE_CLIENT_SECRET = value);
			//readFromEnvOrSettings("PORT", value => PORT = value);
			//readFromEnvOrSettings("FORGE_CALLBACK", value => FORGE_CALLBACK = value);
			return (true);
		}

		public static bool httpErrorHandler (ApiResponse<dynamic> response, string msg = "", bool bThrowException = true) {
			if ( response.StatusCode < 200 || response.StatusCode >= 300 ) {
				if ( bThrowException )
					throw new Exception (msg + " (HTTP " + response.StatusCode + ")");
				return (true);
			}
			return (false);
		}

		private static readonly char [] padding = { '=' };
		public static string SafeBase64Encode (string plainText) {
			var plainTextBytes = System.Text.Encoding.UTF8.GetBytes (plainText);
			return (System.Convert.ToBase64String (plainTextBytes)
				.TrimEnd (padding).Replace ('+', '-').Replace ('/', '_')
			);
		}

		public static string SafeBase64Decode (string base64EncodedData) {
			string st = base64EncodedData.Replace ('_', '/').Replace ('-', '+');
			switch ( base64EncodedData.Length % 4 ) {
				case 2:
					st += "==";
					break;
				case 3:
					st += "=";
					break;
			}
			var base64EncodedBytes = System.Convert.FromBase64String (st);
			return (System.Text.Encoding.UTF8.GetString (base64EncodedBytes));
		}

		public static string BuildURN (string bucketKey, string objectKey) {
			return (SafeBase64Encode ($"urn:adsk.objects:os.object:{bucketKey}/{objectKey}"));
		}

		#endregion

		#region US / EMEA processes
		static async Task CleanUP () {
			Console.WriteLine ("Running cleanup");

			dynamic? response = await oauthExecAsync ();
			if ( response == null )
				return;

			await DeleteBucket (); // This deletes the file(s) as well
		}

		static async Task<string?> TryWorkflow (Region storage = Region.US) {
			Console.WriteLine ("Running with Storage: " + storage.ToString ());
			region = storage;

			dynamic? response = await oauthExecAsync ();
			if ( response == null )
				return (null);
			response = await CreateBucketIfNotExist ();
			if ( !response )
				return (null);
			//DeleteSampleFile();
			response = await UploadSampleFile ();
			if ( response == null )
				return (null);
			//response = BuildURN(BucketKey, ObjectKey);
			string urn = SafeBase64Encode (response);

			response = await GetBrowserURL2Download ();
			if ( response != null )
				Console.WriteLine ("You can download the file from your browser using " + response);
			// Same idea but using multiple uRL approach
			response = await GetObjectURLs ();
			if ( response == null )
				return (null);
			response = await DownloadBinaryContent (response, ObjectKey);

			// Now do whatever you want...

			return (urn);
		}

		#endregion

		static async Task Main (string [] args) {
			Console.WriteLine ("Hello World!");
			//region = Region.US; // Done while initializing
			//DerivativesAPI = USDerivativesAPI;

			readConfigFromEnvOrSettings ();
			string? urn = BuildURN (BucketKey, ObjectKey);

			if ( args [0] == "cleanup" ) {
				try {
					//Region endpoint = Enum.Parse<Region> (args [1], true);
					//Region storage = Enum.Parse<Region> (args [2], true);

					await CleanUP ();
				} catch ( Exception ) { }

			} else {
				try {
					//Region endpoint = Enum.Parse<Region> (args [0], true);
					Region storage = Enum.Parse<Region> (args [1], true);

					urn = await TryWorkflow (
						storage
					);
				} catch ( Exception ) { }
			}
			Console.WriteLine ("Done");
		}

	}

}