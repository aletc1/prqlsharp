# PrqlSharp

PrqlSharp offers C# bindings to the awesome [prql-lib](https://github.com/prql/prql) rust library (version 0.2.11). It exposes the following methods:
- ```ToSql```: Converts a [PRQL query](https://prql-lang.org/) into an SQL query
- ```ToJson```: Parses a [PRQL query](https://prql-lang.org/) and returns the Abstract Syntax Tree (AST) in JSON
- ```FromJson```: Parses a PRQL AST and returns the [PRQL query](https://prql-lang.org/)

## Installation

Just add ```PrqlSharp``` package from Nuget repository.

```
dotnet add package PrqlSharp
```

## Usage

Just call the static methods of ```Prql``` class like:

```csharp
Console.WriteLine(PrqlCsharp.Prql.ToSql("from table1 | select [col1, col2]"));
```

You will get:
```
SELECT
  col1,
  col2
FROM
  table1
```

## Platforms

This nuget package is only available for ```linux``` and ```windows```.