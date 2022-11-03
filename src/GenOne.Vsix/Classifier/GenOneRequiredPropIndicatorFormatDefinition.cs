using System.ComponentModel.Composition;
using System.Windows.Media;

using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace GenOne.Classifier;

[Export(typeof(EditorFormatDefinition))]
[ClassificationType(ClassificationTypeNames = GenOneClassificationTypes.GenOneRequiredPropIndicator)]
[Name(GenOneClassificationTypes.GenOneRequiredPropIndicator)]
[UserVisible(true)]
internal sealed class GenOneRequiredPropIndicatorFormatDefinition : ClassificationFormatDefinition
{
public GenOneRequiredPropIndicatorFormatDefinition()
{
    this.ForegroundColor = Colors.DarkOrange;
    this.DisplayName = "GenOne Required Property Indicator";
}
}

