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
        public static Models.ApiResource ToModel(this ApiEntity entity)
        {

            var model = new Models.ApiResource()
            {
                Name = entity.Nombre,
                Scopes = entity.Alcances.MapApiResource()
            };
            //return entity == null ? null : Mapper.Map<Models.ApiResource>(entity);
            return model;
        }

        public static ICollection<Models.Scope> MapApiResource(this List<ApiAlcanceEntity> lista)
        {
            List<Models.Scope> model = new List<Models.Scope>();

            foreach (var item in lista)
            {
                model.Add(
                    new Models.Scope
                    {
                        Name = item.Nombre,
                        DisplayName = item.NombreMostrar
                    });
            }
            return model;
        }



        /// <summary>
        /// Maps a model to an entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static ApiEntity ToEntity(this Models.ApiResource model)
        {
            return model == null ? null : Mapper.Map<ApiEntity>(model);
        }
    }
}