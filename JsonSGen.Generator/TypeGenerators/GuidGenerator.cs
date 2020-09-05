using System.Text;
using JsonSGen.Generator;

namespace JsonSGen.TypeGenerators
{
    public class GuidGenerator : IJsonGenerator
    {
        public string TypeName => "Guid"; 

        public void GenerateFromJson(CodeBuilder codeBuilder, int indentLevel, JsonProperty property)
        {
            codeBuilder.AppendLine(indentLevel, $"json = json.ReadGuid(out Guid property{property.Name}Value);");
        }

        public void GenerateToJson(CodeBuilder codeBuilder, int indentLevel, StringBuilder appendBuilder, JsonProperty property)
        {
            appendBuilder.Append("\\\"");
            codeBuilder.MakeAppend(indentLevel, appendBuilder);
            codeBuilder.AppendLine(indentLevel, $"builder.Append(value.{property.Name});");
            appendBuilder.Append("\\\""); 
        }
    }
}