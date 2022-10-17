using System.Collections.Generic;
using System.ComponentModel.Composition;
using GenOne.Logic;
using Microsoft.VisualStudio.Language.StandardClassification;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace GenOne.Classifier
{

    internal static class GenOne
    {
        internal const string ContentType = nameof(GenOne);

        internal const string FileExtension = ".gen1";

        [Export]
        [Name(ContentType)]
        [BaseDefinition("code")]
#pragma warning disable SA1401 // Fields must be private
        internal static ContentTypeDefinition ContentTypeDefinition = null;

        [Export]
        [Name(ContentType + nameof(FileExtensionToContentTypeDefinition))]
        [ContentType(ContentType)]
        [FileExtension(FileExtension)]
        internal static FileExtensionToContentTypeDefinition FileExtensionToContentTypeDefinition = null;
#pragma warning restore SA1401 // Fields must be private
    }

    [Export(typeof(IClassifierProvider))]
    [ContentType(GenOne.ContentType)]
    internal class GenOneClassifierProvider : IClassifierProvider
    {
        [Import]
        private IClassificationTypeRegistryService ClassificationRegistry { get; set; }

        public IClassifier GetClassifier(ITextBuffer buffer) =>
            buffer.Properties.GetOrCreateSingletonProperty(() =>
                new GenOneClassifier(this.ClassificationRegistry));
    }



    internal class GenOneClassifier : IClassifier
    {
        public readonly IClassificationType classificationTab;
        private readonly IClassificationType classificationLabel;
        private readonly IClassificationType classificationComment;
        private readonly IClassificationType classificationOther;

        internal GenOneClassifier(IClassificationTypeRegistryService registry)
        {
            this.classificationTab = registry.GetClassificationType(GenOneClassificationTypes.GenOneTab);
            this.classificationLabel = registry.GetClassificationType(GenOneClassificationTypes.GenOneLabel);
            this.classificationComment = registry.GetClassificationType(GenOneClassificationTypes.GenOneComment);
            this.classificationOther = registry.GetClassificationType(GenOneClassificationTypes.GenOneOther);
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
                if (item.Category == LexemeCategory.TypeName)
                {
                    var typeSpan = new SnapshotSpan(span.Snapshot, text.IndexOf(item.Text), item.Text.Length);

                    //list.Add(new ClassificationSpan(span, this.GetClassificationType(text)));
                    list.Add(new ClassificationSpan(typeSpan, this.GetClassificationType(text)));
                }
            }


            return list;
        }

        private IClassificationType GetClassificationType(string line)
        {
            switch (new GenOneLineTypeIdentifier().GetLineType(line))
            {
                case GenOneLineType.Comment:
                    return this.classificationComment;

                case GenOneLineType.Tab:
                    return this.classificationTab;

                case GenOneLineType.Label:
                    return this.classificationLabel;

                case GenOneLineType.Other:
                default:
                    // return this.classificationOther;
                    return this.classificationTab;
            }
        }
    }

    public enum GenOneLineType
    {
        Other,
        Comment,
        Tab,
        Label,
        EndSnippet,
    }


    public class GenOneLineTypeIdentifier
    {
        internal const string LineStartComment = "#";
        internal const string LineStartTab = "tab:";
        internal const string LineStartLabel = "-";
        private const string CommentTab = "DEMOSNIPPETS-TAB";
        private const string CommentLabel = "DEMOSNIPPETS-LABEL";
        private const string CommentEndSnippet = "DEMOSNIPPETS-ENDSNIPPET";

        // For some languages (e.g C++) '#' has a separate meaning to a DemoSnippets comment indicator
        // Track if in a file containing subExt formatting so know not to look for standard formatting
        private bool subExtFormattingOnly = false;

        public GenOneLineType GetLineType(string line)
        {
            if (!this.subExtFormattingOnly && line.StartsWith(LineStartComment))
            {
                return GenOneLineType.Comment;
            }
            else if (!this.subExtFormattingOnly && line.StartsWith(LineStartLabel))
            {
                return GenOneLineType.Label;
            }
            else if (line.ToUpperInvariant().Contains(CommentLabel))
            {
                this.subExtFormattingOnly = true;
                return GenOneLineType.Label;
            }
            else if (!this.subExtFormattingOnly && line.ToLowerInvariant().StartsWith(LineStartTab))
            {
                return GenOneLineType.Tab;
            }
            else if (line.ToUpperInvariant().Contains(CommentTab))
            {
                this.subExtFormattingOnly = true;
                return GenOneLineType.Tab;
            }
            else if (line.ToUpperInvariant().Contains(CommentEndSnippet))
            {
                this.subExtFormattingOnly = true;
                return GenOneLineType.EndSnippet;
            }
            else
            {
                return GenOneLineType.Other;
            }
        }

        public string GetTabName(string line)
        {
            if (line.ToLowerInvariant().StartsWith(LineStartTab))
            {
                return line.Substring(4).Trim();
            }
            else
            {
                var startIndex = line.IndexOf(CommentTab, StringComparison.InvariantCultureIgnoreCase);

                return RemoveClosingCommentTabs(line.Substring(startIndex + CommentTab.Length)).Trim();
            }
        }

        public string GetLabelName(string line)
        {
            if (line.ToLowerInvariant().StartsWith(LineStartLabel))
            {
                return line.Substring(1).Trim();
            }
            else
            {
                var startIndex = line.IndexOf(CommentLabel, StringComparison.InvariantCultureIgnoreCase);

                return RemoveClosingCommentTabs(line.Substring(startIndex + CommentLabel.Length)).Trim();
            }
        }

        private static string RemoveClosingCommentTabs(string input)
        {
            return input.Replace("*/", string.Empty)
                        .Replace("-->", string.Empty)
                        .TrimEnd();
        }
    }

    internal static class GenOneClassificationTypes
    {
        public const string GenOneTab = "ds_tab";
        public const string GenOneLabel = "ds_label";
        public const string GenOneComment = PredefinedClassificationTypeNames.Comment;
        public const string GenOneOther = PredefinedClassificationTypeNames.Other;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(GenOneTab)]
        public static ClassificationTypeDefinition GenOneClassificationTab { get; set; }

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(GenOneLabel)]
        public static ClassificationTypeDefinition GenOneClassificationLabel { get; set; }
    }



    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = GenOneClassificationTypes.GenOneTab)]
    [Name(GenOneClassificationTypes.GenOneTab)]
    [UserVisible(true)]
    internal sealed class GenOneTabFormatDefinition : ClassificationFormatDefinition
    {
        public GenOneTabFormatDefinition()
        {
            this.BackgroundColor = System.Windows.Media.Colors.LightGray;
            this.BackgroundOpacity = .4;
            this.DisplayName = "GenOne Type";
        }
    }


}
