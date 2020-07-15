// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using AutoMapper;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace IdentityServer4.EntityFramework.Mappers
{
    /// <summary>
    /// Extension methods to map to/from entity/model for API resources.
    /// </summary>
    public static class ApiResourceMappers
    {
        static ApiResourceMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ApiResourceMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        /// <summary>
        /// Maps an entity to a model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static Models.ApiResource ToModel(this TBLAPITEST entity)
        {

            var model = new Models.ApiResource()
            {
                Name = entity.NOMBRE,
                Scopes = entity.SCOPES.MapApiResource()
            };
            //return entity == null ? null : Mapper.Map<Models.ApiResource>(entity);
            return model;
        }

        public static ICollection<Models.Scope> MapApiResource(this List<ApiScope> lista)
        {
            List<Models.Scope> model = new List<Models.Scope>();

            foreach (var item in lista)
            {
                model.Add(
                    new Models.Scope
                    {
                        Name = item.Name,
                        DisplayName = item.DisplayName
                    });
            }
            return model;
        }



        /// <summary>
        /// Maps a model to an entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static TBLAPITEST ToEntity(this Models.ApiResource model)
        {
            return model == null ? null : Mapper.Map<TBLAPITEST>(model);
        }
    }
}