using System.Collections.Generic;
using GenOne.Logic;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;

namespace GenOne.Classifier;

internal class GenOneClassifier : IClassifier
{
    public readonly IClassificationType classificationUnknown;
    public readonly IClassificationType classificationKeyWord;
    public readonly IClassificationType classificationTypeName;
    public readonly IClassificationType classificationPunctuation;
    public readonly IClassificationType classificationEnumName;
    public readonly IClassificationType classificationEnumValue;
    public readonly IClassificationType classificationBaseName;
    public readonly IClassificationType classificationMethodName;
    public readonly IClassificationType classificationMethodArgument;
    public readonly IClassificationType classificationPropName;
    public readonly IClassificationType classificationPropType;
    public readonly IClassificationType classificationPluralIndicator;
    public readonly IClassificationType classificationRequiredIndicator;

    internal GenOneClassifier(IClassificationTypeRegistryService registry)
    {
        this.classificationUnknown = registry.GetClassificationType(GenOneClassificationTypes.GenOneUnknown);
        this.classificationKeyWord = registry.GetClassificationType(GenOneClassificationTypes.GenOneKeyword);
        this.classificationTypeName = registry.GetClassificationType(GenOneClassificationTypes.GenOneTypeName);
        this.classificationPunctuation = registry.GetClassificationType(GenOneClassificationTypes.GenOnePunctuation);
        this.classificationEnumName = registry.GetClassificationType(GenOneClassificationTypes.GenOneEnumName);
        this.classificationEnumValue = registry.GetClassificationType(GenOneClassificationTypes.GenOneEnumValue);
        this.classificationBaseName = registry.GetClassificationType(GenOneClassificationTypes.GenOneBaseName);
        this.classificationMethodName = registry.GetClassificationType(GenOneClassificationTypes.GenOneMethodName);
        this.classificationMethodArgument = registry.GetClassificationType(GenOneClassificationTypes.GenOneMethodArgument);
        this.classificationPropName = registry.GetClassificationType(GenOneClassificationTypes.GenOnePropertyName);
        this.classificationPropType = registry.GetClassificationType(GenOneClassificationTypes.GenOnePropertyType);
        this.classificationPluralIndicator = registry.GetClassificationType(GenOneClassificationTypes.GenOnePluralIndicator);
        this.classificationRequiredIndicator = registry.GetClassificationType(GenOneClassificationTypes.GenOneRequiredPropIndicator);
    }

#pragma warning disable 67 //CS0067
    public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;
#pragma warning restore 67

    public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
    {
        var list = new List<ClassificationSpan>();

        var text = span.GetText();

        var tLine = Tokenizer.TokenizeLine(-1, text);
        var cLines = Logic.Classifier.ClassifyLine(tLine);

        foreach (var item in cLines.Lexemes)
        {
            if (item.Category.HasValue && item.Category != LexemeCategory.Unknown)
            {
                var typeSpan = new SnapshotSpan(span.Snapshot, text.IndexOf(item.Text) + span.Start, item.Text.Length);

                list.Add(new ClassificationSpan(typeSpan, this.GetClassificationType(item.Category.Value)));
            }
        }

        return list;
    }

    private IClassificationType GetClassificationType(LexemeCategory lcat)
    {
        return lcat switch
        {
            LexemeCategory.KeyWord => this.classificationKeyWord,
            LexemeCategory.TypeName => this.classificationTypeName,
            LexemeCategory.Punctuation => this.classificationPunctuation,
            LexemeCategory.EnumName => this.classificationEnumName,
            LexemeCategory.EnumValue => this.classificationEnumValue,
            LexemeCategory.BaseName => this.classificationBaseName,
            LexemeCategory.MethodName => this.classificationMethodName,
            LexemeCategory.MethodArgument => this.classificationMethodArgument,
            LexemeCategory.PropertyName => this.classificationPropName,
            LexemeCategory.PropertyType => this.classificationPropType,
            LexemeCategory.PluralIndicator => this.classificationPluralIndicator,
            LexemeCategory.RequiredPropertyIndicator => this.classificationRequiredIndicator,
            _ => this.classificationUnknown,
        };
    }
}
