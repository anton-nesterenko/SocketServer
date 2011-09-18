﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace SocketService.Framework.ServiceHandlerLib
{
    [Serializable()]
    public abstract class BaseHandler<T, P> : IServiceHandler where T : class
    {
        public bool HandleRequest(object request, object state)
        {
            return HandleRequest(request as T, (P)state);
        }

        public abstract bool HandleRequest(T request, P state);
    }
}