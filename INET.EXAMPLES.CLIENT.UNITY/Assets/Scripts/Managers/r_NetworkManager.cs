using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using INET.NetworkClient;
using INET.NetworkPacket;

using Newtonsoft.Json;

public class r_NetworkManager : MonoBehaviour
{
    #region Functions

    private void Start()
    {
        r_NetworkClient.OnLog += OnLog;

        r_NetworkClient.InitializeClient("127.0.0.1", 5555, OnConnected, OnDisconnected);
    }

    private void OnLog(string _output)
    {
        Debug.Log(_output);
    }
    #endregion

    #region Callbacks
    private void OnConnected(int _connection_id, r_NetworkPacket _packet)
    {
        r_AuthPacket _auth = new r_AuthPacket
        {
            m_NickName = "Demo"
        };

        r_NetworkClient.Emit("Auth", JsonConvert.SerializeObject(_auth), RPCTARGET.SERVER);
    }

    private void OnDisconnected(int _connection_id, r_NetworkPacket _packet)
    {
        Debug.Log("Disconnected");
    }
    #endregion
}
