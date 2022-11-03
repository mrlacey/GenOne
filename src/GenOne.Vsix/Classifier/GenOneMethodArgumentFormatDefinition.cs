using System.ComponentModel.Composition;
using System.Windows.Media;

using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace GenOne.Classifier;

[Export(typeof(EditorFormatDefinition))]
[ClassificationType(ClassificationTypeNames = GenOneClassificationTypes.GenOneMethodArgument)]
[Name(GenOneClassificationTypes.GenOneMethodArgument)]
[UserVisible(true)]
internal sealed class GenOneMethodArgumentFormatDefinition : ClassificationFormatDefinition
{
public GenOneMethodArgumentFormatDefinition()
{
    this.ForegroundColor = Colors.PaleGreen;
    this.DisplayName = "GenOne Method Argument";
}
}

