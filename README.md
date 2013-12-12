28.io C# language binding
--------------------------------

This git repository helps you easily integrate 28.io into your .NET apps.

You can take the platform for a quick <a href="http://portal.28.io/trynow/start">test drive</a> that 
contains a couple of query examples. 

To learn JSONiq, we recommend you to checkout the <a href="http://jsoniq.org/">JSONiq</a> website. 

Fast bootstrap
----------------------------

-   add references to the dlls _28.io.Project.dll and NewtonSoft.Json.dll from the folder output/csharp/bin
-   create a token using the authentication api

```
var apiPortal = new _28.io.Project.Api.ApiApi();
dynamic login = Newtonsoft.Json.JsonConvert.DeserializeObject(apiPortal.authenticateAsString("client_credentials", HttpUtility.UrlEncode(_EMAIL), HttpUtility.UrlEncode(_PASSWORD), ""));
string token = login.project_tokens["project_" + _PROJECT];
```

-   use the token to execute queries from your 28.io project

```
var apiQueries = new _28.io.Project.Api._queriesApi();
apiQueries.setBasePath("http://" + _PROJECT + ".28.io/v1");
var results = apiQueries.executeQuerySequentialAsString("public/query.jq?parameter1=value1", "", token);
```

- for complete reference consult output/csharp/html/index.html

Improving the code
----------------------------

In order to allow better customization of the generated code, the 28.io language bindings are based on 
swagger documentation engine and <a href="https://github.com/wordnik/swagger-codegen">swagger-codegen</a>.

###Install prerequisites###

Install swagger-codegen prerequisites: <a href="http://git-scm.com/downloads">git</a>, 
<a href="http://www.scala-lang.org/download/">scala 2.9.1</a>, <a href="http://maven.apache.org/download.cgi">maven</a>.
You also need to install <a href="http://www.stack.nl/~dimitri/doxygen/download.html">doxygen</a> to recreate the api documentation.

Windows users will require also <a href="http://www.scala-sbt.org/release/docs/Getting-Started/Setup.html">sbt</a> and 
to have the installation directories for java, scala, git, doxygen and sbt in the PATH variable.

###Clone and build swagger-codegen###

Install swagger-codegen:

```
git clone https://github.com/wordnik/swagger-codegen.git
cd swagger-codegen
```

Then build swagger-codegen.

For Unix:

```
./sbt assembly
```

or for Windows

```
sbt assembly
```

###Clone 28.io C# language binding###

Clone this project in a subdirectory called _28.io of swagger-codegen.
```
git clone https://github.com/28msec/28.io-csharp.git _28.io
```

###Build 28.io C# language binding###

Execute the build script.

For Unix:

```
./_28.io/csharp_project.sh
```

or for Windows

```
_28.io\csharp_project.bat
```

The new code (model, apis and invoker) and the documentation in html format are generated in _28.io/output/csharp.

More Information
----------------------------

Learn more on 28.io at <a href="http://28.io">28.io</a> or read the 28.io documentation at <a href="http://28.io/documentation">http://28.io/documentation</a>.

Familiarize with JSONiq at <a href="http://jsoniq.org/">http://jsoniq.org/</a>.
