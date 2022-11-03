using System.ComponentModel.Composition;
using System.Windows.Media;

using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace GenOne.Classifier;

[Export(typeof(EditorFormatDefinition))]
[ClassificationType(ClassificationTypeNames = GenOneClassificationTypes.GenOneEnumValue)]
[Name(GenOneClassificationTypes.GenOneEnumValue)]
[UserVisible(true)]
internal sealed class GenOneEnumValueFormatDefinition : ClassificationFormatDefinition
{
public GenOneEnumValueFormatDefinition()
{
    this.ForegroundColor = Colors.PaleVioletRed;
    this.DisplayName = "GenOne Enum Value";
}
}

