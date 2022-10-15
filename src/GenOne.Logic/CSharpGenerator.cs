using System.Linq;
using System.Text;

namespace GenOne.Logic;

public class CSharpGenerator : CodeGenerator
{
    public static string GenerateOutput(List<TokenizedLine> lines)
    {
        var toGenerate = DetermineGeneration(lines);

        // TODO: do code generation based on the contents of toGenerate
        var sb = new StringBuilder();

        foreach (var cmnt in toGenerate.CommentLines)
        {
            sb.AppendLine($"// {cmnt}");
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

            foreach (var prop in type.Properties.Where(p => p.IsRequired))
            {
                // TODO: add constructor


                ////foreach (var arg in meth.Args)
                ////{
                ////    sb.AppendLine($"        {arg.Name} = {arg.Name};");
                ////}

                ////sb.AppendLine("}}"); ;
            }

            foreach (var prop in type.Properties)
            {
                if (prop.IsRequired)
                {
                    sb.AppendLine($"    public {prop.DataType} {prop.Name} {{ get; init; }}");
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

                sb.AppendLine(") {{ }}");

            }

            sb.AppendLine("}");
        }

        return sb.ToString();
    }
}
