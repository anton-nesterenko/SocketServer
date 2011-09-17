﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocketService.Client;
using SocketService.Actions;
using SocketService.Messaging;
using SocketService.Data.Domain;
using SocketService.Data;
using SocketService.Response;
using SocketService.Net.Sockets;

namespace SocketService.Command
{

    [Serializable]
    public class LoginUserCommand : BaseCommand
    {
        private readonly string _username;
        private readonly Guid _clientId;
        public LoginUserCommand(Guid clientId, string username)
        {
            _clientId = clientId;
            _username = username;
        }

        public override void Execute()
        {
            if (UserActionEngine.Instance.LoginUser(_clientId, _username))
            {
                List<User> roomUsers = UserRepository.Instance.FindUsersByRoom("");

                // filter out our key
                var query = from user in roomUsers
                            where user.ClientKey != _clientId
                            select user.ClientKey;

                MSMQQueueWrapper.QueueCommand(
                    new SendObjectCommand(_clientId,
                        new LoginResponse() { Message = string.Format("Welcome {0}!", _username), Success = true })
                );

                MSMQQueueWrapper.QueueCommand(
                    new BroadcastObjectCommand(query.ToArray(), new ServerMessage("{0} has logged in.", _username))
                );

            }
            else
            {
                MSMQQueueWrapper.QueueCommand(
                    new SendObjectCommand(_clientId,
                        new LoginResponse() { Message = "Invalid username.", Success = false })
                );

            }
        }
    }
}