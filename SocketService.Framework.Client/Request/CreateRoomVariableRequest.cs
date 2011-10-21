﻿using System;
using SocketService.Framework.Client.SharedObjects;

namespace SocketService.Framework.Client.Request
{
    [Serializable]
    public class CreateRoomVariableRequest
    {
        public int ZoneId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the room.
        /// </summary>
        /// <value>
        /// The room.
        /// </value>
        public int RoomId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the variable.
        /// </summary>
        /// <value>
        /// The name of the variable.
        /// </value>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public SharedObject Value
        {
            get;
            set;
        }
    }
}
