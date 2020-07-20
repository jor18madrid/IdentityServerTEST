// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#pragma warning disable 1591

using System;
using System.Collections.Generic;

namespace IdentityServer4.EntityFramework.Entities
{
    public class ApiEntity
    {
        public int ApiId { get; set; }
        public bool Habilitar { get; set; } = true;
        public string Nombre { get; set; }
        public string NombreMostrar { get; set; }
        public string Descripcion { get; set; }
        public List<ApiSecretoEntity> Secretos { get; set; }
        public List<ApiAlcanceEntity> Alcances { get; set; }
        public DateTime FECHACREACION { get; set; } = DateTime.Now;
        public DateTime? FECHAMODIFICACION { get; set; }
        public DateTime? FechaUltimoAcceso { get; set; }
        public bool NoEditable { get; set; }
    }
}
