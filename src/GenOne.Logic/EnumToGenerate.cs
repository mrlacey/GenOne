namespace GenOne.Logic;

public class EnumToGenerate
{
    public EnumToGenerate(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    public List<string> Values { get; set; } = new();
}
