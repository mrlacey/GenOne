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
        line.Category = LineCategory.Unknown;

        return line;
    }
}
