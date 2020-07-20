// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


#pragma warning disable 1591

using System;

namespace IdentityServer4.EntityFramework.Entities
{
    public class SecretoEntity
    {
        public int SecretoId { get; set; }
        public string Descripcion { get; set; }
        public string Valor { get; set; }
        public DateTime? FechaExpiracion { get; set; }
        public string Tipo { get; set; } = "SharedSecret";
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}