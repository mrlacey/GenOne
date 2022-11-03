using System.ComponentModel.Composition;
using System.Windows.Media;

using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace GenOne.Classifier;

[Export(typeof(EditorFormatDefinition))]
[ClassificationType(ClassificationTypeNames = GenOneClassificationTypes.GenOnePropertyType)]
[Name(GenOneClassificationTypes.GenOnePropertyType)]
[UserVisible(true)]
internal sealed class GenOnePropertyTypeFormatDefinition : ClassificationFormatDefinition
{
public GenOnePropertyTypeFormatDefinition()
{
    this.ForegroundColor = Colors.CadetBlue;
    this.DisplayName = "GenOne Property Type";
}
}

