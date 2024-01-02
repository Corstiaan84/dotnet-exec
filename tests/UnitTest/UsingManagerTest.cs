﻿// Copyright (c) 2022-2023 Weihan Li. All rights reserved.
// Licensed under the Apache license version 2.0 http://www.apache.org/licenses/LICENSE-2.0

using ReferenceResolver;

namespace UnitTest;

public class UsingManagerTest
{
    [Fact]
    public void GetNormalUsing()
    {
        var usingArray = new[] { "WeihanLi.Common", "static WeihanLi.Common.Helpers" };
        var usings = UsingManager.GetUsings(usingArray);
        Assert.NotNull(usings);
        Assert.NotEmpty(usings);
        Assert.Equal(2, usings.Count);
    }

    [Fact]
    public void GetRemoveUsing()
    {
        var usingArray = new[] { "WeihanLi.Common", "WeihanLi.Common.Helpers", "-WeihanLi.Common.Helpers" };
        var usings = UsingManager.GetUsings(usingArray);
        Assert.NotNull(usings);
        Assert.NotEmpty(usings);
        Assert.Single(usings);
        Assert.Equal("WeihanLi.Common", usings.First());
    }


    [Fact]
    public void GetRemoveGlobalUsing()
    {
        var usingArray = new[] { "WeihanLi.Common", "global::WeihanLi.Common.Helpers", "-WeihanLi.Common.Helpers" };
        var usings = UsingManager.GetUsings(usingArray);
        Assert.NotNull(usings);
        Assert.NotEmpty(usings);
        Assert.Single(usings);
        Assert.Equal("WeihanLi.Common", usings.First());
    }

    [Fact]
    public void GetGlobalUsingText()
    {
        var usingArray = new[] { "WeihanLi.Common", "static WeihanLi.Common.Helpers" };
        var usingText = UsingManager.GetGlobalUsingsCodeText(usingArray);
        Assert.NotNull(usingText);
        Assert.NotEmpty(usingText);
        Assert.Equal($@"global using WeihanLi.Common;{Environment.NewLine}global using static WeihanLi.Common.Helpers;", usingText);
    }
}
