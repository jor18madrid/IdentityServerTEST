﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


#pragma warning disable 1591

namespace IdentityServer4.EntityFramework.Entities
{
    public class ClientProperty : Property
    {
        public int ClientId { get; set; }
        public Clientes Client { get; set; }
    }
}