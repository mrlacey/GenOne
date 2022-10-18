# GenOne

![GitHub Workflow Status](https://img.shields.io/github/workflow/status/mrlacey/GenOne/.NET)
![Built as part of BUILD](https://img.shields.io/badge/KingdomCode-Build-blueviolet)
![GitHub](https://img.shields.io/github/license/mrlacey/GenOne)

Building on the idea that parts of Genesis 1 "look a bit like a DSL for defining types." This is an experiment to see what such a DSL may look like.

This was part of the [Kingdom Code 2022 Build hackathon](https://kingdomcode.org.uk/build/).

We created a [basic grammar](./docs/grammar.md), with examples for input and output.

We created a Visual Studio (2022) extension so that this new DSL can be used in a C# project. [The extension is available in the VS Marketplace](https://marketplace.visualstudio.com/items?itemName=MattLaceyLtd.GenOne).

A member of the team (Emily) had experience with Python.  
The hope was to be able to use the same integration with Visual Studio, but this was not possible for Python projects.

So, we created a [website](https://proud-glacier-0d7289d03.2.azurestaticapps.net/) (using Blazor WASM) that allows input to be turned into either C# or Python.

The future of this is experiment is still to be determined...
