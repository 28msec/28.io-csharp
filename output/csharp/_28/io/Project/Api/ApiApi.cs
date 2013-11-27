using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using _28.io.Project;
using _28.io.Project.Model;
  namespace _28.io.Project.Api {
    public class ApiApi {
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
      /// Creates or refreshes a session
      /// </summary>
      /// This OAuth2 compliant endpoint can be used both to start a new session or to refresh the current session. To start a new session the 'grant_type' parameter must be set to 'client_credentials' and the 'email' and 'password' parameters must be specified. To refresh an already started session the 'grant_type' parameter must be set to 'refresh_token' and the 'refresh_token' parameter must be specified. If a session is successfully started or refreshed a new API and a new refresh tokens are returned.
      /// <param name="grant_type">The grant_type. 'client_credentials' to start a new session, 'refresh_token' to refresh a session</param>
      /// <param name="email">The account email. Mandatory for login requests.</param>
      /// <param name="password">The account password. Mandatory for login requests.</param>
      /// <param name="refresh_token">The session refresh_token obtained the last time this method has been called. Mandatory for refresh requests.</param>
      /// <returns></returns>
      public Authentication authenticate (string grant_type, string email, string password, string refresh_token) {
        // create path and map variables
        var path = "/api/session";

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
      /// Creates or refreshes a session
      /// </summary>
      /// This OAuth2 compliant endpoint can be used both to start a new session or to refresh the current session. To start a new session the 'grant_type' parameter must be set to 'client_credentials' and the 'email' and 'password' parameters must be specified. To refresh an already started session the 'grant_type' parameter must be set to 'refresh_token' and the 'refresh_token' parameter must be specified. If a session is successfully started or refreshed a new API and a new refresh tokens are returned.
      /// <param name="grant_type">The grant_type. 'client_credentials' to start a new session, 'refresh_token' to refresh a session</param>
      /// <param name="email">The account email. Mandatory for login requests.</param>
      /// <param name="password">The account password. Mandatory for login requests.</param>
      /// <param name="refresh_token">The session refresh_token obtained the last time this method has been called. Mandatory for refresh requests.</param>
      /// <returns></returns>
      public string authenticateAsString (string grant_type, string email, string password, string refresh_token) {
        // create path and map variables
        var path = "/api/session";

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
