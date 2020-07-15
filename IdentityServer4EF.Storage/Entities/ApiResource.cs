// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#pragma warning disable 1591

using System;
using System.Collections.Generic;

namespace IdentityServer4.EntityFramework.Entities
{
    public class TBLAPITEST
    {
        public int APIID { get; set; }
        public bool HABILITAR { get; set; } = true;
        public string NOMBRE { get; set; }
        public string NOMBREMOSTRAR { get; set; }
        public string DESCRIPCION { get; set; }
        public List<ApiSecret> SECRETS { get; set; }
        public List<ApiScope> SCOPES { get; set; }
        public List<ApiResourceClaim> USERCLAIMS { get; set; }
        public List<ApiResourceProperty> PROPIEDADES { get; set; }
        public DateTime FECHACREACION { get; set; } = DateTime.Now;
        public DateTime? FECHAMODIFICACION { get; set; }
        public DateTime? FECHAULTIMOACCESO { get; set; }
        public bool NOEDITABLE { get; set; }
    }
}
