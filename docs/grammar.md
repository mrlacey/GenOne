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
    pass
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

class Person:
    pass

class User(Person):
    pass
```

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

from enum import Enum, auto

class UserType(Enum):
    Attendee = auto()
    Helper = auto()
    Organiser = auto()
    Sponsor = auto()
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
    pass

class Earth:
    def __init__(self, Seas: BodyOfWater):
        self.seas = Seas
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
{
    public string Depth { get; set; }
}
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

```py
class Earth:
    def __init__(self, Seas):
        self.seas = Seas
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

class Sea:
    def __init__(self):
        self.fish = []
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

```py
class User:
    def __init__(self, Name):
        self.name = Name
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
    def Shine(self):
        pass
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

class Expanse:
    def Separate(waters: Waters):
        pass
```
