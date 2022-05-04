﻿// Copyright (c) Weihan Li. All rights reserved.
// Licensed under the MIT license.

using Exec;
using WeihanLi.Common.Models;
using Xunit.Abstractions;

namespace UnitTest;

public class CodeExecutorTest
{
    private readonly ITestOutputHelper _outputHelper;
    private readonly ICodeCompiler _compiler = new SimpleCodeCompiler();

    public CodeExecutorTest(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }
    
    [Theory]
    [InlineData("Console.WriteLine(123);")]
    [InlineData("using WeihanLi.Extensions; Console.WriteLine(args.StringJoin(\", \"));")]
    public async Task ExecuteWithDefaultEntry(string code)
    {
        var execOptions = new ExecOptions();
        var result = await _compiler.Compile(code, execOptions);
        Assert.True(result.IsSuccess());
        Assert.NotNull(result.Data);
        Guard.NotNull(result.Data);
        var executor = new CodeExecutor();
        var executeResult = await executor.Execute(result.Data, new[]{ "--hello", "world" }, execOptions);
        _outputHelper.WriteLine($"{executeResult.Msg}");
        Assert.True(executeResult.IsSuccess());
    }

    [Theory]
    [InlineData(@"
public class SomeTest
{
  public static void MainTest() { Console.WriteLine(""MainTest""); }
}")]
    [InlineData(@"
public class SomeTest
{
  public static void MainTest(string[] args) {}
}")]
    [InlineData(@"
internal class SomeTest
{
  public static void MainTest(string[] args) {}
}")]
    [InlineData(@"
internal class SomeTest
{
  private static void MainTest(string[] args) {}
}")]
    public async Task ExecuteWithCustomEntry(string code)
    {
        var execOptions = new ExecOptions();
        var result = await _compiler.Compile(code, execOptions);
        Assert.True(result.IsSuccess());
        Assert.NotNull(result.Data);
        Guard.NotNull(result.Data);
        var executor = new CodeExecutor();
        var executeResult = await executor.Execute(result.Data, Array.Empty<string>(), execOptions);
        _outputHelper.WriteLine($"{executeResult.Msg}");
        Assert.True(executeResult.IsSuccess());
    }
}
