using GenOne.Logic;

namespace GenOne.Tests;

public class SingleLineReferenceTests
{
    [Fact]
    public void TypeCreation1()
    {
        var gd = GetGenerationDetails("let there be User");

        Assert.Single(gd.Types);

        Assert.Equal("User", gd.Types.Single().Name);
    }

    [Fact]
    public void TypeInheritence1()
    {
        var gd = GetGenerationDetails("the User is Person");

        Assert.Single(gd.Types);

        Assert.Equal("User", gd.Types.Single().Name);
        Assert.Equal("Person", gd.Types.Single().BaseClass);
    }

    [Fact]
    public void EnumCreation1()
    {
        var gd = GetGenerationDetails("let there be a UserType with the kinds Attendee, Helper, Organiser, Sponsor");

        Assert.Empty(gd.Types);
        Assert.Single(gd.Enums);

        Assert.Equal("UserType", gd.Enums.Single().Name);
        Assert.Equal(4, gd.Enums.Single().Values.Count);

        Assert.Contains("Attendee", gd.Enums.Single().Values);
        Assert.Contains("Helper", gd.Enums.Single().Values);
        Assert.Contains("Organiser", gd.Enums.Single().Values);
        Assert.Contains("Sponsor", gd.Enums.Single().Values);
    }

    [Fact]
    public void PropertyDefinition1()
    {
        var gd = GetGenerationDetails("let there be Seas in the Earth");

        Assert.Single(gd.Types);

        Assert.Equal("Earth", gd.Types.Single().Name);

        Assert.Single(gd.Types.Single().Properties);
        Assert.Equal("Seas", gd.Types.Single().Properties.Single().Name);
        Assert.Equal("string", gd.Types.Single().Properties.Single().DataType);
    }

    [Fact]
    public void PropertyDefinition2()
    {
        var gd = GetGenerationDetails("let there be Seas(BodyOfWater) in the Earth");

        Assert.Single(gd.Types);

        Assert.Equal("Earth", gd.Types.Single().Name);

        Assert.Single(gd.Types.Single().Properties);
        Assert.Equal("Seas", gd.Types.Single().Properties.Single().Name);
        Assert.Equal("BodyOfWater", gd.Types.Single().Properties.Single().DataType);
    }

    [Fact]
    public void PropertyDefinition3()
    {
        var gd = GetGenerationDetails("let the Sea have a Depth");

        Assert.Single(gd.Types);

        Assert.Equal("Sea", gd.Types.Single().Name);

        Assert.Single(gd.Types.Single().Properties);
        Assert.Equal("Depth", gd.Types.Single().Properties.Single().Name);
        Assert.Equal("string", gd.Types.Single().Properties.Single().DataType);
    }

    [Fact]
    public void PropertyDefinition4()
    {
        var gd = GetGenerationDetails("let the Sea have a Depth that's a float");

        Assert.Single(gd.Types);

        Assert.Equal("Sea", gd.Types.Single().Name);

        Assert.Single(gd.Types.Single().Properties);
        Assert.Equal("Depth", gd.Types.Single().Properties.Single().Name);
        Assert.Equal("float", gd.Types.Single().Properties.Single().DataType);
    }

    [Fact]
    public void PropertyDefinition5()
    {
        var gd = GetGenerationDetails("let there be many Fishes(Fish) in the Sea");

        Assert.Single(gd.Types);

        Assert.Equal("Sea", gd.Types.Single().Name);

        Assert.Single(gd.Types.Single().Properties);
        Assert.Equal("Fishes", gd.Types.Single().Properties.Single().Name);
        Assert.Equal("IEnumerable<Fish>", gd.Types.Single().Properties.Single().DataType);
    }

    [Fact]
    public void PropertyDefinition6()
    {
        var gd = GetGenerationDetails("the User must have a Name");

        Assert.Single(gd.Types);

        Assert.Equal("User", gd.Types.Single().Name);

        Assert.Single(gd.Types.Single().Properties);
        Assert.Equal("Name", gd.Types.Single().Properties.Single().Name);
        Assert.Equal("string", gd.Types.Single().Properties.Single().DataType);
        Assert.True(gd.Types.Single().Properties.Single().IsRequired);
    }

    [Fact]
    public void MethodDefinition1()
    {
        var gd = GetGenerationDetails("let the Sun Shine");

        Assert.Single(gd.Types);

        Assert.Equal("Sun", gd.Types.Single().Name);

        Assert.Single(gd.Types.Single().Methods);
        Assert.Equal("Shine", gd.Types.Single().Methods.Single().Name);
        Assert.Empty(gd.Types.Single().Methods.Single().Args);
    }

    [Fact]
    public void MethodDefinition2()
    {
        var gd = GetGenerationDetails("let the Expanse Separate Waters");

        Assert.Single(gd.Types);

        Assert.Equal("Expanse", gd.Types.Single().Name);

        Assert.Single(gd.Types.Single().Methods);
        Assert.Equal("Separate", gd.Types.Single().Methods.Single().Name);
        Assert.Single(gd.Types.Single().Methods.Single().Args);
        Assert.Equal("Waters", gd.Types.Single().Methods.Single().Args.Single().Name);
        Assert.Equal("Waters", gd.Types.Single().Methods.Single().Args.Single().Datatype);
    }

    private GenerationDetails GetGenerationDetails(string line)
    {
        var tLine = Tokenizer.TokenizeLine(1, line);

        var cLine = Classifier.ClassifyLine(tLine);

        return CSharpGenerator.DetermineGeneration(new List<TokenizedLine> { cLine });
    }
}
