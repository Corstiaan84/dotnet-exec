﻿// Copyright (c) Weihan Li. All rights reserved.
// Licensed under the MIT license.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ReferenceResolver;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddReferenceResolvers(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddLogging();
        serviceCollection.TryAddSingleton<INuGetHelper, NuGetHelper>();
        serviceCollection.TryAddSingleton<IReferenceResolver, FileReferenceResolver>();
        serviceCollection.TryAddSingleton<IReferenceResolver, FolderReferenceResolver>();
        serviceCollection.TryAddSingleton<IReferenceResolver, FrameworkReferenceResolver>();
        serviceCollection.TryAddSingleton<IReferenceResolver, NuGetReferenceResolver>();
        serviceCollection.TryAddSingleton<IReferenceResolver, ProjectReferenceResolver>();
        serviceCollection.TryAddSingleton<IReferenceResolverFactory, ReferenceResolverFactory>();
        return serviceCollection;
    }
}
