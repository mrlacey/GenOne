using System.ComponentModel.Composition;
using System.Windows.Media;

using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace GenOne.Classifier;

[Export(typeof(EditorFormatDefinition))]
[ClassificationType(ClassificationTypeNames = GenOneClassificationTypes.GenOneEnumName)]
[Name(GenOneClassificationTypes.GenOneEnumName)]
[UserVisible(true)]
internal sealed class GenOneEnumNameFormatDefinition : ClassificationFormatDefinition
{
public GenOneEnumNameFormatDefinition()
{
    this.ForegroundColor = Colors.YellowGreen;
    this.DisplayName = "GenOne Enum Name";
}
}

