﻿using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Community.VisualStudio.Toolkit;
using GenOne.Generators;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.TextTemplating.VSHost;

namespace GenOne
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration(Vsix.Name, Vsix.Description, Vsix.Version)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuids.GenOneCsGeneratorString)]

    [ProvideCodeGenerator(typeof(GenOneCsharpGenerator), GenOneCsharpGenerator.Name, GenOneCsharpGenerator.Description, true, RegisterCodeBase = true)]
    [ProvideCodeGenerator(typeof(GenOnePythonGenerator), GenOnePythonGenerator.Name, GenOnePythonGenerator.Description, true, RegisterCodeBase = true)]
    [ProvideCodeGeneratorExtension(GenOneCsharpGenerator.Name, ".gen1")]
    [ProvideCodeGeneratorExtension(GenOnePythonGenerator.Name, ".gen1py")]
    [ProvideUIContextRule(PackageGuids.CommandVisisiblityString,
        name: "GenOne files",
        expression: "IsGen1",
        termNames: new[] { "IsGen1" },
        termValues: new[] { "HierSingleSelectionName:.gen1" })]
    public class GenOnePackage : ToolkitPackage
    {
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await this.RegisterCommandsAsync();
        }
    }
}
