using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;

using INET.NetworkServer;
using INET.NetworkPacket;
using INET.EXAMPLES.SERVER.Packets;

using Newtonsoft.Json;

namespace INET.EXAMPLES.SERVER
{
    public class r_DemoServer
    {
        #region Variables
        public Dictionary<int, r_DemoConnection> m_Players = new Dictionary<int, r_DemoConnection>();
        #endregion

        #region Functions
        public r_DemoServer()
        {
            r_NetworkServer.OnPlayerConnected += OnPlayerConnected;
            r_NetworkServer.OnPlayerDisconnected += OnPlayerDisconnected;

            r_NetworkCallbackHandler.RegisterCallback("Log", OnLog);
            r_NetworkCallbackHandler.RegisterCallback("Alert", OnAlert);
            r_NetworkCallbackHandler.RegisterCallback("Error", OnError);
            r_NetworkCallbackHandler.RegisterCallback("Auth", (_id, _packet) =>
            {
                r_AuthPacket _auth = (r_AuthPacket)JsonConvert.DeserializeObject<r_AuthPacket>(_packet.m_PacketData);
                m_Players[_id].m_Nickname = _auth.m_NickName;

                Console.WriteLine($"Set Auth : " + _auth.m_NickName);
            });
        }

        public void OnPlayerConnected(int _id, TcpClient _socket)
        {
            if (m_Players.ContainsKey(_id)) return;

            m_Players.Add(_id, new r_DemoConnection("", _socket));
        }

        public void OnPlayerDisconnected(int _id)
        {
            if (!m_Players.ContainsKey(_id)) return;

            m_Players.Remove(_id);
        }

        private void OnLog(int _connection_id, r_NetworkPacket _packet) => Console.WriteLine($"[LOG]{_packet.m_PacketData}");
        private void OnAlert(int _connection_id, r_NetworkPacket _packet) => Console.WriteLine($"[ALERT]{_packet.m_PacketData}");
        private void OnError(int _connection_id, r_NetworkPacket _packet) => Console.WriteLine($"[ERROR]{_packet.m_PacketData}");

        #endregion
    }
}
