28.io C# language binding
--------------------------------

This git repository helps you easily integrate 28.io into your .NET apps.

You can take the platform for a quick <a href="http://portal.28.io/trynow/start">test drive</a> that 
contains a couple of query examples. 

To learn JSONiq, we recommend you to checkout the <a href="http://jsoniq.org/">JSONiq</a> website. 

Fast bootstrap
----------------------------

- add references to the dlls _28.io.Project.dll and NewtonSoft.Json.dll from the folder output/csharp/bin
- create a token using the authentication api
```
var apiPortal = new _28.io.Project.Api.ApiApi();
dynamic login = Newtonsoft.Json.JsonConvert.DeserializeObject(apiPortal.authenticateAsString("client_credentials", HttpUtility.UrlEncode(_EMAIL), HttpUtility.UrlEncode(_PASSWORD), ""));
string token = login.project_tokens["project_" + _PROJECT];
```
- use the token to execute queries from your 28.io project
```
var apiQueries = new _28.io.Project.Api._queriesApi();
apiQueries.setBasePath("http://" + _PROJECT + ".28.io/v1");
var results = apiQueries.executeQuerySequentialAsString("public/query.jq?parameter1=value1", "", token);
```
- for complete reference consult output/csharp/html/index.html

Improving the code
----------------------------

In order to allow better customization of the generated code, the 28.io language bindings are based on 
swagger documentation engine and swagger-codegen (https://github.com/wordnik/swagger-codegen).

###Install prerequisites###

Install swagger-codegen prerequisites: git, scala 2.9.1, maven
```
sudo apt-get install git scala=2.9.1.dfsg-3 maven
```

###Clone and build swagger-codegen###

Install swagger-codegen, then build the sources.
```
git clone https://github.com/wordnik/swagger-codegen.git
cd swagger-codegen
./sbt assembly
```

###Install doxygen###

Install doxygen to recreate the api documentation:
```
sudo apt-get install doxygen
```

###Clone 28.io C# language binding###

Clone this project in a subdirectory called _28.io of swagger-codegen.
```
git clone https://github.com/28msec/28.io-csharp.git _28.io
```

###Build 28.io C# language binding###

Execute the build script. The new code (model, apis and invoker) and the documentation in html format are generated in _28.io/output/csharp.
```
./_28.io/csharp_project.sh
```

More Information
----------------------------

Learn more on 28.io at http://28.io or read the 28.io documentation at http://28.io/documentation.

Familiarize with JSONiq at http://jsoniq.org/.
