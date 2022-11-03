using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Language.StandardClassification;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace GenOne.Classifier;

internal static class GenOneClassificationTypes
{
    public const string GenOneUnknown = PredefinedClassificationTypeNames.Other;
    public const string GenOneKeyword = "Gen1-Keyword";
    public const string GenOneTypeName = "Gen1-TypeName";
    public const string GenOnePunctuation = "Gen1-Punctuation";
    public const string GenOneEnumValue = "Gen1-EnumValue";
    public const string GenOneEnumName = "Gen1-EnumName";
    public const string GenOneBaseName = "Gen1-BaseName";
    public const string GenOneMethodName = "Gen1-MethodName";
    public const string GenOneMethodArgument = "Gen1-MethodArg";
    public const string GenOnePropertyName = "Gen1-PropName";
    public const string GenOnePropertyType = "Gen1-PropType";
    public const string GenOnePluralIndicator = "Gen1-PluralIndicator";
    public const string GenOneRequiredPropIndicator = "Gen1-RequiredIndicator";

    public const string GenOneComment = PredefinedClassificationTypeNames.Comment;

    [Export(typeof(ClassificationTypeDefinition))]
    [Name(GenOneKeyword)]
    public static ClassificationTypeDefinition GenOneClassificationKeyword { get; set; }

    [Export(typeof(ClassificationTypeDefinition))]
    [Name(GenOneTypeName)]
    public static ClassificationTypeDefinition GenOneClassificationTypeName { get; set; }

    [Export(typeof(ClassificationTypeDefinition))]
    [Name(GenOnePunctuation)]
    public static ClassificationTypeDefinition GenOneClassificationPunctuation { get; set; }

    [Export(typeof(ClassificationTypeDefinition))]
    [Name(GenOneEnumName)]
    public static ClassificationTypeDefinition GenOneClassificationEnumName { get; set; }

    [Export(typeof(ClassificationTypeDefinition))]
    [Name(GenOneEnumValue)]
    public static ClassificationTypeDefinition GenOneClassificationEnumValue { get; set; }

    [Export(typeof(ClassificationTypeDefinition))]
    [Name(GenOneBaseName)]
    public static ClassificationTypeDefinition GenOneClassificationBaseName { get; set; }

    [Export(typeof(ClassificationTypeDefinition))]
    [Name(GenOneMethodName)]
    public static ClassificationTypeDefinition GenOneClassificationMethodName { get; set; }

    [Export(typeof(ClassificationTypeDefinition))]
    [Name(GenOneMethodArgument)]
    public static ClassificationTypeDefinition GenOneClassificationMethodArgument { get; set; }

    [Export(typeof(ClassificationTypeDefinition))]
    [Name(GenOnePropertyName)]
    public static ClassificationTypeDefinition GenOneClassificationPropertyName { get; set; }

    [Export(typeof(ClassificationTypeDefinition))]
    [Name(GenOnePropertyType)]
    public static ClassificationTypeDefinition GenOneClassificationPropertyType { get; set; }

    [Export(typeof(ClassificationTypeDefinition))]
    [Name(GenOnePluralIndicator)]
    public static ClassificationTypeDefinition GenOneClassificationPluralIndicator { get; set; }

    [Export(typeof(ClassificationTypeDefinition))]
    [Name(GenOneRequiredPropIndicator)]
    public static ClassificationTypeDefinition GenOneClassificationRequiredIndicator { get; set; }
}
