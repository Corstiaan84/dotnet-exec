﻿// Copyright (c) Weihan Li. All rights reserved.
// Licensed under the MIT license.

using WeihanLi.Common.Models;

namespace Exec.Abstractions;

public interface ICodeExecutor
{
    Task<Result> Execute(CompileResult compileResult, ExecOptions options);
}