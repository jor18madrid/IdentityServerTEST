// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#pragma warning disable 1591

using System.Collections.Generic;

namespace IdentityServer4.EntityFramework.Entities
{
    public class ApiAlcanceEntity
    {
        public int ApiAlcanceId { get; set; }
        public string Nombre { get; set; }
        public string NombreMostrar { get; set; }
        public string Descripcion { get; set; }
        public bool Requerido { get; set; }
        public bool Enfatizar { get; set; }
        public bool MostrarDocumentoDescubrimiento { get; set; } = true;

        public int ApiId { get; set; }
        public ApiEntity Api { get; set; }
    }
}