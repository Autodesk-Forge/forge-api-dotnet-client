﻿using Autodesk.Forge.Client;
using Autodesk.Forge.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;

namespace Autodesk.Forge.Api
{
    public interface ITwoLeggedApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// POST authenticate
        /// </summary>
        /// <remarks>
        /// Get a two-legged access token by providing your app&#39;s client ID and secret.
        /// </remarks>
        /// <exception cref="Autodesk.Forge.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="clientId">Client ID of the app</param>
        /// <param name="clientSecret">Client secret of the app</param>
        /// <param name="grantType">Must be &#x60;&#x60;client_credentials&#x60;&#x60;</param>
        /// <param name="scope">Space-separated list of required scopes Note: A URL-encoded space is* &#x60;&#x60;%20&#x60;&#x60;. See the* &#x60;Scopes &lt;/en/docs/oauth/v2/overview/scopes&gt;&#x60; *page for more information on when scopes are required.  (optional)</param>
        /// <returns>Bearer</returns>
        /*Bearer*/
        dynamic Authenticate(string clientId, string clientSecret, string grantType, Scope[] scope = null);

        /// <summary>
        /// POST authenticate
        /// </summary>
        /// <remarks>
        /// Get a two-legged access token by providing your app&#39;s client ID and secret.
        /// </remarks>
        /// <exception cref="Autodesk.Forge.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="clientId">Client ID of the app</param>
        /// <param name="clientSecret">Client secret of the app</param>
        /// <param name="grantType">Must be &#x60;&#x60;client_credentials&#x60;&#x60;</param>
        /// <param name="scope">Space-separated list of required scopes Note: A URL-encoded space is* &#x60;&#x60;%20&#x60;&#x60;. See the* &#x60;Scopes &lt;/en/docs/oauth/v2/overview/scopes&gt;&#x60; *page for more information on when scopes are required.  (optional)</param>
        /// <returns>ApiResponse of Bearer</returns>
        ApiResponse</*Bearer*/dynamic> AuthenticateWithHttpInfo(string clientId, string clientSecret, string grantType, Scope[] scope = null);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// POST authenticate
        /// </summary>
        /// <remarks>
        /// Get a two-legged access token by providing your app&#39;s client ID and secret.
        /// </remarks>
        /// <exception cref="Autodesk.Forge.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="clientId">Client ID of the app</param>
        /// <param name="clientSecret">Client secret of the app</param>
        /// <param name="grantType">Must be &#x60;&#x60;client_credentials&#x60;&#x60;</param>
        /// <param name="scope">Space-separated list of required scopes Note: A URL-encoded space is* &#x60;&#x60;%20&#x60;&#x60;. See the* &#x60;Scopes &lt;/en/docs/oauth/v2/overview/scopes&gt;&#x60; *page for more information on when scopes are required.  (optional)</param>
        /// <returns>Task of Bearer</returns>
        System.Threading.Tasks.Task</*Bearer*/dynamic> AuthenticateAsync(string clientId, string clientSecret, string grantType, Scope[] scope = null);

        /// <summary>
        /// POST authenticate
        /// </summary>
        /// <remarks>
        /// Get a two-legged access token by providing your app&#39;s client ID and secret.
        /// </remarks>
        /// <exception cref="Autodesk.Forge.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="clientId">Client ID of the app</param>
        /// <param name="clientSecret">Client secret of the app</param>
        /// <param name="grantType">Must be &#x60;&#x60;client_credentials&#x60;&#x60;</param>
        /// <param name="scope">Space-separated list of required scopes Note: A URL-encoded space is* &#x60;&#x60;%20&#x60;&#x60;. See the* &#x60;Scopes &lt;/en/docs/oauth/v2/overview/scopes&gt;&#x60; *page for more information on when scopes are required.  (optional)</param>
        /// <returns>Task of ApiResponse (Bearer)</returns>
        System.Threading.Tasks.Task<ApiResponse</*Bearer*/dynamic>> AuthenticateAsyncWithHttpInfo(string clientId, string clientSecret, string grantType, Scope[] scope = null);
        #endregion Asynchronous Operations
    }
    public partial class TwoLeggedApiV2 : ITwoLeggedApi
    {
        private Autodesk.Forge.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="TwoLeggedApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TwoLeggedApiV2(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));

            ExceptionFactory = Autodesk.Forge.Client.Configuration.DefaultExceptionFactory;

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TwoLeggedApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public TwoLeggedApiV2(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = Autodesk.Forge.Client.Configuration.DefaultExceptionFactory;

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.Options.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public Autodesk.Forge.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public Dictionary<String, String> DefaultHeader()
        {
            return this.Configuration.DefaultHeader;
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// POST authenticate Get a two-legged access token by providing your app&#39;s client ID and secret.
        /// </summary>
        /// <exception cref="Autodesk.Forge.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="clientId">Client ID of the app</param>
        /// <param name="clientSecret">Client secret of the app</param>
        /// <param name="grantType">Must be &#x60;&#x60;client_credentials&#x60;&#x60;</param>
        /// <param name="scope">Space-separated list of required scopes Note: A URL-encoded space is* &#x60;&#x60;%20&#x60;&#x60;. See the* &#x60;Scopes &lt;/en/docs/oauth/v2/overview/scopes&gt;&#x60; *page for more information on when scopes are required.  (optional)</param>
        /// <returns>Bearer</returns>
        public /*Bearer*/dynamic Authenticate(string clientId, string clientSecret, string grantType, Scope[] scope = null)
        {
            ApiResponse</*Bearer*/dynamic> localVarResponse = AuthenticateWithHttpInfo(clientId, clientSecret, grantType, scope);
            return localVarResponse.Data;
        }

        /// <summary>
        /// POST authenticate Get a two-legged access token by providing your app&#39;s client ID and secret.
        /// </summary>
        /// <exception cref="Autodesk.Forge.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="clientId">Client ID of the app</param>
        /// <param name="clientSecret">Client secret of the app</param>
        /// <param name="grantType">Must be &#x60;&#x60;client_credentials&#x60;&#x60;</param>
        /// <param name="scope">Space-separated list of required scopes Note: A URL-encoded space is* &#x60;&#x60;%20&#x60;&#x60;. See the* &#x60;Scopes &lt;/en/docs/oauth/v2/overview/scopes&gt;&#x60; *page for more information on when scopes are required.  (optional)</param>
        /// <returns>ApiResponse of Bearer</returns>
        public ApiResponse< /*Bearer*/dynamic> AuthenticateWithHttpInfo(string clientId, string clientSecret, string grantType, Scope[] scope = null)
        {
            // verify the required parameter 'clientId' is set
            if (clientId == null)
                throw new ApiException(400, "Missing required parameter 'clientId' when calling TwoLeggedApi->Authenticate");
            // verify the required parameter 'clientSecret' is set
            if (clientSecret == null)
                throw new ApiException(400, "Missing required parameter 'clientSecret' when calling TwoLeggedApi->Authenticate");
            // verify the required parameter 'grantType' is set
            if (grantType == null)
                throw new ApiException(400, "Missing required parameter 'grantType' when calling TwoLeggedApi->Authenticate");

            var localVarPath = "/authentication/v2/token";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/x-www-form-urlencoded"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };

            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);

            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            String localVarAuthorizationHeader = Configuration.ApiClient.SetAuthorizationHeader(client_id: clientId, client_secret: clientSecret);

            if (localVarAuthorizationHeader != null)
                localVarHeaderParams.Add("Authorization", localVarAuthorizationHeader);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (grantType != null) localVarFormParams.Add("grant_type", Configuration.ApiClient.ParameterToString(grantType)); // form parameter
            if (scope != null) localVarFormParams.Add("scope", Configuration.ApiClient.ParameterToString(scope.AsString())); // form parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("Authenticate", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse</*Bearer*/dynamic>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                /*(Bearer)*/ Configuration.ApiClient.Deserialize(localVarResponse, typeof(Bearer)));

        }

        /// <summary>
        /// POST authenticate Get a two-legged access token by providing your app&#39;s client ID and secret.
        /// </summary>
        /// <exception cref="Autodesk.Forge.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="clientId">Client ID of the app</param>
        /// <param name="clientSecret">Client secret of the app</param>
        /// <param name="grantType">Must be &#x60;&#x60;client_credentials&#x60;&#x60;</param>
        /// <param name="scope">Space-separated list of required scopes Note: A URL-encoded space is* &#x60;&#x60;%20&#x60;&#x60;. See the* &#x60;Scopes &lt;/en/docs/oauth/v2/overview/scopes&gt;&#x60; *page for more information on when scopes are required.  (optional)</param>
        /// <returns>Task of Bearer</returns>
        public async System.Threading.Tasks.Task</*Bearer*/dynamic> AuthenticateAsync(string clientId, string clientSecret, string grantType, Scope[] scope = null)
        {
            ApiResponse</*Bearer*/dynamic> localVarResponse = await AuthenticateAsyncWithHttpInfo(clientId, clientSecret, grantType, scope);
            return localVarResponse.Data;

        }



        /// <summary>
        /// POST authenticate Get a two-legged access token by providing your app&#39;s client ID and secret.
        /// </summary>
        /// <exception cref="Autodesk.Forge.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="clientId">Client ID of the app</param>
        /// <param name="clientSecret">Client secret of the app</param>
        /// <param name="grantType">Must be &#x60;&#x60;client_credentials&#x60;&#x60;</param>
        /// <param name="scope">Space-separated list of required scopes Note: A URL-encoded space is* &#x60;&#x60;%20&#x60;&#x60;. See the* &#x60;Scopes &lt;/en/docs/oauth/v2/overview/scopes&gt;&#x60; *page for more information on when scopes are required.  (optional)</param>
        /// <returns>Task of ApiResponse (Bearer)</returns>
        public async System.Threading.Tasks.Task<ApiResponse</*Bearer*/dynamic>> AuthenticateAsyncWithHttpInfo(string clientId, string clientSecret, string grantType, Scope[] scope = null)
        {
            // verify the required parameter 'clientId' is set
            if (clientId == null)
                throw new ApiException(400, "Missing required parameter 'clientId' when calling TwoLeggedApi->Authenticate");
            // verify the required parameter 'clientSecret' is set
            if (clientSecret == null)
                throw new ApiException(400, "Missing required parameter 'clientSecret' when calling TwoLeggedApi->Authenticate");
            // verify the required parameter 'grantType' is set
            if (grantType == null)
                throw new ApiException(400, "Missing required parameter 'grantType' when calling TwoLeggedApi->Authenticate");

            var localVarPath = "/authentication/v2/token";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/x-www-form-urlencoded"
            };

            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);

            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            String localVarAuthorizationHeader = Configuration.ApiClient.SetAuthorizationHeader(client_id: clientId, client_secret: clientSecret);

            if (localVarAuthorizationHeader != null)
                localVarHeaderParams.Add("Authorization", localVarAuthorizationHeader);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (grantType != null) localVarFormParams.Add("grant_type", Configuration.ApiClient.ParameterToString(grantType)); // form parameter
            if (scope != null) localVarFormParams.Add("scope", Configuration.ApiClient.ParameterToString(scope.AsString())); // form parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("Authenticate", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse</*Bearer*/dynamic>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                /*(Bearer)*/ Configuration.ApiClient.Deserialize(localVarResponse, typeof(Bearer)));

        }

        public static string Base64Encode(string text)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(text));
        }

    }
}
