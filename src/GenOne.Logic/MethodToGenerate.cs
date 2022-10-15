namespace GenOne.Logic;

public class MethodToGenerate
{
    public string Name { get; set; }

    public List<(string Name, string Datatype)> Args { get; set; } = new();
}
