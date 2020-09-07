using System.Text;
using JsonSGen.Generator;

namespace JsonSGen.TypeGenerators
{
    public class NullableDateTimeGenerator : IJsonGenerator
    {
        public string TypeName => "DateTime?";

        public void GenerateFromJson(CodeBuilder codeBuilder, int indentLevel, JsonProperty property)
        {
            codeBuilder.AppendLine(indentLevel, $"json = json.ReadNullableDateTime(out DateTime? property{property.CodeName}Value);");
        }

        public void GenerateToJson(CodeBuilder codeBuilder, int indentLevel, StringBuilder appendBuilder, JsonProperty property)
        {
            codeBuilder.MakeAppend(indentLevel, appendBuilder);
            codeBuilder.AppendLine(indentLevel, $"if(value.{property.CodeName} == null)");
            codeBuilder.AppendLine(indentLevel, "{");
            codeBuilder.AppendLine(indentLevel+1, $"builder.Append(\"null\");");
            codeBuilder.AppendLine(indentLevel, "}");
            codeBuilder.AppendLine(indentLevel, $"builder.AppendDate(value.{property.CodeName}.Value);");
        }
    }
}