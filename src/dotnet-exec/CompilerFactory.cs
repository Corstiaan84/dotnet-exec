﻿// Copyright (c) Weihan Li. All rights reserved.
// Licensed under the MIT license.

namespace Exec;

public sealed class CompilerFactory : ICompilerFactory
{
    private readonly IServiceProvider _serviceProvider;

    public CompilerFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ICodeCompiler GetCompiler(string compilerType)
    {
        return compilerType.ToLower() switch
        {
            "simple" => _serviceProvider.GetRequiredService<SimpleCodeCompiler>(),
            Helper.Script => _serviceProvider.GetRequiredService<CSharpScriptCompilerExecutor>(),
            _ => _serviceProvider.GetRequiredService<WorkspaceCodeCompiler>()
        };
    }
}
