namespace GenOne.Logic;

public class PropertyToGenerate
{
    public PropertyToGenerate(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    public string DataType { get; set; } = "string";

    public bool IsRequired { get; set; }
}
