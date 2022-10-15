# Gen 1 - Grammar

The initial grammar, with examples producing C#.

The following notation is used:

- `let there be` : plain text are keywords.
- `{typeName}` : text in curly braces is generated output.
- `[optional]` : text in square braces is optional.
- `<A|B>` : text in angle brackets represents exclusive options. One of which must be specified.
- `...` : an ellipse indicates, optionally, more of the same.
- `({datatype})` : brackets can surround a datatype, immediately after a property, as shortcut notation for defining a datatype.

## Type creation

**`'let there be {typeName}'`**

E.g.

```ascii
let there be User
```

produces:

```cs
partial class User
{
}
```

```py
class User:
```

## Type Inheritance

**`'the {typeName} is {baseClass}'`**

E.g.

```ascii
the User is Person
```

produces:

```cs
partial class User : Person
{
}
```

```py
class User(Person):```

## Enum creation

**`'let there be [a[n]] {enumName} <of|with> the kinds {enumValueA}[, {enumValueB}, ....]'`**

E.g.

```ascii
let there be a UserType with the kinds Attendee, Helper, Organiser, Sponsor
```

produces:

```cs
enum UserType
{
    Attendee,
    Helper,
    Organiser,
    Sponsor,
}
```

produces:

```py
class UserType(Enum):
    Attendee = 1
    Helper = 2
    Organiser = 3
    Sponsor = 4
```



## Property Definition 1 - simple

**`'let there be [a[n]] {propertyName}[({dataType})] in [the] {typeName}'`**

E.g.

```ascii
let there be Seas in the Earth
```

produces:

```cs
partial class Earth
{
    public string Seas { get; set; }
}
```

```py
class Earth:
    def __init__(self, Seas):
        self.seas = Seas
```

E.g. 2

```ascii
let there be Seas(BodyOfWater) in the Earth
```

produces:

```cs
partial class Earth
{
    public BodyOfWater Seas { get; set; }
}
```

```py
class BodyOfWater:

class Earth:
    def __init__(self, Seas):
        self.seas = BodyOfWater(Seas)
```

## Property Definition 2 - simple alternative

There are two simple definitions for defining properties. This is to provide options allowing for whatever reads most naturally.

**`'let the {typeName} have a {propertyName} [<that's|as> a[n] {dataType}]'`**

E.g.

```ascii
let the Sea have a Depth
```

produces:

```cs
partial class Sea
    def __init__(self, Depth):
        self.depth = Depth
```

```py
class Sea:
    Depth
```

E.g. 2

```ascii
let the Sea have a Depth that's a float
```

produces:

```cs
partial class Sea
{
    public float Depth { get; set; }
}
```

## Property Definition 3 - collections

**`'let there be <many|lots of> {propertyName} in [the] {typeName}'`**

E.g.

```ascii
let there be many Fishes(Fish) in the Sea
```

produces:

```cs
partial class Sea
{
    public IEnumerable<Fish> Fishes { get; set; }
}
```

```py

class Sea
    fish = []
```

## Property Definition 4 - required properties

**`'the {typeName} must have a[n] {propertyName}'`**

E.g.

```ascii
the User must have a Name
```

produces:

```cs
partial class User
{
    public User(string name)
    {
        Name = name;
    }

    public string Name { get; init; }
}
```

## Method Definition

**`'let the {typeName} {methodName} [{arg1}, ....]'`**

Note. Generated methods are defined as partial

E.g.

```ascii
let the Sun Shine
```

produces:

```cs
partial class Sun
{
    partial void Shine();
}
```

```py
class Sun:
    def shine(self):
    # empty - because this may need a definition
```

```ascii
let the Expanse Separate Waters
```

produces:

```cs
partial class Expanse
{
    partial void Separate(Waters waters);
}
```

```py
class Waters:

class Expanse
    def Separate(Waters waters):
```
