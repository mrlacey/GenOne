using System.ComponentModel.Composition;
using System.Windows.Media;

using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace GenOne.Classifier;

[Export(typeof(EditorFormatDefinition))]
[ClassificationType(ClassificationTypeNames = GenOneClassificationTypes.GenOneKeyword)]
[Name(GenOneClassificationTypes.GenOneKeyword)]
[UserVisible(true)]
internal sealed class GenOneKeywordFormatDefinition : ClassificationFormatDefinition
{
    public GenOneKeywordFormatDefinition()
    {
        this.ForegroundColor = Colors.Purple;
        this.DisplayName = "GenOne Keyword";
    }
}

