using System.Linq;
using System.Text;

namespace GenOne.Logic;

public class CSharpGenerator : CodeGenerator
{
    public static string GenerateOutput(List<TokenizedLine> lines)
    {
        var toGenerate = DetermineGeneration(lines);

        var sb = new StringBuilder();

        foreach (var cmnt in toGenerate.CommentLines)
        {
            if (!string.IsNullOrWhiteSpace(cmnt))
            {
                sb.AppendLine($"// {cmnt}");
            }
        }

        foreach (var enm in toGenerate.Enums)
        {
            sb.AppendLine($"enum {enm.Name}");
            sb.AppendLine("{");

            foreach (var ev in enm.Values)
            {
                sb.AppendLine($"    {ev},");
            }

            sb.AppendLine("}");
        }

        foreach (var type in toGenerate.Types)
        {
            if (!string.IsNullOrWhiteSpace(type.BaseClass))
            {
                sb.AppendLine($"partial class {type.Name} : {type.BaseClass}");
            }
            else
            {
                sb.AppendLine($"partial class {type.Name}");
            }

            sb.AppendLine("{");

            var requiredProps = type.Properties.Where(p => p.IsRequired).ToList();

            if (requiredProps.Any())
            {
                sb.Append($"    public {type.Name}(");

                var added = false;

                foreach (var reqProp in requiredProps)
                {
                    if (added)
                    {
                        sb.Append(", ");
                    }

                    sb.Append($"{reqProp.DataType} {reqProp.Name}");

                    added = true;
                }

                sb.AppendLine(") {");

                foreach (var reqProp in requiredProps)
                {
                    sb.AppendLine($"        {reqProp.Name} = {reqProp.Name};");
                }

                sb.AppendLine("    }");
            }

            foreach (var prop in type.Properties)
            {
                if (prop.IsRequired)
                {
                    sb.AppendLine($"    public {prop.DataType} {prop.Name} {{ get; }}");
                }
                else
                {
                    sb.AppendLine($"    public {prop.DataType} {prop.Name} {{ get; set; }}");
                }
            }

            foreach (var meth in type.Methods)
            {
                sb.Append($"    public partial void {meth.Name}(");

                var hasArgs = false;

                foreach (var arg in meth.Args)
                {
                    if (hasArgs)
                    {
                        sb.Append(", ");
                    }

                    hasArgs = true;

                    sb.Append($"{arg.Datatype} {arg.Name}");
                }

                sb.AppendLine(") { }");
            }

            sb.AppendLine("}");
        }

        return sb.ToString();
    }
}
