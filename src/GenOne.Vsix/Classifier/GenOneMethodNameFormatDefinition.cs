using System.ComponentModel.Composition;
using System.Windows.Media;

using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace GenOne.Classifier;

[Export(typeof(EditorFormatDefinition))]
[ClassificationType(ClassificationTypeNames = GenOneClassificationTypes.GenOneMethodName)]
[Name(GenOneClassificationTypes.GenOneMethodName)]
[UserVisible(true)]
internal sealed class GenOneMethodNameFormatDefinition : ClassificationFormatDefinition
{
public GenOneMethodNameFormatDefinition()
{
    this.ForegroundColor = Colors.LightGreen;
    this.DisplayName = "GenOne Method Name";
}
}

