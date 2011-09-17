﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocketService.Framework.Actions;
using SocketService.Framework.Messaging;
using SocketService.Framework.Data.Domain;
using SocketService.Framework.Data;
using SocketService.Framework.Response;

namespace SocketService.Framework.Command
{
    [Serializable]
    public class ChangeRoomCommand : BaseMessageHandler
    {
        private readonly Guid _clientId;
        private readonly string _roomName;
        private readonly bool _addUser;
        public ChangeRoomCommand(Guid clientId, string roomName, bool addUser)
        {
            _clientId = clientId;
            _roomName = roomName;
            _addUser = addUser;
        }

        public override void Execute()
        {
            RoomActionEngine.Instance.CreateRoom(_roomName);

            if (_addUser)
            {
                User user = UserRepository.Instance.FindUserByClientKey(_clientId);

                if (user != null && user.Room != _roomName)
                {
                    string oldRoom = user.Room;

                    UserActionEngine.Instance.ChangeClientRoom(_clientId, _roomName);

                    // now send greeting to all in room
                    List<User> roomUsers = UserRepository.Instance.FindUsersByRoom(_roomName);
                    var query = from u in roomUsers
                                where u.ClientKey != _clientId
                                select u.ClientKey;

                    MSMQQueueWrapper.QueueCommand(
                        new BroadcastObjectCommand(query.ToArray(),
                            new ServerMessage("{0} has entered the room.", user.UserName))
                    );

                    roomUsers = UserRepository.Instance.FindUsersByRoom(oldRoom);
                    query = from u in roomUsers
                            where u.ClientKey != _clientId
                            select u.ClientKey;

                    // tell users in old room that this user left
                    MSMQQueueWrapper.QueueCommand(
                        new BroadcastObjectCommand(query.ToArray(),
                            new ServerMessage("{0} has left the room.", user.UserName))
                    );

                    // tell user that they entered the new room
                    MSMQQueueWrapper.QueueCommand(
                        new SendObjectCommand(_clientId,
                            new ServerMessage("You have entered {0}.", _roomName))
                    );
                }
            }
        }
    }
}