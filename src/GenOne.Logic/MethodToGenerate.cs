namespace GenOne.Logic;

public class MethodToGenerate
{
    public MethodToGenerate(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    public List<(string Name, string Datatype)> Args { get; set; } = new();
}
