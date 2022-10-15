namespace GenOne.Logic;

public class Lexeme
{
    public Lexeme(string text)
    {
        Text = text;
    }

    public string Text { get; set; }

    public int Start { get; set; }

    public int End { get; set; }

    public LexemeCategory? Category { get; set; }
}
