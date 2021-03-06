﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocketServer.Shared.Request;
using SocketServer.Command;

namespace SocketServer.Handler
{
    public class GetKeyParametersRequestHandler : IRequestHandler<GetKeyParametersRequest>
    {
        public void HandleRequest(GetKeyParametersRequest request, Guid state)
        {
            if (request != null)
            {
                MSMQQueueWrapper.QueueCommand(
                    new GetKeyParametersCommand(state)
                );

            }

        }

        public void HandleRequest(GetKeyParametersRequest request, Shared.Network.ClientConnection connection)
        {
            throw new NotImplementedException();
        }
    }
}
