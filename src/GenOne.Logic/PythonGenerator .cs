using System.Text;
using GenOne.Logic;

public class PythonGenerator : CodeGenerator
{
    public static string GenerateOutput(List<TokenizedLine> lines)
    {
        var toGenerate = DetermineGeneration(lines);

        var sb = new StringBuilder();

        return "Python support is coming soon";
    }
}
