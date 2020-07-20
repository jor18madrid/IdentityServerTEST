// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;

namespace IdentityServer4.EntityFramework.Mappers
{
    /// <summary>
    /// Defines entity/model mapping for clients.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ClientMapperProfile : Profile
    {
        /// <summary>
        /// <see>
        ///     <cref>{ClientMapperProfile}</cref>
        /// </see>
        /// </summary>
        public ClientMapperProfile()
        {
            CreateMap<Entities.ClientProperty, KeyValuePair<string, string>>()
                .ReverseMap();

            CreateMap<Entities.ClienteEntity, Models.Client>()
                .ForMember(dest => dest.ProtocolType, opt => opt.Condition(srs => srs != null))
                .ReverseMap();

            CreateMap<Entities.ClienteOrigenCruzadoEntity, string>()
                .ConstructUsing(src => src.Origen)
                .ReverseMap()
                .ForMember(dest => dest.Origen, opt => opt.MapFrom(src => src));

            CreateMap<Entities.ClientIdPRestriction, string>()
                .ConstructUsing(src => src.Provider)
                .ReverseMap()
                .ForMember(dest => dest.Provider, opt => opt.MapFrom(src => src));

            CreateMap<Entities.ClientClaim, Claim>(MemberList.None)
                .ConstructUsing(src => new Claim(src.Type, src.Value))
                .ReverseMap();

            CreateMap<Entities.ClienteAlcanceEntity, string>()
                .ConstructUsing(src => src.Alcance)
                .ReverseMap()
                .ForMember(dest => dest.Alcance, opt => opt.MapFrom(src => src));

            CreateMap<Entities.ClienteUrlRedirigirCerrarSesionEntity, string>()
                .ConstructUsing(src => src.Url)
                .ReverseMap()
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src));

            CreateMap<Entities.ClienteUrlRedirigirEntity, string>()
                .ConstructUsing(src => src.Url)
                .ReverseMap()
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src));

            CreateMap<Entities.ClienteTipoConcesionEntity, string>()
                .ConstructUsing(src => src.TipoConcesion)
                .ReverseMap()
                .ForMember(dest => dest.TipoConcesion, opt => opt.MapFrom(src => src));

            CreateMap<Entities.ClienteSecretoEntity, Models.Secret>(MemberList.Destination)
                .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null))
                .ReverseMap();
        }
    }
}