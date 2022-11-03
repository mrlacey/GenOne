using System.ComponentModel.Composition;
using System.Windows.Media;

using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace GenOne.Classifier;

[Export(typeof(EditorFormatDefinition))]
[ClassificationType(ClassificationTypeNames = GenOneClassificationTypes.GenOnePunctuation)]
[Name(GenOneClassificationTypes.GenOnePunctuation)]
[UserVisible(true)]
internal sealed class GenOnePunctuationFormatDefinition : ClassificationFormatDefinition
{
public GenOnePunctuationFormatDefinition()
{
    this.ForegroundColor = Colors.LightGray;
    this.DisplayName = "GenOne Punctuation";
}
}

