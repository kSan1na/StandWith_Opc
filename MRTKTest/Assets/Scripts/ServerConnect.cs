using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Opc.UaFx.Client;


public class ServerConnect : MonoBehaviour
{
    public OpcClient client;
    private float speed=0;
    private float server_speed=0;
    private GameObject MoveScript_1;
    private GameObject MoveScript_2;
    private float speed_2=0;
    internal bool alarm_status = false;
    internal string move_of_bunker = "stay";
    private float serv_speed_2 = 0;
    private bool alarm_serv_status = false;
    private string move_of_bunker_serv = "stay";

    private void Start()
    {
        string opcUrl = "opc.tcp://127.0.0.1:49300";
        client = new OpcClient(opcUrl);
        MoveScript_1 = GameObject.Find("Moving_CONV_1");
        MoveScript_2 = GameObject.Find("Moving_CONV_2");
        client.Connect();
    }
    void GetValue()
    { 
        var current_server_speed_1 = client.ReadNode("ns=2;i=2");
        var current_server_speed_2 = client.ReadNode("ns=2;i=3");
        var current_server_alarm_status = client.ReadNode("ns=2;i=4");
        var current_server_buncer_status=
        server_speed = float.Parse(current_server_speed_1.ToString());
        serv_speed_2 = float.Parse(current_server_speed_2.ToString());
        alarm_serv_status = bool.Parse(current_server_alarm_status.ToString());
        move_of_bunker_serv = current_server_buncer_status.ToString();
    }
    public void SetSpeedConv_1()
    {
        speed = MoveScript_1.GetComponent<Movie>().speed;
        client.WriteNode("ns=2;i=2", speed);
    }
    public void SetSpeedConv_2()
    {
        speed_2 = MoveScript_2.GetComponent<MoveCon2>().speed;
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
            MoveScript_1.GetComponent<Movie>().speed = server_speed;
            speed = server_speed;
        }
        if (serv_speed_2 != speed_2)
        {
            MoveScript_2.GetComponent<MoveCon2>().speed = server_speed ;
            speed_2 = serv_speed_2;
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
