# Gen 1 - Generation

The following is a short outline describing how the generation will work.

1. Input is provided as a single string representing the whole document.
1. The string is broken into individual lines.
1. Lines are tokenized.
1. Tokenized lines are classified at the line and token level.
1. Classified lines are used to determine what to generate.
1. The final output is then generated.

Notes.

- All generated classes are generated as `partial`.
- Any line that cannot be classified fully is output as a comment.
- Any referenced but not declared type is used without validation. This is to allow for types defined later or elsewhere (in other files).
- Support for outputting code in languages other than C# is desired but not yet supported.
