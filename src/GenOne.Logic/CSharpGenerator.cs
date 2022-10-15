using System.Linq;
using System.Text;

namespace GenOne.Logic;

public static class CSharpGenerator
{
    public static string GenerateOutput(List<TokenizedLine> lines)
    {
        var toGenerate = DetermineGeneration(lines);

        // TODO: do code generation based on the contents of toGenerate
        var sb = new StringBuilder();

        foreach (var type in toGenerate.Types)
        {
            sb.AppendLine($"partial class {type.Name}");
            sb.AppendLine("{");
            sb.AppendLine("}");
        }

        return sb.ToString();
    }

    public static GenerationDetails DetermineGeneration(List<TokenizedLine> lines)
    {
        var gd = new GenerationDetails();

        foreach (var line in lines)
        {
            switch (line.Category)
            {
                case LineCategory.Unknown:
                    gd.CommentLines.Add(line.OriginalText);
                    break;
                case LineCategory.TypeDefinition:
                    // TODO: Get type details from the line and add to output

                    var tName = line.Lexemes.FirstOrDefault(l => l.Category == LexemeCategory.TypeName).Text;

                    if (!gd.Types.Any(t => t.Name == tName))
                    {
                        gd.Types.Add(new TypeToGenerate(tName));
                    }
                    break;
                case LineCategory.TypeInheritence:
                    // TODO: Get inheritence details from the line and add to output
                    break;
                case LineCategory.EnumDefinition:
                    // TODO: Get enum details from the line
                    gd.Enums.Add(new EnumToGenerate("TODO") { });
                    break;
                case LineCategory.PropertyDefinition:
                    // TODO: Get property details from the line and add to output
                    break;
                case LineCategory.MethodDefinition:
                    // TODO: Get method details from the line and add to output
                    break;
                default:
                    break;
            }
        }

        return gd;
    }
}
