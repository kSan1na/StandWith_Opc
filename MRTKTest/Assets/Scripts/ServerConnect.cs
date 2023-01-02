using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Opc.UaFx.Client;
public class ServerConnect : MonoBehaviour
{
    
    public void GetValue()
    { 
        string opcUrl = "opc.tcp://127.0.0.1:49300";
        var client = new OpcClient(opcUrl);
        client.Connect();
        var speed = client.ReadNode("ns=2;i=2");
        string cont_speed;
        cont_speed = speed.ToString();
        client.Disconnect();
        Debug.Log(cont_speed);
    }
    public void SetValue()
    {
        string opcUrl = "opc.tcp://127.0.0.1:49300";
        var client = new OpcClient(opcUrl);
        client.Connect();
        int speed = 1;
        client.WriteNode("ns=2;i=2", speed);
        client.Disconnect();
    }
}
