
import com.wordnik.swagger.codegen.BasicCSharpGenerator

object CSharpCodegen_project extends BasicCSharpGenerator {
  def main(args: Array[String]) = generateClient(args)

  // where to write generated code
  override def destinationDir = "_28.io/output/csharp"

  // package for api invoker, error files
  override def invokerPackage = Some("_28.io.Project")

  // package for models
  override def modelPackage = Some("_28.io.Project.Model")

  // package for api classes
  override def apiPackage = Some("_28.io.Project.Api")

  // location of templates
  override def templateDir = "_28.io/templates/csharp"

  override def typeMapping = Map(
    "array" -> "List",
    "Array" -> "List",
    "boolean" -> "bool",
    "string" -> "string",
    "int" -> "int",
    "integer" -> "int",
    "float" -> "float",
    "long" -> "long",
    "double" -> "double",
    "object" -> "object",
    "Date" -> "DateTime",
    "date" -> "DateTime",
    "date-time" -> "DateTime")
  
   override def escapeReservedWord(word: String) = {
     var w = word
     w = w.replaceAll("-", "_")
     w = w.replaceAll(" ", "_")
     w = w.replaceAll("\\{", "_")
     w = w.replaceAll("\\}", "_")
     if (reservedWords.contains(w)) "_" + w
     else w
   }

  override def toVarName(name: String): String = {
    escapeReservedWord(name)
  }

  // supporting classes
  override def supportingFiles =
    List(
      ("apiInvoker.mustache", destinationDir + java.io.File.separator + invokerPackage.get.replace(".", java.io.File.separator) + java.io.File.separator, "ApiInvoker.cs"),
      ("apiException.mustache", destinationDir + java.io.File.separator + invokerPackage.get.replace(".", java.io.File.separator) + java.io.File.separator, "ApiException.cs"),
      ("Newtonsoft.Json.dll", destinationDir +  java.io.File.separator + "bin", "Newtonsoft.Json.dll"),
      ("compile.mustache", destinationDir, "compile.bat"))
}
