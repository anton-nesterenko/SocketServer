﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocketService.Crypto;

namespace SocketService.Request
{
    [Serializable]
    public class GetCentralAuthorityRequest 
    {
        public CentralAuthority CentralAuthority
        {
            get;
            set;
        }
    }
}