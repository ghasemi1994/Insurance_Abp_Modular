﻿

using Application.Utility.Models;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.Utility.Extensions;

public static class MappingExtensions
{
    public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize)
       where TDestination : class
         => PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize);

    public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, AutoMapper.IConfigurationProvider configuration,
        CancellationToken cancellationToken = default)
        where TDestination : class
        => queryable.ProjectTo<TDestination>(configuration)
        .AsNoTracking().ToListAsync(cancellationToken);
}
