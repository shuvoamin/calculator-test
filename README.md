**Calculator-Test**

This is a simple probability calculator based on pre-defined probability formula, more information available in `./docs/Test Instructions.docx`.

**How to build and run**

The best way to build and run this solution is using Visual Studio, you can download a free version from [here](https://visualstudio.microsoft.com/), you can also run it from command line interface, please check necessary commands [here](https://docs.microsoft.com/en-us/dotnet/core/tutorials/cli-create-console-app), in addition, there are more details available at dotnet core guidance [here](https://docs.microsoft.com/en-us/dotnet/core/), you can also run and debug it just by using supported text editor, I recommend using [Visual Studio Code](https://code.visualstudio.com/). And, you need to install .net core SDK (includes runtime as well) from [here](https://dotnet.microsoft.com/download/dotnet-core/2.1) For example; if you're running it from command line:-

Open Terminal or Command Prompt and go to the root folder of the solution, then

`cd src/web.api`\
`dotnet build`\
`dotnet run`

**Application's Info**

The app has API endpoint as following:-

`/api/calculations/leftInput/rightInput/logicCode`

- leftInput type is `double` (e.g. 0.5)
- rightInput type is `double` (e.g. 0.5)
- logicCode type is `int` (e.g. 1)
  - Acceptable logicCode
    1. Id 1 => P(A) * P(B)
    2. Id 2 => (P(A) + P(B)) - (P(A) * P(B))

API Retun:-

- On successful calculation based on above params it returns calculation result as json with 200 HTTP status code

    Example result
    ```
    {
        "calculationResult": "0.25"
    }
    ```

- If any validation or system exception occur it returns 500 HTTP status code

Note:-

- Both left and right input cannot be zero (e.g. 0) or negative value (e.g. -1)