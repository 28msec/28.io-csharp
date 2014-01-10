using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using _28.io.Project;
using _28.io.Project.Model;
  namespace _28.io.Project.Api {
    public class AuthApi {
      string basePath = "http://portal.28.io";
      private readonly ApiInvoker apiInvoker = ApiInvoker.GetInstance();

      public ApiInvoker getInvoker() {
        return apiInvoker;
      }
      
      // Sets the endpoint base url for the services being accessed
      public void setBasePath(string basePath) {
        this.basePath = basePath;
      }
      
      // Gets the endpoint base url for the services being accessed
      public String getBasePath() {
        return basePath;
      }

      /// <summary>
      /// Creates or refreshes authorization tokens
      /// </summary>
      /// <p>This <a href="http://oauth.net/2/" target="_blank">OAuth2</a> compliant endpoint can be used both create new authorization tokens or to refresh an existing ones. There are three types of authorization tokens provided by this endpoint.</p><dl class="dl-horizontal"><dt>Access token</dt><dd>The access token is used to authorize requests on your 28.io account. These methods are currently unstable and are not documented yet.</dd><dt>Refresh Token</dt><dd>This token is used to renew the validity of your current authorization tokens.</dd><dt>Project token</dt><dd>This token is used to authorize requests to a 28.io project. For instance, the project token named <code>myproject</code> can be used to authorize any request to the <code>http://myproject.28.io</code> endpoint.</dd></dl><p>Any successful request to this endpoint will return the access, refresh, and project tokens.</p><p>To create new authorization tokens, the <code>grant_type</code> parameter must be set to <code>client_credentials</code> and the <code>email</code>. The <code>password</code> parameters must be specified as well.</p><p>To refresh the validity of your authorized tokens, the <code>grant_type</code> parameter must be set to <code>refresh_token</code> and the <code>refresh_token</code> parameter must be specified. In this scenario, new authorization tokens will be granted.</p><p>The format of the expiration date of a token is <a href="http://www.w3.org/TR/xmlschema-2/#isoformats" target="_blank">ISO 8601 compliant</a>.</p>
      /// <param name="grant_type">Authorization grant type. Use &lt;code&gt;client_credentials&lt;/code&gt; to create a token or &lt;code&gt;refresh_token&lt;/code&gt; to refresh a token</param>
      /// <param name="email">The account email. Mandatory if &lt;code&gt;grant_type=client_credentials&lt;/code&gt;.</param>
      /// <param name="password">The account password. Mandatory if &lt;code&gt;grant_type=client_credentials&lt;/code&gt;.</param>
      /// <param name="refresh_token">The &lt;code&gt;refresh_token&lt;/code&gt; obtained in the last successful request to this endpoint.  Mandatory if &lt;code&gt;grant_type=refresh_token&lt;/code&gt;.</param>
      /// <returns></returns>
      public Authentication authenticate (string grant_type, string email, string password, string refresh_token) {
        // create path and map variables
        var path = "/auth";

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (grant_type == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (grant_type != null){
          paramStr = (grant_type != null && grant_type is DateTime) ? ((DateTime)(object)grant_type).ToString("u") : Convert.ToString(grant_type);
          queryParams.Add("grant_type", paramStr);
		}
        if (email != null){
          paramStr = (email != null && email is DateTime) ? ((DateTime)(object)email).ToString("u") : Convert.ToString(email);
          queryParams.Add("email", paramStr);
		}
        if (password != null){
          paramStr = (password != null && password is DateTime) ? ((DateTime)(object)password).ToString("u") : Convert.ToString(password);
          queryParams.Add("password", paramStr);
		}
        if (refresh_token != null){
          paramStr = (refresh_token != null && refresh_token is DateTime) ? ((DateTime)(object)refresh_token).ToString("u") : Convert.ToString(refresh_token);
          queryParams.Add("refresh_token", paramStr);
		}
        try {
          var response = apiInvoker.invokeAPI(basePath, path, "POST", queryParams, null, headerParams);
          if(response != null){
             return (Authentication) ApiInvoker.deserialize(response, typeof(Authentication));
          }
          else {
            return null;
          }
        } catch (ApiException ex) {
          if(ex.ErrorCode == 404) {
          	return null;
          }
          else {
            throw ex;
          }
        }
      }

      /// <summary>
      /// Creates or refreshes authorization tokens
      /// </summary>
      /// <p>This <a href="http://oauth.net/2/" target="_blank">OAuth2</a> compliant endpoint can be used both create new authorization tokens or to refresh an existing ones. There are three types of authorization tokens provided by this endpoint.</p><dl class="dl-horizontal"><dt>Access token</dt><dd>The access token is used to authorize requests on your 28.io account. These methods are currently unstable and are not documented yet.</dd><dt>Refresh Token</dt><dd>This token is used to renew the validity of your current authorization tokens.</dd><dt>Project token</dt><dd>This token is used to authorize requests to a 28.io project. For instance, the project token named <code>myproject</code> can be used to authorize any request to the <code>http://myproject.28.io</code> endpoint.</dd></dl><p>Any successful request to this endpoint will return the access, refresh, and project tokens.</p><p>To create new authorization tokens, the <code>grant_type</code> parameter must be set to <code>client_credentials</code> and the <code>email</code>. The <code>password</code> parameters must be specified as well.</p><p>To refresh the validity of your authorized tokens, the <code>grant_type</code> parameter must be set to <code>refresh_token</code> and the <code>refresh_token</code> parameter must be specified. In this scenario, new authorization tokens will be granted.</p><p>The format of the expiration date of a token is <a href="http://www.w3.org/TR/xmlschema-2/#isoformats" target="_blank">ISO 8601 compliant</a>.</p>
      /// <param name="grant_type">Authorization grant type. Use &lt;code&gt;client_credentials&lt;/code&gt; to create a token or &lt;code&gt;refresh_token&lt;/code&gt; to refresh a token</param>
      /// <param name="email">The account email. Mandatory if &lt;code&gt;grant_type=client_credentials&lt;/code&gt;.</param>
      /// <param name="password">The account password. Mandatory if &lt;code&gt;grant_type=client_credentials&lt;/code&gt;.</param>
      /// <param name="refresh_token">The &lt;code&gt;refresh_token&lt;/code&gt; obtained in the last successful request to this endpoint.  Mandatory if &lt;code&gt;grant_type=refresh_token&lt;/code&gt;.</param>
      /// <returns></returns>
      public string authenticateAsString (string grant_type, string email, string password, string refresh_token) {
        // create path and map variables
        var path = "/auth";

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (grant_type == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (grant_type != null){
          paramStr = (grant_type != null && grant_type is DateTime) ? ((DateTime)(object)grant_type).ToString("u") : Convert.ToString(grant_type);
          queryParams.Add("grant_type", paramStr);
		}
        if (email != null){
          paramStr = (email != null && email is DateTime) ? ((DateTime)(object)email).ToString("u") : Convert.ToString(email);
          queryParams.Add("email", paramStr);
		}
        if (password != null){
          paramStr = (password != null && password is DateTime) ? ((DateTime)(object)password).ToString("u") : Convert.ToString(password);
          queryParams.Add("password", paramStr);
		}
        if (refresh_token != null){
          paramStr = (refresh_token != null && refresh_token is DateTime) ? ((DateTime)(object)refresh_token).ToString("u") : Convert.ToString(refresh_token);
          queryParams.Add("refresh_token", paramStr);
		}
        try {
          return apiInvoker.invokeAPI(basePath, path, "POST", queryParams, null, headerParams);
        } catch (ApiException ex) {
          if(ex.ErrorCode == 404) {
          	return null;
          }
          else {
            throw ex;
          }
        }
      }
      }
    }
