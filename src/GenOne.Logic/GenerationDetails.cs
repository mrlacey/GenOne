namespace GenOne.Logic;

public class GenerationDetails
{
    public List<EnumToGenerate> Enums { get; set; } = new();

    public List<TypeToGenerate> Types { get; set; } = new();

    // TODO: work out where/when/how to output the comment lines.
    public List<string> CommentLines { get; set; } = new();
}
