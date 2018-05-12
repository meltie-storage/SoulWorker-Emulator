// Licensed under the MIT license. See LICENSE file in the project root folder for full license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;

using SoulWorker.Framework.Database;
using SoulWorker.Framework.Logging;

namespace SoulWorker.LoginService.Network
{
    public class LoginClass
    {
        // public static Account account { get; set; }
        public static LoginNetwork servers;
        //public SRP6 SecureRemotePassword { get; set; }
        public Socket clientSocket;
        byte[] DataBuffer = new byte[0x000]; // need to find real byte

        public LoginClass()
        {
            // account = new Account();
            // SecureRemotePassword = new SRP6();   
        }

        void HandleLoginData(byte[] data)
        {
            
        }

        public void HandleAuthenticationLoginChallenge()
        {
            Log.Message(LogType.Normal, "AuthenticationLoginChallenge");

            // Placeholder for login structure - still unknown.
        }

        public void Accept(IAsyncResult ars)
        {
            clientSocket = (ars.AsyncState as TcpListener).EndAcceptSocket(ars);
            servers.threadManager.Set();

            clientSocket.BeginReceive(DataBuffer, 0, DataBuffer.Length, SocketFlags.None, Receive, clientSocket);
        }

        public void Receive(IAsyncResult ars)
        {
            try
            {
                var handler = ars.AsyncState as Socket;
                var receiveBytes = clientSocket.EndReceive(ars);

                if (receiveBytes != 0)
                {
                    // HandleServerData(DataBuffer);

                    clientSocket.BeginReceive(DataBuffer, 0, DataBuffer.Length, SocketFlags.None, Receive, handler);
                }
                else
                    clientSocket.Close();
            }
            catch (Exception ex)
            {
                Log.Message(LogType.Error, "{0}", ex.Message);
            }
        }
    }
}
