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
                    var thisName = line.Lexemes.FirstOrDefault(l => l.Category == LexemeCategory.TypeName).Text;

                    var baseName = line.Lexemes.FirstOrDefault(l => l.Category == LexemeCategory.BaseName).Text;

                    if (!gd.Types.Any(t => t.Name == thisName))
                    {
                        gd.Types.Add(new TypeToGenerate(thisName) { BaseClass = baseName });
                    }
                    else
                    {
                        foreach (var gdt in gd.Types)
                        {
                            if (gdt.Name == thisName)
                            {
                                gdt.BaseClass = baseName;
                                break;
                            }
                        }
                    }

                    break;
                case LineCategory.EnumDefinition:
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

                    var typeForProperty = line.Lexemes.FirstOrDefault(l => l.Category == LexemeCategory.TypeName).Text;

                    if (!gd.Types.Any(t => t.Name == typeForProperty))
                    {
                        gd.Types.Add(new TypeToGenerate(typeForProperty));
                    }

                    var propName = line.Lexemes.FirstOrDefault(l => l.Category == LexemeCategory.PropertyName).Text;

                    var propType = string.Empty;

                    // TODO: assign datatype in Classifier
                    if (propName.Contains("(") && propName.EndsWith(")"))
                    {
                        propType = propName.Substring(propName.IndexOf('(') + 1, propName.Length - propName.IndexOf('(') - 2);

                        propName = propName.Substring(0, propName.IndexOf('('));
                    }

                    var datatypeLexeme = line.Lexemes.FirstOrDefault(l => l.Category == LexemeCategory.PropertyType);

                    if (datatypeLexeme != null)
                    {
                        propType = datatypeLexeme.Text;
                    }

                    if (line.Lexemes.Any(l => l.Category == LexemeCategory.PluralIndicator))
                    {
                        propType = $"IEnumerable<{propType}>";
                    }

                    var newProp = new PropertyToGenerate(propName);

                    if (!string.IsNullOrEmpty(propType))
                    {
                        newProp.DataType = propType;
                    }

                    gd.Types.Single(t => t.Name == typeForProperty).Properties.Add(newProp);

                    break;
                case LineCategory.MethodDefinition:
                    var typeForMethod = line.Lexemes.FirstOrDefault(l => l.Category == LexemeCategory.TypeName).Text;

                    if (!gd.Types.Any(t => t.Name == typeForMethod))
                    {
                        gd.Types.Add(new TypeToGenerate(typeForMethod));
                    }

                    var methName = line.Lexemes.FirstOrDefault(l => l.Category == LexemeCategory.MethodName).Text;

                    var newMethod = new MethodToGenerate(methName);

                    foreach (var item in line.Lexemes.Where(l => l.Category == LexemeCategory.MethodArgument))
                    {
                        newMethod.Args.Add((item.Text, item.Text));
                    }

                    gd.Types.Single(t => t.Name == typeForMethod).Methods.Add(newMethod);

                    break;
                default:
                    break;
            }
        }

        return gd;
    }

}