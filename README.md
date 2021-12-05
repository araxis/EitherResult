# EitherResult
[![Arax.EitherResult - NuGet](https://img.shields.io/badge/nuget-Arax.EitherResult-blue)](https://www.nuget.org/packages/Arax.EitherResult)
[![NuGet](https://img.shields.io/nuget/dt/Arax.EitherResult.svg)](https://www.nuget.org/packages/Arax.EitherResult) 
[![.NET](https://github.com/araxis/EitherResult/actions/workflows/dotnet.yml/badge.svg)](https://github.com/araxis/EitherResult/actions/workflows/dotnet.yml)

Implemetation of Haskell's Either type in C#

### Installing EitherResult

You should install [EitherResult with NuGet](https://www.nuget.org/packages/Arax.EitherResult)

    Install-Package Arax.SimpleResult
    
Or via the .NET Core command line interface:

    dotnet add package Arax.EitherResult

##  Make Either<T,U> and Return 
```csharp
    public Either<int,string> GetResult()
    {
            if (condition)
            {
                return Either<int, string>.Left(1);
            }
            else
            {
                return Either<int, string>.Right("Result");
            }
    }
```
## OR : More Simple
```csharp
public Either<int,string> GetPerson(long id)
    {
        if (condition)
            {
                return 1;
            }
            else
            {
                return "Result";
            }
    }
```
## Usage 
```csharp
public void UseResult()
{
   Either<int, string> result = GetResult();

   result.Switch(onLeft: left => { },onRight: right => { });

   Either<string, int> mapResult = result.Map(transformLeft:left => "map left", transformRight: right => 25);

   string foldResult = result.Fold(transformLeft: left => left.ToString(), transformRight: right => right);
}
```
