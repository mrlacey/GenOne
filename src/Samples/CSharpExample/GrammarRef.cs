/*
Original source
===============
let there be User

the User is Person

let there be a UserType with the kinds Attendee, Helper, Organiser, Sponsor

let there be DeepSeas in the Earth

let there be Seas(BodyOfWater) in the Earth

let the Sea have a Depth

let the Moutain have an Altitude

let the Sea have a NauticalDepth that's a float

let there be lots of Fishes(Fish) in the Sea

the User must have a Name

let the Sun Shine

let the Expanse Separate Waters

*/

namespace CSharpExample;

enum UserType
{
    Attendee,
    Helper,
    Organiser,
    Sponsor,
}
partial class User : Person
{
    public string Name { get; init; }
}
partial class Earth
{
    public string DeepSeas { get; set; }
    public BodyOfWater Seas { get; set; }
}
partial class Sea
{
    public string Depth { get; set; }
    public float NauticalDepth { get; set; }
    public IEnumerable<Fish> Fishes { get; set; }
}
partial class Moutain
{
    public string Altitude { get; set; }
}
partial class Sun
{
    public partial void Shine() { }
}
partial class Expanse
{
    public partial void Separate(Waters Waters) { }
}

