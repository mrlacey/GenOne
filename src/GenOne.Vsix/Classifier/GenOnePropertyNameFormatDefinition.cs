using System.ComponentModel.Composition;
using System.Windows.Media;

using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace GenOne.Classifier;

[Export(typeof(EditorFormatDefinition))]
[ClassificationType(ClassificationTypeNames = GenOneClassificationTypes.GenOnePropertyName)]
[Name(GenOneClassificationTypes.GenOnePropertyName)]
[UserVisible(true)]
internal sealed class GenOnePropertyNameFormatDefinition : ClassificationFormatDefinition
{
public GenOnePropertyNameFormatDefinition()
{
    this.ForegroundColor = Colors.SaddleBrown;
    this.DisplayName = "GenOne Property Name";
}
}

