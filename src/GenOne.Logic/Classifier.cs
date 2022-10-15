namespace GenOne.Logic;

public static class Classifier
{
    public static List<TokenizedLine> ClassifyLines(List<TokenizedLine> lines)
    {
        var results = new List<TokenizedLine>();

        foreach (var line in lines)
        {
            results.Add(ClassifyLine(line));
        }

        return results;
    }

    public static TokenizedLine ClassifyLine(TokenizedLine line)
    {
        // TODO: do the actual classification of the line (and each lexeme--or should that be done at the time of tokenizing?)

        if (line.Lexemes.Count == 4)
        {
            if (line.Lexemes[0].Text == "let"
            && line.Lexemes[1].Text == "there"
            && line.Lexemes[2].Text == "be")
            {
                line.Lexemes[3].Category = LexemeCategory.TypeName;
                line.Category = LineCategory.TypeDefinition;
            }
            else if (line.Lexemes[0].Text == "the"
            && line.Lexemes[2].Text == "is")
            {
                line.Lexemes[1].Category = LexemeCategory.TypeName;
                line.Lexemes[3].Category = LexemeCategory.BaseName;
                line.Category = LineCategory.TypeInheritence;
            }
        }
        else if (line.Lexemes.Count >= 8
            && line.OriginalText.StartsWith("let there be")
            && (line.OriginalText.Contains("of the kinds") || line.OriginalText.Contains("with the kinds")))
        {
            var l4 = line.Lexemes[3];

            if (l4.Text == "a" || l4.Text == "an")
            {
                l4 = line.Lexemes[4];
            }

            l4.Category = LexemeCategory.EnumName;

            var foundValues = false;

            foreach (var lexeme in line.Lexemes)
            {
                if (foundValues)
                {
                    lexeme.Category = LexemeCategory.EnumValue;
                }
                else if (lexeme.Text == "kinds")
                {
                    foundValues = true;
                }
            }

            line.Category = LineCategory.EnumDefinition;
        }
        else
        {
            line.Category = LineCategory.Unknown;
        }
        return line;
    }
}
