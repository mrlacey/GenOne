namespace GenOne.Logic;

public class TokenizedLine
{
    public TokenizedLine(int number, string text)
    {
        LineNumber = number;
        OriginalText = text;

        // TODO: implement the tokenization
    }

    public int LineNumber { get; set; }

    public string OriginalText { get; set; }

    public List<Lexeme> Lexemes { get; set; } = new();

    public LineCategory? Category { get; set; }
}
