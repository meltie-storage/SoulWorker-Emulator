// Licensed under the MIT license. See LICENSE file in the project root folder for full license information.

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using SoulWorker.Framework.Logging;

namespace SoulWorker.LoginService.Network
{
    public class LoginNetwork
    {
        public ManualResetEvent threadManager = new ManualResetEvent(false);
        TcpListener listener;

        public bool Start(string host, int port)
        {
            try
            {
                listener = new TcpListener(IPAddress.Parse(host), port);
                listener.Start();

                return true;
            }
            catch (SocketException ex)
            {
                Log.Message(LogType.Error, "{0}", ex.Message);
                Log.Message();

                return false;
            }
        }

        public void AcceptConnectionThread()
        {
            new Thread(AcceptConnection).Start();
        }

        void AcceptConnection()
        {
            while (true)
            {
                Thread.Sleep(1);

                if (listener.Pending())
                {
                    threadManager.Reset();
                    listener.BeginAcceptSocket(new AsyncCallback(new LoginClass().Accept), listener);

                    threadManager.WaitOne();
                }
            }
        }
    }
}
