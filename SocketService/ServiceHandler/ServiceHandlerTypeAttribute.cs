﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace SocketService.ServiceHandler
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false)]
    public class ServiceHandlerTypeAttribute : ExportAttribute, IServiceHandlerType
    {
        public ServiceHandlerTypeAttribute(Type handlerType)
        {
            HandlerType = handlerType;
        }

        #region IHandlerType Members

        public Type HandlerType
        {
            get;
            set;
        }

        #endregion
    }
}