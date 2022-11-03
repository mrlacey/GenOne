using System.ComponentModel.Composition;
using System.Windows.Media;

using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace GenOne.Classifier;

[Export(typeof(EditorFormatDefinition))]
[ClassificationType(ClassificationTypeNames = GenOneClassificationTypes.GenOnePluralIndicator)]
[Name(GenOneClassificationTypes.GenOnePluralIndicator)]
[UserVisible(true)]
internal sealed class GenOnePluralIndicatorFormatDefinition : ClassificationFormatDefinition
{
public GenOnePluralIndicatorFormatDefinition()
{
    this.ForegroundColor = Colors.DarkMagenta;
    this.DisplayName = "GenOne Plural Indicator";
}
}

