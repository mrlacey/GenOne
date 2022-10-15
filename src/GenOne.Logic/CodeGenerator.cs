using System.Linq;

namespace GenOne.Logic;

public class CodeGenerator
{
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
                    var tName = line.Lexemes.FirstOrDefault(l => l.Category == LexemeCategory.TypeName).Text;

                    if (!gd.Types.Any(t => t.Name == tName))
                    {
                        gd.Types.Add(new TypeToGenerate(tName));
                    }
                    break;
                case LineCategory.TypeInheritence:
                    // TODO: Get inheritence details from the line and add to output
                    var thisName = line.Lexemes.FirstOrDefault(l => l.Category == LexemeCategory.TypeName).Text;

                    var baseName = line.Lexemes.FirstOrDefault(l => l.Category == LexemeCategory.BaseName).Text;

                    if (!gd.Types.Any(t => t.Name == thisName))
                    {
                        gd.Types.Add(new TypeToGenerate(thisName) { BaseClass = baseName });
                    }

                    break;
                case LineCategory.EnumDefinition:
                    // TODO: Get enum details from the line

                    var enum2gen = new EnumToGenerate(line.Lexemes.First(l => l.Category == LexemeCategory.EnumName).Text);

                    foreach (var lexeme in line.Lexemes.Where(l => l.Category == LexemeCategory.EnumValue))
                    {
                        // TODO: handle punctuation better
                        enum2gen.Values.Add(lexeme.Text.TrimEnd(','));
                    }

                    gd.Enums.Add(enum2gen);
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