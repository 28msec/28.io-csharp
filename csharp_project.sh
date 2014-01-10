#!/bin/sh

SCRIPT="$0"
DIR=`dirname "$SCRIPT"`
DIR=`cd "${DIR}"; pwd`
if [ ! -d "${APP_DIR}" ]; then
  APP_DIR=${DIR}/..
  APP_DIR=`cd "${APP_DIR}"; pwd`
fi
cd $APP_DIR

SCALA_RUNNER_VERSION=$(scala bin/Version.scala)

if [ -f target/scala-$SCALA_RUNNER_VERSION/swagger-codegen.jar ]; then
  export JAVA_OPTS="${JAVA_OPTS} -XX:MaxPermSize=256M -Xmx1024M -DloggerPath=conf/log4j.properties"
  ags="${DIR}/CSharpCodegen_project.scala ${DIR}/data/project"
  scala -cp target/scala-$SCALA_RUNNER_VERSION/swagger-codegen.jar $ags || exit 1
  doxygen ${DIR}/Doxyfile
else
  echo "File not found: ${APP_DIR}/target/scala-$SCALA_RUNNER_VERSION/swagger-codegen.jar"
  echo "Please set scalaVersion := \"$SCALA_RUNNER_VERSION\" in build.sbt and run ./sbt assembly"
fi
