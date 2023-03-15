﻿// Copyright (c) Weihan Li. All rights reserved.
// Licensed under the MIT license.

Console.WriteLine($"Hello is {RegexHelper.IsLowercase("Hello")}");

public partial class RegexHelper
{
    // The Source Generator generates the code of the method at compile time
    [System.Text.RegularExpressions.GeneratedRegex("^[a-z]+$")]
    public static partial System.Text.RegularExpressions.Regex LowercaseLettersRegex();

    public static bool IsLowercase(string value)
    {
        return LowercaseLettersRegex().IsMatch(value);
    }
}
