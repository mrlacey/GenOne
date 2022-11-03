using System.ComponentModel.Composition;
using System.Windows.Media;

using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace GenOne.Classifier;

[Export(typeof(EditorFormatDefinition))]
[ClassificationType(ClassificationTypeNames = GenOneClassificationTypes.GenOneBaseName)]
[Name(GenOneClassificationTypes.GenOneBaseName)]
[UserVisible(true)]
internal sealed class GenOneBaseNameFormatDefinition : ClassificationFormatDefinition
{
public GenOneBaseNameFormatDefinition()
{
    this.ForegroundColor = Colors.Blue;
    this.DisplayName = "GenOne Base Type Name";
}
}

