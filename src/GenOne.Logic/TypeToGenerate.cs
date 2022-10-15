namespace GenOne.Logic;

public class TypeToGenerate
{
    public TypeToGenerate(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    public string? BaseClass { get; set; }

    public List<PropertyToGenerate> Properties { get; set; } = new();

    public List<MethodToGenerate> Methods { get; set; } = new();
}
