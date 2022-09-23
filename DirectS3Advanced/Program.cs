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
using System.Diagnostics;
using System.Net.Http.Headers;

namespace DirectS3Advanced {

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

		protected static Region region { get; set; } = Region.US;

		// We use the same Bearer token for upload and download here,
		// but we should usually have different bearers with different scopes
		protected static BucketsApi BucketAPI = new BucketsApi ();
		protected static ObjectsApi ObjectsAPI = new ObjectsApi ();

		protected static string FILE_NAME0 = "test.txt";
		protected static string FILE_NAME1 = "test-small.obj";
		protected static string FILE_NAME2 = "test.nwd";
		protected static string FILE_NAME3 = "test-large.dwfx";

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

		private async static Task<List<string>> verifyServerObjectsSha1 (string bucketKey, List<UploadItemDesc> objects) {
			List<string> sha1s = new List<string> (objects.Count);
			foreach ( UploadItemDesc resp in objects ) { // SHA1 takes time to be processed in the server, need to wait sometimes
				if ( resp.Error )
					sha1s.Add ("");
				string srcSha1 = ObjectsApi.calculateSHA1 (resp.data);
				for ( ; ; ) {
					dynamic serverSha1Resp = await ObjectsAPI.GetObjectDetailsAsync (bucketKey, resp.objectKey);
					if ( !serverSha1Resp.ContainsKey ("sha1") ) {
						System.Threading.Thread.Sleep (5000); // 5 seconds - usually it is faster, but for large objects might take a bit longer
						continue;
					}
					string serverSha1 = serverSha1Resp ["sha1"];
					if ( srcSha1 != serverSha1 ) {
						Console.WriteLine ("Error: SHA1 differs for object {0} {1} vs {2})", resp.objectKey, resp.Length, serverSha1Resp ["size"]);
						Console.WriteLine (serverSha1Resp);
					}
					sha1s.Add (srcSha1);
					break;
				}
			}
			return (sha1s);
		}

		private static List<bool> compareObjects (List<UploadItemDesc> uploadRes, List<DownloadItemDesc> downloadRes) {
			List<bool> sha1s = new List<bool> (uploadRes.Count);
			foreach ( var upload in uploadRes ) {
				if ( upload.Error ) {
					sha1s.Add (false);
					continue;
				}
				// SHA1 takes time to be processed in the server, need to wait sometimes
				string srcSha1 = ObjectsApi.calculateSHA1 (upload.data);
				DownloadItemDesc target = downloadRes.Where (x => x.objectKey == upload.objectKey).ToArray () [0];
				string targetSha1 = ObjectsApi.calculateSHA1 (target.data);
				if ( srcSha1 != targetSha1 ) {
					Console.WriteLine ("Error: SHA1 differs for object {0}", upload.objectKey);
					Console.WriteLine (target.downloadParams);
				}
				sha1s.Add (targetSha1 == srcSha1);
			}
			return (sha1s);
		}

		private async static Task<ApiResponse<Object>> deleteFile (string bucketKey, string objectKey) {
			Console.WriteLine ("**** Deleting file from bucket: {0}, object: {1}", bucketKey, objectKey);
			return (await ObjectsAPI.DeleteObjectAsyncWithHttpInfo (bucketKey, objectKey));
		}

		private async static Task deleteAllServerObjects (string bucketKey, List<UploadItemDesc> objects) {
			foreach ( var resp in objects ) {
				if ( resp.Error )
					return;
				var deleteRes = await deleteFile (bucketKey, resp.objectKey);
				Console.WriteLine ("**** Delete file response status code: {0}", deleteRes.StatusCode);
			}
		}

		#endregion

		#region Workflow
		static async Task TryWorkflow (Region storage = Region.US) {
			Console.WriteLine ("Running with Storage: " + storage.ToString ());
			region = storage;

			dynamic? response = await oauthExecAsync ();
			if ( response == null )
				return;
			response = await CreateBucketIfNotExist ();
			if ( !response )
				return;

			// We use the same Bearer token for upload and download here,
			// but we should usually have different bearers with different scopes
			async Task<Bearer> onRefreshToken () {
				ApiResponse<dynamic>? bearer = await oauthExecAsync ();
				// Note our oauthExecAsync method already updates the API wrappers
				// returning the bearer isn't stricly required (we could have returned null)
				return (new Bearer (bearer));
			}
			void onUploadProgress (float progress, TimeSpan elapsed, List<UploadItemDesc> objects) {
				Console.WriteLine ("progress: {0} elapsed: {1} objects: {2}", progress, elapsed, string.Join (", ", objects));
			}
			void onDownloadProgress (float progress, TimeSpan elapsed, List<DownloadItemDesc> objects) {
				Console.WriteLine ("progress: {0} elapsed: {1} objects: {2}", progress, elapsed, string.Join (", ", objects));
			}

			// Small Files
			Console.WriteLine ("**** Testing object and small files");
			byte [] _buffer = File.ReadAllBytes (FILE_NAME1);
			FileStream _stream = File.Open (FILE_NAME1, FileMode.Open);
			var uploadRes = await ObjectsAPI.uploadResources (
				BucketKey,
				new List<UploadItemDesc> () {
					new UploadItemDesc (FILE_NAME0, "this is a string"), // string test
					new UploadItemDesc (FILE_NAME1 + ".txt", _buffer.ToString ()), // file:// test, we know it is a text file
					new UploadItemDesc (FILE_NAME1, _buffer), // file:// test, but as Buffer this time
					new UploadItemDesc (FILE_NAME1 + ".bin", _stream), // file:// test, but as ReadableStream this time
				},
				new Dictionary<string, object> () {
					//{ "chunkSize", 3 }, // use 3Mb to make it fails, use a debug ApiClient, objectsApi.apiClient.isDebugMode = true
					//{ "minutesExpiration", 2 },
					//{ "useAcceleration", true }
				},
				onUploadProgress,
				onRefreshToken
			);
			Console.WriteLine ("**** Upload object(s) response(s):");
			foreach ( var resp in uploadRes )
				Console.WriteLine ("{0} {1}{2}", resp.objectKey, resp.Error ? "Error: " : "", resp.completed.ToString ());

			Console.WriteLine ("**** Verifying SHA1 codes"); // re-assembling files takes times, but we uploaded these files in 1 part :)
			await verifyServerObjectsSha1 (BucketKey, uploadRes);

			FileStream _streamOut = File.Open (FILE_NAME1 + ".out", FileMode.Create);
			var downloadRes = await ObjectsAPI.downloadResources (
				BucketKey,
				new List<DownloadItemDesc> () {
					new DownloadItemDesc (FILE_NAME0, "text"), // string test
					new DownloadItemDesc (FILE_NAME1 + ".txt", "arraybuffer"), // Buffer
					new DownloadItemDesc (FILE_NAME1, "arraybuffer"), // Buffer
					new DownloadItemDesc (FILE_NAME1 + ".bin", "stream", _streamOut), // file:// test, but as WritableStream this time
					new DownloadItemDesc (FILE_NAME0, "text", null, new Dictionary<string, object> () { { "Range", new RangeHeaderValue (5, 10) } } ), // with range
				},
				new Dictionary<string, object> () {
					//{ "publicResourceFallback", true }, // use 3Mb to make it fails, use a debug ApiClient, objectsApi.apiClient.isDebugMode = true
					//{ "minutesExpiration", 2 },
					//{ "useCdn", true }
				},
				onDownloadProgress,
				onRefreshToken
			);

			Console.WriteLine ("**** Verifying SHA1 codes with downloads");
			compareObjects (uploadRes, downloadRes);
			Console.WriteLine ("**** Deleting server files(s)");
			await deleteAllServerObjects (BucketKey, uploadRes);
			try { File.Delete (FILE_NAME1 + ".out"); } catch { }
		
			// Large Files < 5Mb <
			Console.WriteLine ("**** Testing Large files");
			_buffer = File.ReadAllBytes (FILE_NAME2);
			_stream = File.Open (FILE_NAME2, FileMode.Open);
			byte [] _buffer3 = File.ReadAllBytes (FILE_NAME3);
			FileStream _stream3 = File.Open (FILE_NAME3, FileMode.Open);
			long size = _buffer3.LongLength;
			uploadRes = await ObjectsAPI.uploadResources (
				BucketKey,
				new List<UploadItemDesc> () {
					new UploadItemDesc (FILE_NAME2, _buffer),
					new UploadItemDesc (FILE_NAME2 + ".bin", _stream),
					new UploadItemDesc (FILE_NAME3, _buffer3),
					new UploadItemDesc (FILE_NAME3 + ".bin", _stream3),
				},
				new Dictionary<string, object> () {
					//{ "chunkSize", 3 }, // use 3Mb to make it fails, use a debug ApiClient, objectsApi.apiClient.isDebugMode = true
					{ "minutesExpiration", 60 }, // use 1 to stress error code 403 - Forbidden
					{ "Timeout", Timeout.InfiniteTimeSpan } // TimeSpan.FromSeconds (100) }
				},
				onUploadProgress
			);
			Console.WriteLine ("**** Upload file(s) response(s):");
			foreach ( var resp in uploadRes )
				Console.WriteLine ("{0} {1}{2}", resp.objectKey, resp.Error ? "Error: " : "", resp.completed.ToString ());
			Console.WriteLine ("**** Verifying SHA1 codes (please wait, the system is reassembling parts)");
			await verifyServerObjectsSha1 (BucketKey, uploadRes);
			_streamOut = File.Open (FILE_NAME2 + ".out", FileMode.Create);
			FileStream _stream3Out = File.Open (FILE_NAME3 + ".out", FileMode.Create);
			downloadRes = await ObjectsAPI.downloadResources (
				BucketKey,
				new List<DownloadItemDesc> () {
					new DownloadItemDesc (FILE_NAME2, "arraybuffer"), // Buffer
					new DownloadItemDesc (FILE_NAME2 + ".bin", "stream"),
					new DownloadItemDesc (FILE_NAME3, "arraybuffer"), // Buffer
					new DownloadItemDesc (FILE_NAME3 + ".bin", "stream"),
				},
				new Dictionary<string, object> () {
					//{ "publicResourceFallback", true }, // Allows fallback to OSS signed URLs in case of unmerged resumable uploads.
					//{ "useCdn", true }, // Will generate a CloudFront URL for the S3 object.
					{ "minutesExpiration", 5 } // use 1 to stress error code 403 - Forbidden
				},
				onDownloadProgress
			);
			Console.WriteLine ("**** Verifying SHA1 codes with downloads");
			compareObjects (uploadRes, downloadRes);
			Console.WriteLine ("**** Deleting server files(s)");
			await deleteAllServerObjects (BucketKey, uploadRes);
			try { File.Delete (FILE_NAME2 + ".out"); } catch { }
			try { File.Delete (FILE_NAME3 + ".out"); } catch { }
		}

		#endregion

		static async Task Main (string [] args) {
			Console.WriteLine ("Hello World!");

			readConfigFromEnvOrSettings ();

			try {
				//Region endpoint = Enum.Parse<Region> (args [0], true);
				Region storage = Enum.Parse<Region> (args [1], true);

				await TryWorkflow (
					storage
				);
			} catch ( Exception ex ) {
#if DEBUG
				Console.WriteLine (ex.Message);
#endif
			}

			Console.WriteLine ("Done");
		}

	}

}
