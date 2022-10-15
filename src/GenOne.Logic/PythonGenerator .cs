using System.Linq;
using System.Text;
using GenOne.Logic;

public class PythonGenerator : CodeGenerator
{
    public static string GenerateOutput(List<TokenizedLine> lines)
    {
        var toGenerate = DetermineGeneration(lines);

        var sb = new StringBuilder();

        if (toGenerate.Enums.Any())
        {
            sb.AppendLine("from enum import Enum, auto");
            sb.AppendLine();

            foreach (var enm in toGenerate.Enums)
            {
                sb.AppendLine($"class {enm.Name}(Enum):");

                foreach (var item in enm.Values)
                {
                    sb.AppendLine($"    {item} = auto()");
                }

                sb.AppendLine();
            }
        }

        // Ensure that base classes exists in the file
        // TODO: also ensure that custom defined types exist in the file
        foreach (var baseClass in toGenerate.Types.Where(t => !string.IsNullOrWhiteSpace(t.BaseClass)))
        {
            if (!toGenerate.Types.Any(t => t.Name == baseClass.BaseClass))
            {
                sb.AppendLine($"class {baseClass.BaseClass}:");
                sb.AppendLine($"    pass");
                sb.AppendLine();
            }
        }

        foreach (var type in toGenerate.Types)
        {
            if (!string.IsNullOrWhiteSpace(type.BaseClass))
            {
                sb.AppendLine($"class {type.Name}({type.BaseClass}):");
            }
            else
            {
                sb.AppendLine($"class {type.Name}:");
            }

            if (type.Properties.Any())
            {
                foreach (var prop in type.Properties)
                {
                    if (prop.DataType.StartsWith("IEnumerable<"))
                    {
                        sb.AppendLine($"    def __init__(self, {prop.Name}):");
                        sb.AppendLine($"        self.{prop.Name} = []");
                    }
                    else
                    {
                        sb.AppendLine($"    def __init__(self, {prop.Name}: {prop.DataType}):");
                        sb.AppendLine($"        self.{prop.Name} = {prop.Name}");
                    }
                }
            }

            foreach (var meth in type.Methods)
            {
                if (meth.Args.Any())
                {
                    // TODO: handle multiple parameters

                    sb.AppendLine($"    def {meth.Name}({meth.Args[0].Name}: {meth.Args[0].Datatype}):");
                    sb.AppendLine($"        pass");
                }
                else
                {
                    sb.AppendLine($"    def {meth.Name}(self):");
                    sb.AppendLine($"        pass");
                }
            }

            if (!type.Properties.Any() && !type.Methods.Any())
            {
                sb.AppendLine($"    pass");
            }

            sb.AppendLine();
        }


        return sb.ToString();
    }
}
