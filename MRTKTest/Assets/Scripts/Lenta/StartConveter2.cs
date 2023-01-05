using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Opc.UaFx.Client;
public class StartConveter2 : MonoBehaviour
{
    public GameObject Move;
    public Rigidbody lenta2;
    public Material mat;
    public GameObject Lenta;
    private GameObject ServerScript;
    private GameObject AlarmLamp;
    private GameObject BarabanSpiner;
    private bool working_status;
    public void PUSK()
    {
        Lenta = GameObject.Find("lenta2");
        Move.GetComponent<MoveCon2>().speed_of_conv = (float)1;
        Move.GetComponent<MoveCon2>().speed = (float)(1) / 10;
        lenta2 = Lenta.GetComponent<Rigidbody>();
        Move.GetComponent<MoveCon2>().rb = lenta2;
        Move.GetComponent<MoveCon2>().mt = mat;
        Lenta.GetComponent<Rigidbody>().isKinematic = true;
        BarabanSpiner = GameObject.Find("BarabanManager");
        BarabanSpiner.GetComponent<BarabanSpiner>().speed_2 = Move.GetComponent<MoveCon2>().speed * 100;
        working_status = true;

    }
    public void Stop()
    {
        Move.GetComponent<MoveCon2>().speed_of_conv = 0;
        Move.GetComponent<MoveCon2>().speed = 0;
        BarabanSpiner.GetComponent<BarabanSpiner>().speed_2 = Move.GetComponent<MoveCon2>().speed * 100;
        working_status = false;
    }
    public void speed_up()
    {
        if (working_status)
        {
            Move.GetComponent<MoveCon2>().speed += (float)(1) / 10;
            BarabanSpiner.GetComponent<BarabanSpiner>().speed_2 = Move.GetComponent<MoveCon2>().speed * 100;
        }
    }
    public void speed_down()
    {
        if (working_status)
        {
            Move.GetComponent<MoveCon2>().speed -= (float)(1) / 10;
            BarabanSpiner.GetComponent<BarabanSpiner>().speed_2 = Move.GetComponent<MoveCon2>().speed * 100;
        }
        
    }
    public void EmergancyShotDown()
    {   
        Stop();
        AlarmLamp = GameObject.Find("AlartLampManager");
        ServerScript = GameObject.Find("ServerManager");
        bool alarm_status= ServerScript.GetComponent<ServerConnect>().alarm_status;
        if (alarm_status == false)
        {
            AlarmLamp.GetComponent<AlarmLamp>().alarm();
            ServerScript.GetComponent<ServerConnect>().alarm_status = true;
        }
    }

}
