using System.ComponentModel.Composition;
using System.Windows.Media;

using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace GenOne.Classifier;

[Export(typeof(EditorFormatDefinition))]
[ClassificationType(ClassificationTypeNames = GenOneClassificationTypes.GenOneTypeName)]
[Name(GenOneClassificationTypes.GenOneTypeName)]
[UserVisible(true)]
internal sealed class GenOneTypeNameFormatDefinition : ClassificationFormatDefinition
{
    public GenOneTypeNameFormatDefinition()
{
    this.ForegroundColor = Colors.DeepSkyBlue;
    this.DisplayName = "GenOne Type Name";
}
}

