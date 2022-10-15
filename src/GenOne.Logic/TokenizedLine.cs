namespace GenOne.Logic;

public class TokenizedLine
{
    public TokenizedLine(int number, string text)
    {
        LineNumber = number;
        OriginalText = text;

        // TODO: tokenize the tokenization better + add start & end values
        var words = text.Split(new[] { " " }, System.StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in words)
        {
            Lexemes.Add(new Lexeme(word));
        }
    }

    public int LineNumber { get; set; }

    public string OriginalText { get; set; }

    public List<Lexeme> Lexemes { get; set; } = new();

    public LineCategory? Category { get; set; }
}
