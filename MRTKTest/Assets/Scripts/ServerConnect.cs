using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Opc.UaFx.Client;


public class ServerConnect : MonoBehaviour
{
    public OpcClient client;
    private float speed=0;
    private float server_speed=0;
    [SerializeField] private Moving Conveyer1;
    [SerializeField]  private Moving Conveyer2;
    private float speed_2=0;
    internal bool alarm_status = false;
    internal string move_of_bunker = "stay";
    private float serv_speed_2 = 0;
    private bool alarm_serv_status = false;
    private string move_of_bunker_serv = "stay";
    
    private void Start()
    {
        string opcUrl = "opc.tcp://192.168.0.148:49300";
        client = new OpcClient(opcUrl);
        client.Connect();
    }
    void GetValue()
    { 
        var current_server_speed_1 = client.ReadNode("ns=2;i=2");
        var current_server_speed_2 = client.ReadNode("ns=2;i=3");
        var current_server_alarm_status = client.ReadNode("ns=2;i=4");
        var current_server_buncer_status= client.ReadNode("ns=2;i=5");
        server_speed = float.Parse(current_server_speed_1.ToString());
        serv_speed_2 = float.Parse(current_server_speed_2.ToString());
        alarm_serv_status = bool.Parse(current_server_alarm_status.ToString());
        move_of_bunker_serv = current_server_buncer_status.ToString();
    }
    public void SetSpeedConv_1()
    {
        
        client.WriteNode("ns=2;i=2", speed);
    }
    public void SetSpeedConv_2()
    {
        
        client.WriteNode("ns=2;i=3", speed_2);
    }
    void SetAlarmStatus()
    {
        client.WriteNode("ns=2;i=4", alarm_status);
    }
    void Set_Bunker_Status()
    {
        client.WriteNode("ns=2;i=5", move_of_bunker);
    }
    private void Update()
    {
        GetValue();
        if (server_speed != speed)
        {
            SetSpeedConv_1();
            server_speed = speed;
        }
        if (serv_speed_2 != speed_2)
        {
     
            SetSpeedConv_2();
            serv_speed_2 = speed_2;
        }
        if (alarm_status != alarm_serv_status)
        {
            SetAlarmStatus();
        }
        if (move_of_bunker != move_of_bunker_serv)
        {
            Set_Bunker_Status();
            move_of_bunker_serv = move_of_bunker;
        }
        speed_2 = Conveyer2._speed;
        speed = Conveyer1._speed;

    }
    private void OnDisable()
    {
        client.WriteNode("ns=2;i=2", 0);
        client.WriteNode("ns=2;i=3", 0);
        client.WriteNode("ns=2;i=4", false);
        client.WriteNode("ns=2;i=5", "stay");
        client.Disconnect();
    }
}
