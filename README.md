# salesfly-csharp

[![Build Status](https://travis-ci.org/salesfly/salesfly-csharp.svg?branch=master)](https://travis-ci.org/salesfly/salesfly-csharp)

C#/.NET client for [Salesfly API](https://salesfly.com)&reg;

## Documentation

See the [C# API docs](https://docs.salesfly.com/csharp/).

## Requirements

The C# client for Salesfly API requires .NET Core 3.0 or later to be installed. You can check if you already have .NET Core installed on your machine by opening up a command prompt or terminal and running the following command:

```bash
dotnet --version
```

You should see something like 3.0.100. If you receive an error message, you can [download .NET Core from Microsoft](https://www.microsoft.com/net/) and install it.

## Installation

With .NET CLI

```powershell
dotnet add package Salesfly --version 1.0.0
```

With Package Manager

```powershell
PM> Install-Package Salesfly -Version 1.0.0
```

## Usage

The library needs to be configured with your account's API key. Get your own API key by signing up for a free [Salesfly account](https://salesfly.com).

```csharp
using System;
using Salesfly;
using Salesfly.Api;
using Salesfly.Exceptions;

class Program
{
    static void Main(string[] args)
    {
        var apiKey = Environment.GetEnvironmentVariable("SALESFLY_APIKEY");
        try
        {
            SalesflyClient.Init(apiKey);
            var location = await Api.GeoLocation.Get("8.8.8.8");
            Console.WriteLine("Country code: " + location.CountryCode);
        } catch (ResponseException e) {
            Console.WriteLine("Failed to get location");
        }
    }
}
```

## License and Trademarks

Copyright (c) 2018-20 UAB Salesfly.

Licensed under the [MIT license](https://en.wikipedia.org/wiki/MIT_License).

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

Salesfly is a registered trademark of [UAB Salesfly](https://www.salesfly.com).
