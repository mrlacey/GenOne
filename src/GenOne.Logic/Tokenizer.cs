namespace GenOne.Logic;

public static class Tokenizer
{
    public static List<TokenizedLine> TokenizeLines(List<string> lines)
    {
        var result = new List<TokenizedLine>();

        for (int i = 0; i < lines.Count; i++)
        {
            result.Add(TokenizeLine(i, lines[i]));
        }

        return result;
    }

    public static TokenizedLine TokenizeLine(int lineNo, string line)
    {
        return new TokenizedLine(lineNo, line);
    }
}
