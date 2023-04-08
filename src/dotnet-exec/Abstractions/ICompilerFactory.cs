﻿// Copyright (c) Weihan Li. All rights reserved.
// Licensed under the MIT license.

namespace Exec.Abstractions;

public interface ICompilerFactory
{
    ICodeCompiler GetCompiler(string compilerType);
}