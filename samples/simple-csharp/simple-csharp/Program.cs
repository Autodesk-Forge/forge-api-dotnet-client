//
// Copyright (c) 2017 Autodesk, Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

using Autodesk.Forge;
using Autodesk.Forge.Model;
using Autodesk.Forge.Client;

namespace forge.simple_csharp {

	class Program {

		// Initialize the oAuth 2.0 client configuration fron enviroment variables
		// you can also hardcode them in the code if you want in the placeholders below
		private static string FORGE_CLIENT_ID =Environment.GetEnvironmentVariable ("FORGE_CLIENT_ID")?? "your_client_id" ;
        private static string FORGE_CLIENT_SECRET =Environment.GetEnvironmentVariable ("FORGE_CLIENT_SECRET")?? "your_client_secret" ;
		private static string BUCKET_KEY ="forge-csharp-sample-app-" + FORGE_CLIENT_ID.ToLower () ;
		private static string FILE_NAME ="my-elephant.obj" ;
		private static string FILE_PATH ="elephant.obj" ;

		// Initialize the relevant clients; in this example, the Objects, Buckets and Derivatives clients, which are part of the Data Management API and Model Derivatives API
		private static BucketsApi bucketsApi =new BucketsApi () ;
		private static ObjectsApi objectsApi =new ObjectsApi () ;
		private static DerivativesApi derivativesApi =new DerivativesApi () ;

		private static TwoLeggedApi oauth2TwoLegged ;
		private static dynamic twoLeggedCredentials ;

		// Initialize the 2-legged OAuth 2.0 client, and optionally set specific scopes.
		private static void initializeOAuth () {
			// You must provide at least one valid scope
			Scope[] scopes =new Scope[] { Scope.DataRead, Scope.DataWrite, Scope.BucketCreate, Scope.BucketRead } ;

			oauth2TwoLegged =new TwoLeggedApi () ;
			twoLeggedCredentials =oauth2TwoLegged.Authenticate (FORGE_CLIENT_ID, FORGE_CLIENT_SECRET, oAuthConstants.CLIENT_CREDENTIALS, scopes) ;
			bucketsApi.Configuration.AccessToken =twoLeggedCredentials.access_token ;
			objectsApi.Configuration.AccessToken =twoLeggedCredentials.access_token ;
			derivativesApi.Configuration.AccessToken =twoLeggedCredentials.access_token ;
		}

		// Example of how to create a new bucket using Forge SDK.
		// Uses the oauth2TwoLegged and twoLeggedCredentials objects that you retrieved previously.
		private static void createBucket () {
			Console.WriteLine ("***** Sending createBucket request") ;
			PostBucketsPayload payload =new PostBucketsPayload (BUCKET_KEY, null, PostBucketsPayload.PolicyKeyEnum.Persistent) ;
			dynamic response =bucketsApi.CreateBucket (payload, "US") ;
			Console.WriteLine ("***** Response for createBucket: " + response.ToString ()) ;
		}

		// Example of how to upload a file to the bucket.
		// Uses the oauth2TwoLegged and twoLeggedCredentials objects that you retrieved previously.
		private static dynamic uploadFile () {
			Console.WriteLine ("***** Sending uploadFile request") ;
			string path =FILE_PATH ;
			if ( !File.Exists (path) )
				path =@"..\..\..\" + FILE_PATH ;
			using ( StreamReader streamReader =new StreamReader (path) ) {
				dynamic response =objectsApi.UploadObject (BUCKET_KEY,
					FILE_NAME, (int)streamReader.BaseStream.Length, streamReader.BaseStream,
					"application/octet-stream") ;
				Console.WriteLine ("***** Response for uploadFile: ") ;
				Console.WriteLine ("Uploaded object Details - Location: " + response.location
					+ ", Size: " + response.size) ;
				return (response) ;
			}
		}

		// Example of how to send a translate to SVF job request.
		// Uses the oauth2TwoLegged and twoLeggedCredentials objects that you retrieved previously.
		// @param urn - the urn of the file to translate
		private static dynamic translateToSVF (string urn) {
			Console.WriteLine ("***** Sending Derivative API translate request") ;
			JobPayloadInput jobInput =new JobPayloadInput (
				System.Convert.ToBase64String (System.Text.Encoding.UTF8.GetBytes (urn))
			) ;
			JobPayloadOutput jobOutput =new JobPayloadOutput (
				new List<JobPayloadItem> (
					new JobPayloadItem [] {
						new JobPayloadItem (
							JobPayloadItem.TypeEnum.Svf,
							new List<JobPayloadItem.ViewsEnum> (
								new JobPayloadItem.ViewsEnum [] { JobPayloadItem.ViewsEnum._3d }
							),
							null
						)}
				)
			) ;
			JobPayload job =new JobPayload (jobInput, jobOutput) ;
			dynamic response =derivativesApi.Translate (job, true) ;
			Console.WriteLine ("***** Response for Translating File to SVF: " + response.ToString ()) ;
			return (response) ;
		}

		// Example of how to query the status of a translate job.
		// Uses the oauth2TwoLegged and twoLeggedCredentials objects that you retrieved previously.
		// @param base64Urn - the urn of the file to translate in base 64 format
		private static dynamic verifyJobComplete (string base64Urn) {
			Console.WriteLine ("***** Sending getManifest request") ;
			while ( true ) {
				dynamic response =derivativesApi.GetManifest (base64Urn) ;
				if ( hasOwnProperty (response, "progress") && response.progress == "complete" ) {
					Console.WriteLine ("***** Finished translating your file to SVF - status: " + response.status
						+ ", progress: " + response.progress) ;
					return (response) ;
				} else {
					Console.WriteLine ("***** Haven't finished translating your file to SVF - status: " + response.status
						+ ", progress: " + response.progress) ;
					Thread.Sleep (1000) ;
				}
			}
			//return (null) ;
		}

		public static bool hasOwnProperty (dynamic obj, string name) {
			try {
				var test =obj [name] ;
				return (true) ;
			} catch ( Exception ) {
				return (false) ;
			}
		}

		// Open translated SVF file in the viewer
		// Uses the twoLeggedCredentials object that you retrieved previously.
		// Opens the file statically from your hard drive with url parameters for the accessToken and for the urn of the file to show.
		// @param base64Urn
		private static void openViewer (string base64Urn) {
			Console.WriteLine("***** Opening SVF file in viewer with urn:" + base64Urn) ;
			string st =_html.Replace ("__URN__", base64Urn).Replace ("__ACCESS_TOKEN__", twoLeggedCredentials.access_token) ;
			System.IO.File.WriteAllText ("viewer.html", st) ;
			System.Diagnostics.Process.Start (new System.Diagnostics.ProcessStartInfo ("viewer.html")) ;
		}

		// Example of how to delete a file that was uploaded by the application.
		// Uses the oauth2TwoLegged and twoLeggedCredentials objects that you retrieved previously.
		private static void deleteFile () {
	        Console.WriteLine ("***** Sending deleteFile request") ;
			ApiResponse<object> response =objectsApi.DeleteObjectWithHttpInfo (BUCKET_KEY, FILE_NAME) ;
			Console.WriteLine ("***** Response Code for deleting File: " + response.StatusCode) ;
		}

		static void Main (string [] args) {
			try {
				initializeOAuth () ;

				try {
					createBucket () ;
				} catch ( Exception ex ) {
					Console.WriteLine ("Error creating bucket : " + ex.Message) ;
				}

				try {
					dynamic uploadedObject =uploadFile () ;

					try {
						dynamic job =translateToSVF (uploadedObject.objectId) ;

						if ( job.result == "success" || job.result == "created" ) {
							string base64Urn =job.urn ;

							dynamic manifest =verifyJobComplete (base64Urn) ;
							if ( manifest.status == "success" )
								openViewer (manifest.urn) ;
						}
					} catch ( Exception ex ) {
						Console.WriteLine ("Error translating file : " + ex.Message) ;
					}
				} catch ( Exception ex ) {
					Console.WriteLine ("Error uploading file : " + ex.Message) ;
				}
			} catch ( Exception ex ) {
				Console.WriteLine ("Error Initializing OAuth client : " + ex.Message) ;
			}
		}

		#region Html
		private static readonly string _html =@"<!DOCTYPE html>
<html>
<head>
	<meta charset=""UTF-8"">
	<script src=""https://developer.api.autodesk.com/viewingservice/v1/viewers/three.min.css""></script>
	<link rel=""stylesheet"" href=""https://developer.api.autodesk.com/viewingservice/v1/viewers/style.min.css"" />
	<script src=""https://developer.api.autodesk.com/viewingservice/v1/viewers/viewer3D.min.js""></script>
</head>
<body onload=""initialize()"">
<div id=""viewer"" style=""position:absolute; width:90%; height:90%;""></div>
<script>
	function authMe () { return ('__ACCESS_TOKEN__') ; }

	function initialize () {
		var options ={
			'document' : ""urn:__URN__"",
			'env': 'AutodeskProduction',
			'getAccessToken': authMe
		} ;
		var viewerElement =document.getElementById ('viewer') ;
		//var viewer =new Autodesk.Viewing.Viewer3D (viewerElement, {}) ; / No toolbar
		var viewer =new Autodesk.Viewing.Private.GuiViewer3D (viewerElement, {}) ; // With toolbar
		Autodesk.Viewing.Initializer (options, function () {
			viewer.initialize () ;
			loadDocument (viewer, options.document) ;
		}) ;
	}
	function loadDocument (viewer, documentId) {
		// Find the first 3d geometry and load that.
		Autodesk.Viewing.Document.load (
			documentId,
			function (doc) { // onLoadCallback
				var geometryItems =[] ;
				geometryItems =Autodesk.Viewing.Document.getSubItemsWithProperties (
					doc.getRootItem (),
					{ 'type' : 'geometry', 'role' : '3d' },
					true
				) ;
				if ( geometryItems.length <= 0 ) {
					geometryItems =Autodesk.Viewing.Document.getSubItemsWithProperties (
						doc.getRootItem (),
						{ 'type': 'geometry', 'role': '2d' },
						true
					) ;
				}
				if ( geometryItems.length > 0 )
					viewer.load (
						doc.getViewablePath (geometryItems [0])//,
						//null, null, null,
						//doc.acmSessionId /*session for DM*/
					) ;
			},
			function (errorMsg) { // onErrorCallback
				alert(""Load Error: "" + errorMsg) ;
			}//,
			//{
            //	'oauth2AccessToken': authMee (),
            //	'x-ads-acm-namespace': 'WIPDM',
            //	'x-ads-acm-check-groups': 'true',
        	//}
		) ;
	}
</script>
</body>
</html>" ;

		#endregion

	}

}
