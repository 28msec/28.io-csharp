@set SCRIPT=%0
@set DIR=%~dp0
@set DIR=%DIR:~0,-1%
@set JAVA_OPTS=

@FOR /F "delims=" %%i IN ('cd') DO @set INITDIR=%%i
@FOR /F "delims=" %%i IN ('scala bin/Version.scala') DO @set SCALA_RUNNER_VERSION=%%i

@cd %DIR%\..
@FOR /F "delims=" %%i IN ('cd') DO @set APP_DIR=%%i

@IF EXIST target\scala-%SCALA_RUNNER_VERSION%\swagger-codegen.jar (
  set JAVA_OPTS=-XX:MaxPermSize=512M -Xmx1024M -mx512m -DloggerPath=conf\log4j.properties
  set AGS=%DIR%\CSharpCodegen_project.scala %DIR%\data\project
  scala -cp target\scala-%SCALA_RUNNER_VERSION%\swagger-codegen.jar %AGS%
  doxygen %DIR%\Doxyfile
) ELSE (
  echo File not found: %APP_DIR%\target\scala-%SCALA_RUNNER_VERSION%\swagger-codegen.jar
  echo Please set scalaVersion := "%SCALA_RUNNER_VERSION%" in build.sbt and run ./sbt assembly
)
@cd %INITDIR%