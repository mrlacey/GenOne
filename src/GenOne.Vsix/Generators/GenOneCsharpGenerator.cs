using System.Linq;
using System.Text;
using GenOne.Logic;
using Microsoft.VisualStudio.TextTemplating.VSHost;

namespace GenOne.Generators
{
    // TODO: also add a code snippet for 'ltb'
    // TODO: Also add item template for a .gen1 file
    public class GenOneCsharpGenerator : BaseCodeGeneratorWithSite
    {
        public const string Name = nameof(GenOneCsharpGenerator);

        public const string Description = "Create C# files from GenOne docs";

        public override string GetDefaultExtension() => ".cs";

        protected override byte[] GenerateCode(string inputFileName, string inputFileContent)
        {
            var lines = inputFileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            var tLines = Tokenizer.TokenizeLines(lines.ToList());
            var cLines = Classifier.ClassifyLines(tLines);

            var generated = CSharpGenerator.GenerateOutput(cLines);

            var sb = new StringBuilder();

            sb.AppendLine("/*");
            sb.AppendLine("Original source");
            sb.AppendLine("===============");
            sb.AppendLine($"{inputFileContent}");
            sb.AppendLine("*/");
            sb.AppendLine();
            sb.AppendLine($"namespace {FileNamespace};");
            sb.AppendLine($"{generated}");

            return Encoding.UTF8.GetBytes(sb.ToString());
        }
    }
}
