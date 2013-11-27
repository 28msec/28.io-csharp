using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using _28.io.Project;
using _28.io.Project.Model;
  namespace _28.io.Project.Api {
    public class _datasourcesApi {
      string basePath = "http://portal.28.io/v1";
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
      /// Lists all data sources
      /// </summary>
      /// <p>This method retrieves the data sources that are configured for a project.</p>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public List<Datasource> listDatasources (string token) {
        // create path and map variables
        var path = "/_datasources";

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          var response = apiInvoker.invokeAPI(basePath, path, "GET", queryParams, null, headerParams);
          if(response != null){
             return (List<Datasource>) ApiInvoker.deserialize(response, typeof(List<Datasource>));
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
      /// Lists all data sources
      /// </summary>
      /// <p>This method retrieves the data sources that are configured for a project.</p>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public string listDatasourcesAsString (string token) {
        // create path and map variables
        var path = "/_datasources";

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          return apiInvoker.invokeAPI(basePath, path, "GET", queryParams, null, headerParams);
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
      /// Lists all data sources in a specific category
      /// </summary>
      /// <p>This method retrieves the list of data sources from a specific category configured for the project. If no data source is present in the specified category an empty array is returned.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public List<Datasource> listCategoryDatasources (string category, string token) {
        // create path and map variables
        var path = "/_datasources/{category}".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          var response = apiInvoker.invokeAPI(basePath, path, "GET", queryParams, null, headerParams);
          if(response != null){
             return (List<Datasource>) ApiInvoker.deserialize(response, typeof(List<Datasource>));
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
      /// Lists all data sources in a specific category
      /// </summary>
      /// <p>This method retrieves the list of data sources from a specific category configured for the project. If no data source is present in the specified category an empty array is returned.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public string listCategoryDatasourcesAsString (string category, string token) {
        // create path and map variables
        var path = "/_datasources/{category}".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          return apiInvoker.invokeAPI(basePath, path, "GET", queryParams, null, headerParams);
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
      /// Creates a new data source
      /// </summary>
      /// <p>This method creates a new data source. According to the specified data source category, the connection to the data source will be tested within this method. If the test does not pass the credentials will not be stored and the reponse status code will be set to 422.</p><p class="callout-warning">Currently, the default MongoDB data source cannot be created using this method.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="name">The name of the data source. The data source name can contain any alphabetic letter, numbers, dots, or dashes, and must start with an alphabetic letter.</param>
      /// <param name="token">A project token.</param>
      /// <param name="_default">Whether the new data source will be the default one for its category. The default value is false.</param>
      /// <param name="body">The data sources credentials as JSON.</param>
      /// <returns></returns>
      public Success createDatasource (string category, string name, string token, bool _default, string body) {
        // create path and map variables
        var path = "/_datasources/{category}".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || name == null || token == null || body == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (name != null){
          paramStr = (name != null && name is DateTime) ? ((DateTime)(object)name).ToString("u") : Convert.ToString(name);
          queryParams.Add("name", paramStr);
		}
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        if (_default != null){
          paramStr = (_default != null && _default is DateTime) ? ((DateTime)(object)_default).ToString("u") : Convert.ToString(_default);
          queryParams.Add("_default", paramStr);
		}
        try {
          var response = apiInvoker.invokeAPI(basePath, path, "POST", queryParams, body, headerParams);
          if(response != null){
             return (Success) ApiInvoker.deserialize(response, typeof(Success));
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
      /// Creates a new data source
      /// </summary>
      /// <p>This method creates a new data source. According to the specified data source category, the connection to the data source will be tested within this method. If the test does not pass the credentials will not be stored and the reponse status code will be set to 422.</p><p class="callout-warning">Currently, the default MongoDB data source cannot be created using this method.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="name">The name of the data source. The data source name can contain any alphabetic letter, numbers, dots, or dashes, and must start with an alphabetic letter.</param>
      /// <param name="token">A project token.</param>
      /// <param name="_default">Whether the new data source will be the default one for its category. The default value is false.</param>
      /// <param name="body">The data sources credentials as JSON.</param>
      /// <returns></returns>
      public string createDatasourceAsString (string category, string name, string token, bool _default, string body) {
        // create path and map variables
        var path = "/_datasources/{category}".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || name == null || token == null || body == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (name != null){
          paramStr = (name != null && name is DateTime) ? ((DateTime)(object)name).ToString("u") : Convert.ToString(name);
          queryParams.Add("name", paramStr);
		}
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        if (_default != null){
          paramStr = (_default != null && _default is DateTime) ? ((DateTime)(object)_default).ToString("u") : Convert.ToString(_default);
          queryParams.Add("_default", paramStr);
		}
        try {
          return apiInvoker.invokeAPI(basePath, path, "POST", queryParams, body, headerParams);
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
      /// Retrieves a data source credentials
      /// </summary>
      /// <p>This method retrieves credentials from data source.</p><p class="callout-warning">Currently, the default MongoDB credentials cannot be retrieved using this method.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public object getDatasource (string category, string datasource, string token) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          var response = apiInvoker.invokeAPI(basePath, path, "GET", queryParams, null, headerParams);
          if(response != null){
             return (object) ApiInvoker.deserialize(response, typeof(object));
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
      /// Retrieves a data source credentials
      /// </summary>
      /// <p>This method retrieves credentials from data source.</p><p class="callout-warning">Currently, the default MongoDB credentials cannot be retrieved using this method.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public string getDatasourceAsString (string category, string datasource, string token) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          return apiInvoker.invokeAPI(basePath, path, "GET", queryParams, null, headerParams);
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
      /// Updates a data source
      /// </summary>
      /// <p>This method updates a data source changing its name, whether it is default or not, or its credentials. At least one change, that is, one of the optional parameters, must be specified.</p><p class="callout-warning">Currently, the default MongoDB data source cannot be modified through this method.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="token">A project token.</param>
      /// <param name="name">The new name of the data source. If not specified the data source is not renamed.</param>
      /// <param name="_default">Whether the data source should become (if true) or cease to be (if false) the default one for its category. If not specified the data source does not change its default status.</param>
      /// <param name="body">The new data sources credentials as JSON. If not specified the data sources credentials are not changed</param>
      /// <returns></returns>
      public Success updateDatasource (string category, string datasource, string token, string name, bool _default, string body) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        if (name != null){
          paramStr = (name != null && name is DateTime) ? ((DateTime)(object)name).ToString("u") : Convert.ToString(name);
          queryParams.Add("name", paramStr);
		}
        if (_default != null){
          paramStr = (_default != null && _default is DateTime) ? ((DateTime)(object)_default).ToString("u") : Convert.ToString(_default);
          queryParams.Add("_default", paramStr);
		}
        try {
          var response = apiInvoker.invokeAPI(basePath, path, "PATCH", queryParams, body, headerParams);
          if(response != null){
             return (Success) ApiInvoker.deserialize(response, typeof(Success));
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
      /// Updates a data source
      /// </summary>
      /// <p>This method updates a data source changing its name, whether it is default or not, or its credentials. At least one change, that is, one of the optional parameters, must be specified.</p><p class="callout-warning">Currently, the default MongoDB data source cannot be modified through this method.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="token">A project token.</param>
      /// <param name="name">The new name of the data source. If not specified the data source is not renamed.</param>
      /// <param name="_default">Whether the data source should become (if true) or cease to be (if false) the default one for its category. If not specified the data source does not change its default status.</param>
      /// <param name="body">The new data sources credentials as JSON. If not specified the data sources credentials are not changed</param>
      /// <returns></returns>
      public string updateDatasourceAsString (string category, string datasource, string token, string name, bool _default, string body) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        if (name != null){
          paramStr = (name != null && name is DateTime) ? ((DateTime)(object)name).ToString("u") : Convert.ToString(name);
          queryParams.Add("name", paramStr);
		}
        if (_default != null){
          paramStr = (_default != null && _default is DateTime) ? ((DateTime)(object)_default).ToString("u") : Convert.ToString(_default);
          queryParams.Add("_default", paramStr);
		}
        try {
          return apiInvoker.invokeAPI(basePath, path, "PATCH", queryParams, body, headerParams);
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
      /// Removes a data source
      /// </summary>
      /// <p>This method removes a data source.</p><p class="callout-warning">Currently, the default MongoDB data source cannot be deleted through this method.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public Success removeDatasource (string category, string datasource, string token) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          var response = apiInvoker.invokeAPI(basePath, path, "DELETE", queryParams, null, headerParams);
          if(response != null){
             return (Success) ApiInvoker.deserialize(response, typeof(Success));
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
      /// Removes a data source
      /// </summary>
      /// <p>This method removes a data source.</p><p class="callout-warning">Currently, the default MongoDB data source cannot be deleted through this method.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public string removeDatasourceAsString (string category, string datasource, string token) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          return apiInvoker.invokeAPI(basePath, path, "DELETE", queryParams, null, headerParams);
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
      /// List available collections
      /// </summary>
      /// <p>This method retrieves the list of available collections from a data source.</p><p class="callout-warning">Currently, this method is only available for MongoDB data sources.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public List<Collection> getDatasourceContents (string category, string datasource, string token) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}/contents".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          var response = apiInvoker.invokeAPI(basePath, path, "GET", queryParams, null, headerParams);
          if(response != null){
             return (List<Collection>) ApiInvoker.deserialize(response, typeof(List<Collection>));
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
      /// List available collections
      /// </summary>
      /// <p>This method retrieves the list of available collections from a data source.</p><p class="callout-warning">Currently, this method is only available for MongoDB data sources.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public string getDatasourceContentsAsString (string category, string datasource, string token) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}/contents".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          return apiInvoker.invokeAPI(basePath, path, "GET", queryParams, null, headerParams);
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
      /// Creates collection
      /// </summary>
      /// <p>This method creates a new collection within a data source.</p><p class="callout-warning">Currently, this method is only available for MongoDB data sources.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="name">The name of the new collection.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public Success createCollection (string category, string datasource, string name, string token) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}/contents".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || name == null || token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (name != null){
          paramStr = (name != null && name is DateTime) ? ((DateTime)(object)name).ToString("u") : Convert.ToString(name);
          queryParams.Add("name", paramStr);
		}
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          var response = apiInvoker.invokeAPI(basePath, path, "POST", queryParams, null, headerParams);
          if(response != null){
             return (Success) ApiInvoker.deserialize(response, typeof(Success));
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
      /// Creates collection
      /// </summary>
      /// <p>This method creates a new collection within a data source.</p><p class="callout-warning">Currently, this method is only available for MongoDB data sources.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="name">The name of the new collection.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public string createCollectionAsString (string category, string datasource, string name, string token) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}/contents".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || name == null || token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (name != null){
          paramStr = (name != null && name is DateTime) ? ((DateTime)(object)name).ToString("u") : Convert.ToString(name);
          queryParams.Add("name", paramStr);
		}
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
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
      /// <summary>
      /// Retrieves metadata about a collection
      /// </summary>
      /// <p>This method retrieves the metadata of a collection.</p><p class="callout-warning">Currently, this method is only available for MongoDB data sources.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="collection">The collection name.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public Collection getCollectionMetadata (string category, string datasource, string collection, string token) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}/contents/{collection}".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString())).Replace("{" + "collection" + "}", apiInvoker.escapeString(collection.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || collection == null || token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          var response = apiInvoker.invokeAPI(basePath, path, "GET", queryParams, null, headerParams);
          if(response != null){
             return (Collection) ApiInvoker.deserialize(response, typeof(Collection));
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
      /// Retrieves metadata about a collection
      /// </summary>
      /// <p>This method retrieves the metadata of a collection.</p><p class="callout-warning">Currently, this method is only available for MongoDB data sources.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="collection">The collection name.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public string getCollectionMetadataAsString (string category, string datasource, string collection, string token) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}/contents/{collection}".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString())).Replace("{" + "collection" + "}", apiInvoker.escapeString(collection.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || collection == null || token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          return apiInvoker.invokeAPI(basePath, path, "GET", queryParams, null, headerParams);
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
      /// Removes a collection
      /// </summary>
      /// <p>This method removes a collection from a data source.</p><p class="callout-warning">Currently, this method is only available for MongoDB data sources.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="collection">The collection name.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public Success removeCollection (string category, string datasource, string collection, string token) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}/contents/{collection}".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString())).Replace("{" + "collection" + "}", apiInvoker.escapeString(collection.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || collection == null || token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          var response = apiInvoker.invokeAPI(basePath, path, "DELETE", queryParams, null, headerParams);
          if(response != null){
             return (Success) ApiInvoker.deserialize(response, typeof(Success));
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
      /// Removes a collection
      /// </summary>
      /// <p>This method removes a collection from a data source.</p><p class="callout-warning">Currently, this method is only available for MongoDB data sources.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="collection">The collection name.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public string removeCollectionAsString (string category, string datasource, string collection, string token) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}/contents/{collection}".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString())).Replace("{" + "collection" + "}", apiInvoker.escapeString(collection.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || collection == null || token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          return apiInvoker.invokeAPI(basePath, path, "DELETE", queryParams, null, headerParams);
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
      /// Lists collection items
      /// </summary>
      /// <p>This method retrieves a list of items a the collection.</p><p class="callout-warning">Currently, this method is only available for MongoDB data sources.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="collection">The collection name.</param>
      /// <param name="token">A project token.</param>
      /// <param name="offset">The index of the first item from which to start listing the collection items. Default is 1.</param>
      /// <param name="limit">The number of collection items to list. Default is 10.</param>
      /// <param name="expand">Whether to include the serialized item in the listing. The default value is false.</param>
      /// <returns></returns>
      public CollectionList28IO listCollection (string category, string datasource, string collection, string token, int offset, int limit, bool expand) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}/contents/{collection}/items".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString())).Replace("{" + "collection" + "}", apiInvoker.escapeString(collection.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || collection == null || token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        if (offset != null){
          paramStr = (offset != null && offset is DateTime) ? ((DateTime)(object)offset).ToString("u") : Convert.ToString(offset);
          queryParams.Add("offset", paramStr);
		}
        if (limit != null){
          paramStr = (limit != null && limit is DateTime) ? ((DateTime)(object)limit).ToString("u") : Convert.ToString(limit);
          queryParams.Add("limit", paramStr);
		}
        if (expand != null){
          paramStr = (expand != null && expand is DateTime) ? ((DateTime)(object)expand).ToString("u") : Convert.ToString(expand);
          queryParams.Add("expand", paramStr);
		}
        try {
          var response = apiInvoker.invokeAPI(basePath, path, "GET", queryParams, null, headerParams);
          if(response != null){
             return (CollectionList28IO) ApiInvoker.deserialize(response, typeof(CollectionList28IO));
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
      /// Lists collection items
      /// </summary>
      /// <p>This method retrieves a list of items a the collection.</p><p class="callout-warning">Currently, this method is only available for MongoDB data sources.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="collection">The collection name.</param>
      /// <param name="token">A project token.</param>
      /// <param name="offset">The index of the first item from which to start listing the collection items. Default is 1.</param>
      /// <param name="limit">The number of collection items to list. Default is 10.</param>
      /// <param name="expand">Whether to include the serialized item in the listing. The default value is false.</param>
      /// <returns></returns>
      public string listCollectionAsString (string category, string datasource, string collection, string token, int offset, int limit, bool expand) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}/contents/{collection}/items".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString())).Replace("{" + "collection" + "}", apiInvoker.escapeString(collection.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || collection == null || token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        if (offset != null){
          paramStr = (offset != null && offset is DateTime) ? ((DateTime)(object)offset).ToString("u") : Convert.ToString(offset);
          queryParams.Add("offset", paramStr);
		}
        if (limit != null){
          paramStr = (limit != null && limit is DateTime) ? ((DateTime)(object)limit).ToString("u") : Convert.ToString(limit);
          queryParams.Add("limit", paramStr);
		}
        if (expand != null){
          paramStr = (expand != null && expand is DateTime) ? ((DateTime)(object)expand).ToString("u") : Convert.ToString(expand);
          queryParams.Add("expand", paramStr);
		}
        try {
          return apiInvoker.invokeAPI(basePath, path, "GET", queryParams, null, headerParams);
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
      /// Inserts an item into a collection
      /// </summary>
      /// <p>This method inserts an item into a data source collection.</p><p class="callout-warning">Currently, this method is only available for MongoDB data sources.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="collection">The collection name.</param>
      /// <param name="token">A project token.</param>
      /// <param name="body">The item to insert.</param>
      /// <returns></returns>
      public Success insertInCollection (string category, string datasource, string collection, string token, string body) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}/contents/{collection}/items".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString())).Replace("{" + "collection" + "}", apiInvoker.escapeString(collection.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || collection == null || token == null || body == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          var response = apiInvoker.invokeAPI(basePath, path, "POST", queryParams, body, headerParams);
          if(response != null){
             return (Success) ApiInvoker.deserialize(response, typeof(Success));
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
      /// Inserts an item into a collection
      /// </summary>
      /// <p>This method inserts an item into a data source collection.</p><p class="callout-warning">Currently, this method is only available for MongoDB data sources.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="collection">The collection name.</param>
      /// <param name="token">A project token.</param>
      /// <param name="body">The item to insert.</param>
      /// <returns></returns>
      public string insertInCollectionAsString (string category, string datasource, string collection, string token, string body) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}/contents/{collection}/items".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString())).Replace("{" + "collection" + "}", apiInvoker.escapeString(collection.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || collection == null || token == null || body == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          return apiInvoker.invokeAPI(basePath, path, "POST", queryParams, body, headerParams);
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
      /// Truncates a collection
      /// </summary>
      /// <p>This method truncates a collection.</p><p class="callout-warning">Currently, this method is only available for MongoDB data sources.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="collection">The collection name.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public Success truncateCollection (string category, string datasource, string collection, string token) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}/contents/{collection}/items".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString())).Replace("{" + "collection" + "}", apiInvoker.escapeString(collection.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || collection == null || token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          var response = apiInvoker.invokeAPI(basePath, path, "DELETE", queryParams, null, headerParams);
          if(response != null){
             return (Success) ApiInvoker.deserialize(response, typeof(Success));
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
      /// Truncates a collection
      /// </summary>
      /// <p>This method truncates a collection.</p><p class="callout-warning">Currently, this method is only available for MongoDB data sources.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="collection">The collection name.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public string truncateCollectionAsString (string category, string datasource, string collection, string token) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}/contents/{collection}/items".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString())).Replace("{" + "collection" + "}", apiInvoker.escapeString(collection.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || collection == null || token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          return apiInvoker.invokeAPI(basePath, path, "DELETE", queryParams, null, headerParams);
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
      /// Retrieves a collection item
      /// </summary>
      /// <p>This method retrieves a collection item.</p><p class="callout-warning">Currently, this method is only available for MongoDB data sources.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="collection">The collection name.</param>
      /// <param name="identifier">The item identifier.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public object getItem (string category, string datasource, string collection, string identifier, string token) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}/contents/{collection}/items/{identifier}".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString())).Replace("{" + "collection" + "}", apiInvoker.escapeString(collection.ToString())).Replace("{" + "identifier" + "}", apiInvoker.escapeString(identifier.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || collection == null || identifier == null || token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          var response = apiInvoker.invokeAPI(basePath, path, "GET", queryParams, null, headerParams);
          if(response != null){
             return (object) ApiInvoker.deserialize(response, typeof(object));
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
      /// Retrieves a collection item
      /// </summary>
      /// <p>This method retrieves a collection item.</p><p class="callout-warning">Currently, this method is only available for MongoDB data sources.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="collection">The collection name.</param>
      /// <param name="identifier">The item identifier.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public string getItemAsString (string category, string datasource, string collection, string identifier, string token) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}/contents/{collection}/items/{identifier}".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString())).Replace("{" + "collection" + "}", apiInvoker.escapeString(collection.ToString())).Replace("{" + "identifier" + "}", apiInvoker.escapeString(identifier.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || collection == null || identifier == null || token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          return apiInvoker.invokeAPI(basePath, path, "GET", queryParams, null, headerParams);
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
      /// Updates a collection item
      /// </summary>
      /// <p>This method updates a collection item.</p><p class="callout-warning">Currently, this method is only available for MongoDB data sources.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="collection">The collection name.</param>
      /// <param name="identifier">The item identifier.</param>
      /// <param name="token">A project token.</param>
      /// <param name="body">The new item.</param>
      /// <returns></returns>
      public Success updateItem (string category, string datasource, string collection, string identifier, string token, string body) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}/contents/{collection}/items/{identifier}".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString())).Replace("{" + "collection" + "}", apiInvoker.escapeString(collection.ToString())).Replace("{" + "identifier" + "}", apiInvoker.escapeString(identifier.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || collection == null || identifier == null || token == null || body == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          var response = apiInvoker.invokeAPI(basePath, path, "PUT", queryParams, body, headerParams);
          if(response != null){
             return (Success) ApiInvoker.deserialize(response, typeof(Success));
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
      /// Updates a collection item
      /// </summary>
      /// <p>This method updates a collection item.</p><p class="callout-warning">Currently, this method is only available for MongoDB data sources.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="collection">The collection name.</param>
      /// <param name="identifier">The item identifier.</param>
      /// <param name="token">A project token.</param>
      /// <param name="body">The new item.</param>
      /// <returns></returns>
      public string updateItemAsString (string category, string datasource, string collection, string identifier, string token, string body) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}/contents/{collection}/items/{identifier}".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString())).Replace("{" + "collection" + "}", apiInvoker.escapeString(collection.ToString())).Replace("{" + "identifier" + "}", apiInvoker.escapeString(identifier.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || collection == null || identifier == null || token == null || body == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          return apiInvoker.invokeAPI(basePath, path, "PUT", queryParams, body, headerParams);
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
      /// Removes an item from a collection
      /// </summary>
      /// <p>This method removes an item from a collection</p><p class="callout-warning">Currently, this method is only available for MongoDB data sources.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="collection">The collection name.</param>
      /// <param name="identifier">The item identifier.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public Success removeItem (string category, string datasource, string collection, string identifier, string token) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}/contents/{collection}/items/{identifier}".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString())).Replace("{" + "collection" + "}", apiInvoker.escapeString(collection.ToString())).Replace("{" + "identifier" + "}", apiInvoker.escapeString(identifier.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || collection == null || identifier == null || token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          var response = apiInvoker.invokeAPI(basePath, path, "DELETE", queryParams, null, headerParams);
          if(response != null){
             return (Success) ApiInvoker.deserialize(response, typeof(Success));
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
      /// Removes an item from a collection
      /// </summary>
      /// <p>This method removes an item from a collection</p><p class="callout-warning">Currently, this method is only available for MongoDB data sources.</p>
      /// <param name="category">The data source category.</param>
      /// <param name="datasource">The data source name.</param>
      /// <param name="collection">The collection name.</param>
      /// <param name="identifier">The item identifier.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public string removeItemAsString (string category, string datasource, string collection, string identifier, string token) {
        // create path and map variables
        var path = "/_datasources/{category}/{datasource}/contents/{collection}/items/{identifier}".Replace("{" + "category" + "}", apiInvoker.escapeString(category.ToString())).Replace("{" + "datasource" + "}", apiInvoker.escapeString(datasource.ToString())).Replace("{" + "collection" + "}", apiInvoker.escapeString(collection.ToString())).Replace("{" + "identifier" + "}", apiInvoker.escapeString(identifier.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (category == null || datasource == null || collection == null || identifier == null || token == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          return apiInvoker.invokeAPI(basePath, path, "DELETE", queryParams, null, headerParams);
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
