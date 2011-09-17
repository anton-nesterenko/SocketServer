﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SocketService.Request;
using System.Security.Cryptography;
using SocketService.Crypto;
using System.IO;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using SocketService.Serial;
using System.IO.Compression;
using SocketService.Net;
using SocketService.Messaging;

namespace SocketService
{
    public partial class ServerControlForm : Form
    {
        private readonly SocketManager serverManager = new SocketManager();
        private readonly MessageServer messageServer = new MessageServer();

        public ServerControlForm()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            messageServer.Start();
            serverManager.StartServer(4000);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            serverManager.StopServer();
            messageServer.Stop();
        }

        private void ServerControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            serverManager.StopServer();
            messageServer.Stop();
        }

    }
}