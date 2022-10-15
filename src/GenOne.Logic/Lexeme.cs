namespace GenOne.Logic;

public class Lexeme
{
    public int Start { get; set; }
    public int End { get; set; }
    public string Text { get; set; }
    public LexemeCategory Category { get; set; }
}
