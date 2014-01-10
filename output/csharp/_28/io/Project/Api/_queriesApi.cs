using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using _28.io.Project;
using _28.io.Project.Model;
  namespace _28.io.Project.Api {
    public class _queriesApi {
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
      /// Lists public and/or private queries
      /// </summary>
      /// <p>This method retrieves a list of queries that belong to a project. To only list public (resp. private) queries set the <code>visibility</code> parameter to <code>public</code> (resp. <code>private</code>). To list both public and private queries, omit the <code>visibility</code> parameter.</p>
      /// <param name="visibility">The query visibility.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public QueryListing listQueries (string visibility, string token) {
        // create path and map variables
        var path = "/_queries/{visibility}".Replace("{" + "visibility" + "}", apiInvoker.escapeString(visibility.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (visibility == null || token == null ) {
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
             return (QueryListing) ApiInvoker.deserialize(response, typeof(QueryListing));
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
      /// Lists public and/or private queries
      /// </summary>
      /// <p>This method retrieves a list of queries that belong to a project. To only list public (resp. private) queries set the <code>visibility</code> parameter to <code>public</code> (resp. <code>private</code>). To list both public and private queries, omit the <code>visibility</code> parameter.</p>
      /// <param name="visibility">The query visibility.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public string listQueriesAsString (string visibility, string token) {
        // create path and map variables
        var path = "/_queries/{visibility}".Replace("{" + "visibility" + "}", apiInvoker.escapeString(visibility.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (visibility == null || token == null ) {
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
      /// Executes a non-side-effecting query
      /// </summary>
      /// <p>This method executes a non-side-effecting query and serialize its results using a chosen serialization method. The following serialization methods are available: <a href="http://jsoniq.org/docs/JSONiqExtensionToXQuery/html-single/#section-json-serialization" target="_blank">JSON-XML-hybrid</a>, <a href="http://jsoniq.org/docs/JSONiqExtensionToXQuery/html-single/#section-json-serialization" target="_blank">JSON</a>, <a href="http://www.w3.org/TR/xslt-xquery-serialization/#xml-output" target="_blank">XML</a>, <a href="http://www.w3.org/TR/xslt-xquery-serialization/#text-output" target="_blank">Text</a>, <a href="http://www.w3.org/TR/xslt-xquery-serialization/#html-output" target="_blank">HTML</a>, and <a href="http://www.w3.org/TR/xslt-xquery-serialization/#xhtml-output" target="_blank">XHTML</a>.</p><p>It is also possible to use the 28.io serialization method. The 28.io serialization produces a JSON object with metadata about the items produced as query result. This serialization method format is unstable and will be documented as soon we are ready to commit to backward compatibility.</p><div class="callout-info"><p>The HTTP response of this method is using streaming. Therefore, if an error occurs after part of the response has already been sent to the client, the response status code will be 200. In this case, the streaming of the HTTP response will stop and the following string will be sent <code>"\n\n\nAn error occurred during the processing of the request.\n"</code> followed by the error description. To always get a well-formed JSON error response, and the expected HTTP error status code, it is possible to issue the same request using POST. Note however that, in this case, the HTTP response will not stream.</p></div><h4>Query Serialization</h4><p>The serialization method can be chosen by means of the <code>Accept</code> header or by specifying the <code>format</code> parameter. In case no serialization method is specified, JSON-XML-hybrid is used.</p><p>Specifically, the serialization method is chosen as follows: <ol><li>if an <code>Accept</code> header is specified and if it contains at least one supported mime-type/charset pair, the serialization method corresponding to the most preferred one (according to the <a href="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.1" target="_blank">"q" modifier</a> first and the order in which the mime-types are specified second) among those supported is chosen;</li><li>otherwise, if a <code>format</code> parameter is specified, the corresponding serialization method is chosen;</li><li>otherwise, JSON-XML-hybrid is used.</li></ol></p><p>If the Accept header is specified and it contains at least one supported mime-type, the preferred supported mime-type is used to choose the serialization method, according to the following mapping: <ul><li><code>application/mixed-json-xml</code>: <a href="http://jsoniq.org/docs/JSONiqExtensionToXQuery/html-single/#section-json-serialization" target="_blank">JSON-XML-hybrid Serialization</a></li><li><code>application/json</code> or any mime-type which ends with <code>+json</code>: <a href="http://jsoniq.org/docs/JSONiqExtensionToXQuery/html-single/#section-json-serialization" target="_blank">JSON Serialization</a></li><li><code>text/xml</code>, <code>application/xml</code> or any mime-type which ends with <code>+xml</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#xml-output" target="_blank">XML Serialization</a></li><li><code>text/html</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#html-output" target="_blank">HTML Serialization</a></li><li><code>application/xhtml+xml</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#xhtml-output" target="_blank">XHTML Serialization</a></li><li><code>application/28io+json</code>: 28.io Serialization (format definition unstable)</li><li><code>*/*</code>: the <code>Accept</code> header is ignored and the format parameter, if specified, is used to choose the serialization method.</li></ul><p class="callout-warning">Any mime-type not matching one of the conditions listed above is not supported by this resource.</p><p>If the format parameter has been specified and is used to choose the serialization method, the following mapping is used: <ul><li><code>.mixed</code>: <a href="http://jsoniq.org/docs/JSONiqExtensionToXQuery/html-single/#section-json-serialization" target="_blank">JSON-XML-hybrid Serialization</a></li><li><code>.json</code>: <a href="http://jsoniq.org/docs/JSONiqExtensionToXQuery/html-single/#section-json-serialization" target="_blank">JSON Serialization</a></li><li><code>.xml</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#xml-output" target="_blank">XML Serialization</a></li><li><code>.text</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#text-output" target="_blank">Text Serialization</a></li><li><code>.html</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#html-output" target="_blank">HTML Serialization</a></li><li><code>.xhtml</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#xhtml-output" target="_blank">XHTML Serialization</a></li><li><code>.28io-json</code>: 28.io Serialization (format definition unstable).</li></ul></p><h4>Response Content-Type and Encoding</h4><p>The content-type of the response is determined as follows:<ol><li>If the serialization method has been chosen depending on one of the mime-types specified in the <code>Accept</code> header, the following criterion are used: <ul><li>if the used mime-type is <code>*/*</code> or <code>application/mixed-json-xml</code> then the response content type depends on the first item of the result. If it is an XML node the response content-type will be <code>application/xml</code>, otherwise <code>application/json</code></li><li>for any other mime-type, the same mime-type is used in the response.</li></ul> In case no charset has been specified for that mime-type in the <code>Accept</code> header, <code>UTF-8</code> is used. Otherwise, the specified charset is used.</li><li>If the serialization method has been chosen due to the format parameter or the query file extension the content-type of the response is chosen as follows: <ul><li>JSON-XML-hybrid serialization: the response content type depends on the first item of the result. If it is an XML node the response content-type will be <code>application/xml;charset=UTF-8</code>, otherwise <code>application/json;charset=UTF-8</code></li><li>JSON serialization: <code>application/json;charset=UTF-8</code></li><li>XML serialization: <code>application/xml;charset=UTF-8</code></li><li>Text serialization: <code>text/plain;charset=UTF-8</code></li><li>HTML serialization: <code>text/html;charset=UTF-8</code></li><li>XHTML serialization: <code>application/xhtml+xml;charset=UTF-8</code></li><li>28.io serialization: <code>application/28io+json;charset=UTF-8</code></li></ul></li></ol></p><p class="callout-warning">If any of the items produced by the query cannot be serialized using the chosen serialization method a <code>500 internal server error</code> will be raised.</p>
      /// <param name="query_path">The query path. It starts with &lt;code&gt;public&lt;/code&gt; or &lt;code&gt;private&lt;/code&gt; and can contain slashes.</param>
      /// <param name="format">The serialization method to use for the results of the executed query. When choosing a serialization method, this parameter has a lower priority than the &lt;code&gt;Accept&lt;/code&gt; header.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public QueryResult28IO executeSimpleQuery (string query_path, string format, string token) {
        // create path and map variables
        var path = "/_queries/{query-path}{format}".Replace("{" + "query-path" + "}", apiInvoker.escapeString(query_path.ToString())).Replace("{" + "format" + "}", apiInvoker.escapeString(format.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (query_path == null || format == null ) {
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
             return (QueryResult28IO) ApiInvoker.deserialize(response, typeof(QueryResult28IO));
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
      /// Executes a non-side-effecting query
      /// </summary>
      /// <p>This method executes a non-side-effecting query and serialize its results using a chosen serialization method. The following serialization methods are available: <a href="http://jsoniq.org/docs/JSONiqExtensionToXQuery/html-single/#section-json-serialization" target="_blank">JSON-XML-hybrid</a>, <a href="http://jsoniq.org/docs/JSONiqExtensionToXQuery/html-single/#section-json-serialization" target="_blank">JSON</a>, <a href="http://www.w3.org/TR/xslt-xquery-serialization/#xml-output" target="_blank">XML</a>, <a href="http://www.w3.org/TR/xslt-xquery-serialization/#text-output" target="_blank">Text</a>, <a href="http://www.w3.org/TR/xslt-xquery-serialization/#html-output" target="_blank">HTML</a>, and <a href="http://www.w3.org/TR/xslt-xquery-serialization/#xhtml-output" target="_blank">XHTML</a>.</p><p>It is also possible to use the 28.io serialization method. The 28.io serialization produces a JSON object with metadata about the items produced as query result. This serialization method format is unstable and will be documented as soon we are ready to commit to backward compatibility.</p><div class="callout-info"><p>The HTTP response of this method is using streaming. Therefore, if an error occurs after part of the response has already been sent to the client, the response status code will be 200. In this case, the streaming of the HTTP response will stop and the following string will be sent <code>"\n\n\nAn error occurred during the processing of the request.\n"</code> followed by the error description. To always get a well-formed JSON error response, and the expected HTTP error status code, it is possible to issue the same request using POST. Note however that, in this case, the HTTP response will not stream.</p></div><h4>Query Serialization</h4><p>The serialization method can be chosen by means of the <code>Accept</code> header or by specifying the <code>format</code> parameter. In case no serialization method is specified, JSON-XML-hybrid is used.</p><p>Specifically, the serialization method is chosen as follows: <ol><li>if an <code>Accept</code> header is specified and if it contains at least one supported mime-type/charset pair, the serialization method corresponding to the most preferred one (according to the <a href="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.1" target="_blank">"q" modifier</a> first and the order in which the mime-types are specified second) among those supported is chosen;</li><li>otherwise, if a <code>format</code> parameter is specified, the corresponding serialization method is chosen;</li><li>otherwise, JSON-XML-hybrid is used.</li></ol></p><p>If the Accept header is specified and it contains at least one supported mime-type, the preferred supported mime-type is used to choose the serialization method, according to the following mapping: <ul><li><code>application/mixed-json-xml</code>: <a href="http://jsoniq.org/docs/JSONiqExtensionToXQuery/html-single/#section-json-serialization" target="_blank">JSON-XML-hybrid Serialization</a></li><li><code>application/json</code> or any mime-type which ends with <code>+json</code>: <a href="http://jsoniq.org/docs/JSONiqExtensionToXQuery/html-single/#section-json-serialization" target="_blank">JSON Serialization</a></li><li><code>text/xml</code>, <code>application/xml</code> or any mime-type which ends with <code>+xml</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#xml-output" target="_blank">XML Serialization</a></li><li><code>text/html</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#html-output" target="_blank">HTML Serialization</a></li><li><code>application/xhtml+xml</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#xhtml-output" target="_blank">XHTML Serialization</a></li><li><code>application/28io+json</code>: 28.io Serialization (format definition unstable)</li><li><code>*/*</code>: the <code>Accept</code> header is ignored and the format parameter, if specified, is used to choose the serialization method.</li></ul><p class="callout-warning">Any mime-type not matching one of the conditions listed above is not supported by this resource.</p><p>If the format parameter has been specified and is used to choose the serialization method, the following mapping is used: <ul><li><code>.mixed</code>: <a href="http://jsoniq.org/docs/JSONiqExtensionToXQuery/html-single/#section-json-serialization" target="_blank">JSON-XML-hybrid Serialization</a></li><li><code>.json</code>: <a href="http://jsoniq.org/docs/JSONiqExtensionToXQuery/html-single/#section-json-serialization" target="_blank">JSON Serialization</a></li><li><code>.xml</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#xml-output" target="_blank">XML Serialization</a></li><li><code>.text</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#text-output" target="_blank">Text Serialization</a></li><li><code>.html</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#html-output" target="_blank">HTML Serialization</a></li><li><code>.xhtml</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#xhtml-output" target="_blank">XHTML Serialization</a></li><li><code>.28io-json</code>: 28.io Serialization (format definition unstable).</li></ul></p><h4>Response Content-Type and Encoding</h4><p>The content-type of the response is determined as follows:<ol><li>If the serialization method has been chosen depending on one of the mime-types specified in the <code>Accept</code> header, the following criterion are used: <ul><li>if the used mime-type is <code>*/*</code> or <code>application/mixed-json-xml</code> then the response content type depends on the first item of the result. If it is an XML node the response content-type will be <code>application/xml</code>, otherwise <code>application/json</code></li><li>for any other mime-type, the same mime-type is used in the response.</li></ul> In case no charset has been specified for that mime-type in the <code>Accept</code> header, <code>UTF-8</code> is used. Otherwise, the specified charset is used.</li><li>If the serialization method has been chosen due to the format parameter or the query file extension the content-type of the response is chosen as follows: <ul><li>JSON-XML-hybrid serialization: the response content type depends on the first item of the result. If it is an XML node the response content-type will be <code>application/xml;charset=UTF-8</code>, otherwise <code>application/json;charset=UTF-8</code></li><li>JSON serialization: <code>application/json;charset=UTF-8</code></li><li>XML serialization: <code>application/xml;charset=UTF-8</code></li><li>Text serialization: <code>text/plain;charset=UTF-8</code></li><li>HTML serialization: <code>text/html;charset=UTF-8</code></li><li>XHTML serialization: <code>application/xhtml+xml;charset=UTF-8</code></li><li>28.io serialization: <code>application/28io+json;charset=UTF-8</code></li></ul></li></ol></p><p class="callout-warning">If any of the items produced by the query cannot be serialized using the chosen serialization method a <code>500 internal server error</code> will be raised.</p>
      /// <param name="query_path">The query path. It starts with &lt;code&gt;public&lt;/code&gt; or &lt;code&gt;private&lt;/code&gt; and can contain slashes.</param>
      /// <param name="format">The serialization method to use for the results of the executed query. When choosing a serialization method, this parameter has a lower priority than the &lt;code&gt;Accept&lt;/code&gt; header.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public string executeSimpleQueryAsString (string query_path, string format, string token) {
        // create path and map variables
        var path = "/_queries/{query-path}{format}".Replace("{" + "query-path" + "}", apiInvoker.escapeString(query_path.ToString())).Replace("{" + "format" + "}", apiInvoker.escapeString(format.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (query_path == null || format == null ) {
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
      /// Executes a query
      /// </summary>
      /// <p>This method executes a query and serialize its results using a chosen serialization method. The following serialization methods are available: <a href="http://jsoniq.org/docs/JSONiqExtensionToXQuery/html-single/#section-json-serialization" target="_blank">JSON-XML-hybrid</a>, <a href="http://jsoniq.org/docs/JSONiqExtensionToXQuery/html-single/#section-json-serialization" target="_blank">JSON</a>, <a href="http://www.w3.org/TR/xslt-xquery-serialization/#xml-output" target="_blank">XML</a>, <a href="http://www.w3.org/TR/xslt-xquery-serialization/#text-output" target="_blank">Text</a>, <a href="http://www.w3.org/TR/xslt-xquery-serialization/#html-output" target="_blank">HTML</a>, and <a href="http://www.w3.org/TR/xslt-xquery-serialization/#xhtml-output" target="_blank">XHTML</a>.</p><p>It is also possible to use the 28.io serialization method. The 28.io serialization produces a JSON object with metadata about the items produced as query result. This serialization method format is unstable and will be documented as soon we are ready to commit to backward compatibility.</p><h4>Query Serialization</h4><p>If the query specifies the response content-type or encoding using the <a href="http://28.io/documentation/latest/modules/http/response?anchor=content-type-1">HTTP response module</a> and the query execution completes without raising errors, its serialization method cannot be overridden through this api. Similarly, if the query <a href="http://28.io/documentation/latest/modules/http/response?anchor=status-code-1">specifies a response status code</a> and the query execution completes without raising errors, the HTTP status code set by the query is systematically used as the response status code.</p><p>If the query does not specify a response content-type, the serialization method can be chosen by means of the <code>Accept</code> header or by specifying the <code>format</code> parameter. In case the query does not specify a response content-type and no serialization method is specified, JSON-XML-hybrid is used.</p><p>Specifically, the serialization method is chosen as follows: <ol><li>if an <code>Accept</code> header is specified and if it contains at least one supported mime-type/charset pair, the serialization method corresponding to the most preferred one (according to the <a href="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.1" target="_blank">"q" modifier</a> first and the order in which the mime-types are specified second) among those supported is chosen;</li><li>otherwise, if a <code>format</code> parameter is specified, the corresponding serialization method is chosen;</li><li>otherwise, JSON-XML-hybrid is used.</li></ol></p><p>If the Accept header is specified and it contains at least one supported mime-type, the preferred supported mime-type is used to choose the serialization method, according to the following mapping: <ul><li><code>application/mixed-json-xml</code>: <a href="http://jsoniq.org/docs/JSONiqExtensionToXQuery/html-single/#section-json-serialization" target="_blank">JSON-XML-hybrid Serialization</a></li><li><code>application/json</code> or any mime-type which ends with <code>+json</code>: <a href="http://jsoniq.org/docs/JSONiqExtensionToXQuery/html-single/#section-json-serialization" target="_blank">JSON Serialization</a></li><li><code>text/xml</code>, <code>application/xml</code> or any mime-type which ends with <code>+xml</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#xml-output" target="_blank">XML Serialization</a></li><li><code>text/html</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#html-output" target="_blank">HTML Serialization</a></li><li><code>application/xhtml+xml</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#xhtml-output" target="_blank">XHTML Serialization</a></li><li><code>application/28io+json</code>: 28.io Serialization (format definition unstable)</li><li><code>*/*</code>: the <code>Accept</code> header is ignored and the format parameter, if specified, is used to choose the serialization method.</li></ul><p class="callout-warning">Any mime-type not matching one of the conditions listed above is not supported by this resource.</p><p>If the format parameter is used to choose the serialization method, the following mapping is used: <ul><li><code>.mixed</code>: <a href="http://jsoniq.org/docs/JSONiqExtensionToXQuery/html-single/#section-json-serialization" target="_blank">JSON-XML-hybrid Serialization</a></li><li><code>.json</code>: <a href="http://jsoniq.org/docs/JSONiqExtensionToXQuery/html-single/#section-json-serialization" target="_blank">JSON Serialization</a></li><li><code>.xml</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#xml-output" target="_blank">XML Serialization</a></li><li><code>.text</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#text-output" target="_blank">Text Serialization</a></li><li><code>.html</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#html-output" target="_blank">HTML Serialization</a></li><li><code>.xhtml</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#xhtml-output" target="_blank">XHTML Serialization</a></li><li><code>.28io-json</code>: 28.io Serialization (format definition unstable).</li></ul></p><h4>Response Content-Type and Encoding</h4><p>The content-type of the response is determined as follows: <ol><li>If the query has set the response content-type, it will be used in the response. If this content-type, however, is not acceptable according to the <code>Accept</code> header specified in the request, an error will be raised and the response status code will be set to <code>406</code>. Note that <code>application/mixed-json-xml</code> is treated as <code>*/*</code> when considering if the content-type set by the query is accepted or not.</li><li>If the serialization method has been chosen depending on one of the mime-types specified in the <code>Accept</code> header, the following criterion are used: <ul><li>if the used mime-type is <code>*/*</code> or <code>application/mixed-json-xml</code> then the response content type depends on the first item of the result. If it is an XML node the response content-type will be <code>application/xml</code>, otherwise <code>application/json</code></li><li>for any other mime-type, the same mime-type is used in the response.</li></ul> In case no charset has been set by the query or specified for that mime-type in the <code>Accept</code> header, <code>UTF-8</code> is used.</li><li>If the serialization method has been chosen due to the format parameter or the query file extension the content-type of the response is chosen as follows: <ul><li>JSON-XML-hybrid serialization: the response content type depends on the first item of the result. If it is an XML node the response content-type will be <code>application/xml;charset=UTF-8</code>, otherwise <code>application/json;charset=UTF-8</code></li><li>JSON serialization: <code>application/json;charset=UTF-8</code></li><li>XML serialization: <code>application/xml;charset=UTF-8</code></li><li>Text serialization: <code>text/plain;charset=UTF-8</code></li><li>HTML serialization: <code>text/html;charset=UTF-8</code></li><li>XHTML serialization: <code>application/xhtml+xml;charset=UTF-8</code></li><li>28.io serialization: <code>application/28io+json;charset=UTF-8</code></li></ul></li></ol></p><p class="callout-warning">If the items produced by the query cannot be serialized using the chosen serialization method a <code>500 internal server error</code> will be raised.</p>
      /// <param name="query_path">The query path. It starts with &lt;code&gt;public&lt;/code&gt; or &lt;code&gt;private&lt;/code&gt; and can contain slashes.</param>
      /// <param name="format">The serialization method to use for the results of the executed query. When choosing a serialization method, this parameter has a lower priority than the &lt;code&gt;Accept&lt;/code&gt; header.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public QueryResult28IO executeQuery (string query_path, string format, string token) {
        // create path and map variables
        var path = "/_queries/{query-path}{format}".Replace("{" + "query-path" + "}", apiInvoker.escapeString(query_path.ToString())).Replace("{" + "format" + "}", apiInvoker.escapeString(format.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (query_path == null || format == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
        if (token != null){
          paramStr = (token != null && token is DateTime) ? ((DateTime)(object)token).ToString("u") : Convert.ToString(token);
          queryParams.Add("token", paramStr);
		}
        try {
          var response = apiInvoker.invokeAPI(basePath, path, "POST", queryParams, null, headerParams);
          if(response != null){
             return (QueryResult28IO) ApiInvoker.deserialize(response, typeof(QueryResult28IO));
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
      /// Executes a query
      /// </summary>
      /// <p>This method executes a query and serialize its results using a chosen serialization method. The following serialization methods are available: <a href="http://jsoniq.org/docs/JSONiqExtensionToXQuery/html-single/#section-json-serialization" target="_blank">JSON-XML-hybrid</a>, <a href="http://jsoniq.org/docs/JSONiqExtensionToXQuery/html-single/#section-json-serialization" target="_blank">JSON</a>, <a href="http://www.w3.org/TR/xslt-xquery-serialization/#xml-output" target="_blank">XML</a>, <a href="http://www.w3.org/TR/xslt-xquery-serialization/#text-output" target="_blank">Text</a>, <a href="http://www.w3.org/TR/xslt-xquery-serialization/#html-output" target="_blank">HTML</a>, and <a href="http://www.w3.org/TR/xslt-xquery-serialization/#xhtml-output" target="_blank">XHTML</a>.</p><p>It is also possible to use the 28.io serialization method. The 28.io serialization produces a JSON object with metadata about the items produced as query result. This serialization method format is unstable and will be documented as soon we are ready to commit to backward compatibility.</p><h4>Query Serialization</h4><p>If the query specifies the response content-type or encoding using the <a href="http://28.io/documentation/latest/modules/http/response?anchor=content-type-1">HTTP response module</a> and the query execution completes without raising errors, its serialization method cannot be overridden through this api. Similarly, if the query <a href="http://28.io/documentation/latest/modules/http/response?anchor=status-code-1">specifies a response status code</a> and the query execution completes without raising errors, the HTTP status code set by the query is systematically used as the response status code.</p><p>If the query does not specify a response content-type, the serialization method can be chosen by means of the <code>Accept</code> header or by specifying the <code>format</code> parameter. In case the query does not specify a response content-type and no serialization method is specified, JSON-XML-hybrid is used.</p><p>Specifically, the serialization method is chosen as follows: <ol><li>if an <code>Accept</code> header is specified and if it contains at least one supported mime-type/charset pair, the serialization method corresponding to the most preferred one (according to the <a href="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.1" target="_blank">"q" modifier</a> first and the order in which the mime-types are specified second) among those supported is chosen;</li><li>otherwise, if a <code>format</code> parameter is specified, the corresponding serialization method is chosen;</li><li>otherwise, JSON-XML-hybrid is used.</li></ol></p><p>If the Accept header is specified and it contains at least one supported mime-type, the preferred supported mime-type is used to choose the serialization method, according to the following mapping: <ul><li><code>application/mixed-json-xml</code>: <a href="http://jsoniq.org/docs/JSONiqExtensionToXQuery/html-single/#section-json-serialization" target="_blank">JSON-XML-hybrid Serialization</a></li><li><code>application/json</code> or any mime-type which ends with <code>+json</code>: <a href="http://jsoniq.org/docs/JSONiqExtensionToXQuery/html-single/#section-json-serialization" target="_blank">JSON Serialization</a></li><li><code>text/xml</code>, <code>application/xml</code> or any mime-type which ends with <code>+xml</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#xml-output" target="_blank">XML Serialization</a></li><li><code>text/html</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#html-output" target="_blank">HTML Serialization</a></li><li><code>application/xhtml+xml</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#xhtml-output" target="_blank">XHTML Serialization</a></li><li><code>application/28io+json</code>: 28.io Serialization (format definition unstable)</li><li><code>*/*</code>: the <code>Accept</code> header is ignored and the format parameter, if specified, is used to choose the serialization method.</li></ul><p class="callout-warning">Any mime-type not matching one of the conditions listed above is not supported by this resource.</p><p>If the format parameter is used to choose the serialization method, the following mapping is used: <ul><li><code>.mixed</code>: <a href="http://jsoniq.org/docs/JSONiqExtensionToXQuery/html-single/#section-json-serialization" target="_blank">JSON-XML-hybrid Serialization</a></li><li><code>.json</code>: <a href="http://jsoniq.org/docs/JSONiqExtensionToXQuery/html-single/#section-json-serialization" target="_blank">JSON Serialization</a></li><li><code>.xml</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#xml-output" target="_blank">XML Serialization</a></li><li><code>.text</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#text-output" target="_blank">Text Serialization</a></li><li><code>.html</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#html-output" target="_blank">HTML Serialization</a></li><li><code>.xhtml</code>: <a href="http://www.w3.org/TR/xslt-xquery-serialization/#xhtml-output" target="_blank">XHTML Serialization</a></li><li><code>.28io-json</code>: 28.io Serialization (format definition unstable).</li></ul></p><h4>Response Content-Type and Encoding</h4><p>The content-type of the response is determined as follows: <ol><li>If the query has set the response content-type, it will be used in the response. If this content-type, however, is not acceptable according to the <code>Accept</code> header specified in the request, an error will be raised and the response status code will be set to <code>406</code>. Note that <code>application/mixed-json-xml</code> is treated as <code>*/*</code> when considering if the content-type set by the query is accepted or not.</li><li>If the serialization method has been chosen depending on one of the mime-types specified in the <code>Accept</code> header, the following criterion are used: <ul><li>if the used mime-type is <code>*/*</code> or <code>application/mixed-json-xml</code> then the response content type depends on the first item of the result. If it is an XML node the response content-type will be <code>application/xml</code>, otherwise <code>application/json</code></li><li>for any other mime-type, the same mime-type is used in the response.</li></ul> In case no charset has been set by the query or specified for that mime-type in the <code>Accept</code> header, <code>UTF-8</code> is used.</li><li>If the serialization method has been chosen due to the format parameter or the query file extension the content-type of the response is chosen as follows: <ul><li>JSON-XML-hybrid serialization: the response content type depends on the first item of the result. If it is an XML node the response content-type will be <code>application/xml;charset=UTF-8</code>, otherwise <code>application/json;charset=UTF-8</code></li><li>JSON serialization: <code>application/json;charset=UTF-8</code></li><li>XML serialization: <code>application/xml;charset=UTF-8</code></li><li>Text serialization: <code>text/plain;charset=UTF-8</code></li><li>HTML serialization: <code>text/html;charset=UTF-8</code></li><li>XHTML serialization: <code>application/xhtml+xml;charset=UTF-8</code></li><li>28.io serialization: <code>application/28io+json;charset=UTF-8</code></li></ul></li></ol></p><p class="callout-warning">If the items produced by the query cannot be serialized using the chosen serialization method a <code>500 internal server error</code> will be raised.</p>
      /// <param name="query_path">The query path. It starts with &lt;code&gt;public&lt;/code&gt; or &lt;code&gt;private&lt;/code&gt; and can contain slashes.</param>
      /// <param name="format">The serialization method to use for the results of the executed query. When choosing a serialization method, this parameter has a lower priority than the &lt;code&gt;Accept&lt;/code&gt; header.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public string executeQueryAsString (string query_path, string format, string token) {
        // create path and map variables
        var path = "/_queries/{query-path}{format}".Replace("{" + "query-path" + "}", apiInvoker.escapeString(query_path.ToString())).Replace("{" + "format" + "}", apiInvoker.escapeString(format.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (query_path == null || format == null ) {
           throw new ApiException(400, "missing required params");
        }
        string paramStr = null;
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
      /// Retrieves a query source code
      /// </summary>
      /// <p>This method retrieves the source code of a query. The response content-type is set according to the query language. If the query does not <a href="http://www.w3.org/TR/xquery-30/#id-version-declaration" target="_blank">declare its own dialect</a>, the query file extension is used to infer the language of the query. If the query file extension is <code>.xq</code> the query language is considered to be <code>XQuery</code>, <code>JSONiq</code>, otherwise.
      /// <param name="query_path">The query path. It starts with &quot;public&quot; or &quot;private&quot; and contains slashes.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public string getQuery (string query_path, string token) {
        // create path and map variables
        var path = "/_queries/{query-path}/metadata/source".Replace("{" + "query-path" + "}", apiInvoker.escapeString(query_path.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (query_path == null || token == null ) {
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
             return (string) ApiInvoker.deserialize(response, typeof(string));
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
      /// Retrieves a query source code
      /// </summary>
      /// <p>This method retrieves the source code of a query. The response content-type is set according to the query language. If the query does not <a href="http://www.w3.org/TR/xquery-30/#id-version-declaration" target="_blank">declare its own dialect</a>, the query file extension is used to infer the language of the query. If the query file extension is <code>.xq</code> the query language is considered to be <code>XQuery</code>, <code>JSONiq</code>, otherwise.
      /// <param name="query_path">The query path. It starts with &quot;public&quot; or &quot;private&quot; and contains slashes.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public string getQueryAsString (string query_path, string token) {
        // create path and map variables
        var path = "/_queries/{query-path}/metadata/source".Replace("{" + "query-path" + "}", apiInvoker.escapeString(query_path.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (query_path == null || token == null ) {
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
      /// Creates a new query
      /// </summary>
      /// <p>This method creates a new query resource.</p>
      /// <param name="query_path">The query path. It starts with &quot;public&quot; or &quot;private&quot; and contains slashes.</param>
      /// <param name="token">A project token.</param>
      /// <param name="body">The source code of the query</param>
      /// <returns></returns>
      public Success createQuery (string query_path, string token, string body) {
        // create path and map variables
        var path = "/_queries/{query-path}/metadata/source".Replace("{" + "query-path" + "}", apiInvoker.escapeString(query_path.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (query_path == null || token == null ) {
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
      /// Creates a new query
      /// </summary>
      /// <p>This method creates a new query resource.</p>
      /// <param name="query_path">The query path. It starts with &quot;public&quot; or &quot;private&quot; and contains slashes.</param>
      /// <param name="token">A project token.</param>
      /// <param name="body">The source code of the query</param>
      /// <returns></returns>
      public string createQueryAsString (string query_path, string token, string body) {
        // create path and map variables
        var path = "/_queries/{query-path}/metadata/source".Replace("{" + "query-path" + "}", apiInvoker.escapeString(query_path.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (query_path == null || token == null ) {
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
      /// Creates or updates a query
      /// </summary>
      /// <p>This method updates the source code of an existing query.</p>
      /// <param name="query_path">The query path. It starts with &quot;public&quot; or &quot;private&quot; and contains slashes.</param>
      /// <param name="token">A project token.</param>
      /// <param name="body">The query source code</param>
      /// <returns></returns>
      public Success saveQuery (string query_path, string token, string body) {
        // create path and map variables
        var path = "/_queries/{query-path}/metadata/source".Replace("{" + "query-path" + "}", apiInvoker.escapeString(query_path.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (query_path == null || token == null ) {
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
      /// Creates or updates a query
      /// </summary>
      /// <p>This method updates the source code of an existing query.</p>
      /// <param name="query_path">The query path. It starts with &quot;public&quot; or &quot;private&quot; and contains slashes.</param>
      /// <param name="token">A project token.</param>
      /// <param name="body">The query source code</param>
      /// <returns></returns>
      public string saveQueryAsString (string query_path, string token, string body) {
        // create path and map variables
        var path = "/_queries/{query-path}/metadata/source".Replace("{" + "query-path" + "}", apiInvoker.escapeString(query_path.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (query_path == null || token == null ) {
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
      /// Removes a query
      /// </summary>
      /// <p>This method removes a query.</p>
      /// <param name="query_path">The query path. It starts with &quot;public&quot; or &quot;private&quot; and contains slashes.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public Success removeQuery (string query_path, string token) {
        // create path and map variables
        var path = "/_queries/{query-path}/metadata/source".Replace("{" + "query-path" + "}", apiInvoker.escapeString(query_path.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (query_path == null || token == null ) {
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
      /// Removes a query
      /// </summary>
      /// <p>This method removes a query.</p>
      /// <param name="query_path">The query path. It starts with &quot;public&quot; or &quot;private&quot; and contains slashes.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public string removeQueryAsString (string query_path, string token) {
        // create path and map variables
        var path = "/_queries/{query-path}/metadata/source".Replace("{" + "query-path" + "}", apiInvoker.escapeString(query_path.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (query_path == null || token == null ) {
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
      /// Retrieves a query execution plan
      /// </summary>
      /// <p>This method retrieves the execution plan of a query.</p>
      /// <param name="query_path">The query path. It starts with &quot;public&quot; or &quot;private&quot; and contains slashes.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public IteratorPlan getQueryPlan (string query_path, string token) {
        // create path and map variables
        var path = "/_queries/{query-path}/metadata/plan".Replace("{" + "query-path" + "}", apiInvoker.escapeString(query_path.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (query_path == null || token == null ) {
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
             return (IteratorPlan) ApiInvoker.deserialize(response, typeof(IteratorPlan));
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
      /// Retrieves a query execution plan
      /// </summary>
      /// <p>This method retrieves the execution plan of a query.</p>
      /// <param name="query_path">The query path. It starts with &quot;public&quot; or &quot;private&quot; and contains slashes.</param>
      /// <param name="token">A project token.</param>
      /// <returns></returns>
      public string getQueryPlanAsString (string query_path, string token) {
        // create path and map variables
        var path = "/_queries/{query-path}/metadata/plan".Replace("{" + "query-path" + "}", apiInvoker.escapeString(query_path.ToString()));

        // query params
        var queryParams = new Dictionary<String, String>();
        var headerParams = new Dictionary<String, String>();

        // verify required params are set
        if (query_path == null || token == null ) {
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
      }
    }
