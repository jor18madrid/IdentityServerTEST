﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


#pragma warning disable 1591

using System.ComponentModel.DataAnnotations;

namespace IdentityServer4.EntityFramework.Entities
{
    public class ClienteOrigenCruzadoEntity
    {
        public int ClienteOrigenCruzadoId { get; set; }
        public string Origen { get; set; }

        public int ClienteId { get; set; }
        public ClienteEntity Cliente { get; set; }
    }
}