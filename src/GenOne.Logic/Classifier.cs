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

        if (line.Lexemes.Count == 4
            && line.Lexemes[0].Text == "let"
            && line.Lexemes[1].Text == "there"
            && line.Lexemes[2].Text == "be")
        {
            line.Lexemes[3].Category = LexemeCategory.TypeName;
            line.Category = LineCategory.TypeDefinition;
        }
        else
        {
            line.Category = LineCategory.Unknown;
        }
        return line;
    }
}
