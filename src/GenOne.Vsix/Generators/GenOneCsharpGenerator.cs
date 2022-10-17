﻿using System.Linq;
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

        public const string Description = "Create C# files from .gen1 docs";

        public override string GetDefaultExtension() => ".cs";

        protected override byte[] GenerateCode(string inputFileName, string inputFileContent)
        {
            var lines = inputFileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            var tLines = Tokenizer.TokenizeLines(lines.ToList());
            var cLines = Logic.Classifier.ClassifyLines(tLines);

            var generated = CSharpGenerator.GenerateOutput(cLines);

            var sb = new StringBuilder();

            sb.AppendLine("/// <auto-generated>");
            sb.AppendLine($"/// The file was generated by GenOne (v{Vsix.Version})");
            sb.AppendLine($"/// Learn more at https://github.com/mrlacey/GenOne");
            sb.AppendLine("/// </auto-generated>");
            sb.AppendLine();
            sb.AppendLine($"namespace {FileNamespace};");
            sb.AppendLine();
            sb.AppendLine($"{generated}");

            return Encoding.UTF8.GetBytes(sb.ToString());
        }
    }
}
