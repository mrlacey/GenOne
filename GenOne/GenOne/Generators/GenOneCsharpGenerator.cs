using Microsoft.VisualStudio.TextTemplating.VSHost;

namespace GenOne.Generators
{
    // TODO: also add a code snippet for 'ltb'
    // TODO: Also add item template for a .gen1 file
    internal class GenOneCsharpGenerator : BaseCodeGeneratorWithSite
    {
        public const string Name = nameof(GenOneCsharpGenerator);

        public const string Description = "Create C# files from GenOne docs";

        public override string GetDefaultExtension() => ".cs";

        protected override byte[] GenerateCode(string inputFileName, string inputFileContent)
        {
            throw new NotImplementedException();
        }
    }
}
