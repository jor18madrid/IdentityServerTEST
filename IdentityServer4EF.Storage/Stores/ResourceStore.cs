﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IdentityServer4.EntityFramework.Stores
{
    /// <summary>
    /// Implementation of IResourceStore thats uses EF.
    /// </summary>
    /// <seealso cref="IdentityServer4.Stores.IResourceStore" />
    public class ResourceStore : IResourceStore
    {
        private readonly IConfigurationDbContext _context;
        private readonly ILogger<ResourceStore> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceStore"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentNullException">context</exception>
        public ResourceStore(IConfigurationDbContext context, ILogger<ResourceStore> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }

        /// <summary>
        /// Finds the API resource by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Task<ApiResource> FindApiResourceAsync(string name)
        {
            var query =
                from apiResource in _context.ApiResources
                where apiResource.Nombre == name
                select apiResource;

            var apis = query
                .Include(x => x.Secretos)
                .Include(x => x.Alcances)
                //.ThenInclude(s => s.UserClaims)
                //.Include(x => x.USERCLAIMS)
                //.Include(x => x.PROPIEDADES)
                .AsNoTracking();

            var api = apis.FirstOrDefault();

            if (api != null)
            {
                _logger.LogDebug("Found {api} API resource in database", name);
            }
            else
            {
                _logger.LogDebug("Did not find {api} API resource in database", name);
            }

            return Task.FromResult(api.ToModel());
        }

        /// <summary>
        /// Gets API resources by scope name.
        /// </summary>
        /// <param name="scopeNames"></param>
        /// <returns></returns>
        public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var names = scopeNames.ToArray();

            var query =
                from api in _context.ApiResources
                where api.Alcances.Where(x => names.Contains(x.Nombre)).Any()
                select api;

            var apis = query
                .Include(x => x.Secretos)
                .Include(x => x.Alcances)
                //.ThenInclude(s => s.UserClaims)
                //.Include(x => x.USERCLAIMS)
                //.Include(x => x.PROPIEDADES)
                .AsNoTracking();

            var results = apis.ToArray();
            var models = results.Select(x => x.ToModel()).ToArray();

            _logger.LogDebug("Found {scopes} API scopes in database", models.SelectMany(x => x.Scopes).Select(x => x.Name));

            return Task.FromResult(models.AsEnumerable());
        }

        /// <summary>
        /// Gets identity resources by scope name.
        /// </summary>
        /// <param name="scopeNames"></param>
        /// <returns></returns>
        public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            //var scopes = scopeNames.ToArray();

            //var query =
            //    from identityResource in _context.IdentityResources
            //    where scopes.Contains(identityResource.Name)
            //    select identityResource;

            //var resources = query
            //    .Include(x => x.UserClaims)
            //    .Include(x => x.Properties)
            //    .AsNoTracking();

            IEnumerable<Entities.IdentityResource> resources = Enumerable.Empty<Entities.IdentityResource>();


            var results = resources.ToArray();

            _logger.LogDebug("Found {scopes} identity scopes in database", results.Select(x => x.Name));

            return Task.FromResult(results.Select(x => x.ToModel()).ToArray().AsEnumerable());
            //return null;
        }

        /// <summary>
        /// Gets all resources.
        /// </summary>
        /// <returns></returns>
        public Task<Resources> GetAllResourcesAsync()
        {
            //var identity = _context.IdentityResources
            //  .Include(x => x.UserClaims);

            IEnumerable<Entities.IdentityResource> identity = Enumerable.Empty<Entities.IdentityResource>();

            var apis = _context.ApiResources
                .Include(x => x.Secretos)
                .Include(x => x.Alcances)
                //.ThenInclude(s => s.UserClaims)
                //.Include(x => x.USERCLAIMS)
                //.Include(x => x.PROPIEDADES)
                .AsNoTracking();

            var result = new Resources(
                identity.ToArray().Select(x => x.ToModel()).AsEnumerable(),
                apis.ToArray().Select(x => x.ToModel()).AsEnumerable());

            _logger.LogDebug("Found {scopes} as all scopes in database", result.IdentityResources.Select(x => x.Name).Union(result.ApiResources.SelectMany(x => x.Scopes).Select(x => x.Name)));

            return Task.FromResult(result);
            //return null;
        }
    }
}