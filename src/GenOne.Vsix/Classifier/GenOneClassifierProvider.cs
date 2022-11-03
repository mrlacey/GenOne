using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace GenOne.Classifier;

[Export(typeof(IClassifierProvider))]
[ContentType(GenOne.ContentType)]
internal class GenOneClassifierProvider : IClassifierProvider
{
    [Import]
    private IClassificationTypeRegistryService ClassificationRegistry { get; set; }

    public IClassifier GetClassifier(ITextBuffer buffer) =>
        buffer.Properties.GetOrCreateSingletonProperty(() =>
            new GenOneClassifier(this.ClassificationRegistry));
}
