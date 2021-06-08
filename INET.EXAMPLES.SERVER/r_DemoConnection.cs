using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;

namespace INET.EXAMPLES.SERVER
{
    public class r_DemoConnection
    {
        #region Variables
        public string m_Nickname { get; set; }
        public TcpClient m_Socket { get; set; }
        #endregion

        #region Functions
        public r_DemoConnection(string _nickname, TcpClient _socket)
        {
            this.m_Nickname = _nickname;
            this.m_Socket = _socket;
        }

        public void Print()
        {
            Console.WriteLine($"[DATA] {m_Nickname}");
        }
        #endregion
    }
}
