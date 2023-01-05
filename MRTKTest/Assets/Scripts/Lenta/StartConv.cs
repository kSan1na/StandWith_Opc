using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Opc.UaFx.Client;
using MRTK;
public class StartConv : MonoBehaviour
{
    public GameObject Move;
    public Rigidbody lenta1;
    public Material mat;
    public GameObject Stend;
    public Rigidbody Aboba;
    public GameObject Lenta;
    private GameObject ServerScript;
    private GameObject AlarmLamp;
    private GameObject BarabanSpiner;
    private bool working_status = false;
    
   

    public void PUSK()
    {

        Stend = GameObject.Find("unitystend");
        Lenta = GameObject.Find("lenta1");
        Stend.GetComponent<Rigidbody>().isKinematic=true;
        Stend.GetComponent<BoxCollider>().enabled = false;
        lenta1 = Lenta.GetComponent<Rigidbody>();
        Move = GameObject.Find("Moving_CONV_1");
        Move.GetComponent<Movie>().speed_of_conv = (float)1;
        Move.GetComponent<Movie>().speed = (float)(1)/10;
        Move.GetComponent<Movie>().rb = lenta1;
        Move.GetComponent<Movie>().mt = mat;
        Move.GetComponent<Movie>().enabled = true;
        BarabanSpiner = GameObject.Find("BarabanManager");
        BarabanSpiner.GetComponent<BarabanSpiner>().speed_1 = Move.GetComponent<Movie>().speed * 480;
        working_status = true;
        
        
    }
    public void Stop()
    {
        Move.GetComponent<Movie>().speed_of_conv = 0;
        Move.GetComponent<Movie>().speed = 0;
        BarabanSpiner.GetComponent<BarabanSpiner>().speed_1 = Move.GetComponent<Movie>().speed * 480;
        working_status = false;

    }
    public void speed_up()
    {
        if (working_status)
        {
            Move.GetComponent<Movie>().speed_of_conv +=1;
            Move.GetComponent<Movie>().speed += (float)(1) / 10;
            BarabanSpiner.GetComponent<BarabanSpiner>().speed_1 = Move.GetComponent<Movie>().speed * 480;
        }
    }
    public void speed_down()
    {
        if (working_status)
        {
            Move.GetComponent<Movie>().speed_of_conv -= 1;
            Move.GetComponent<Movie>().speed -= (float)(1) / 10;
            BarabanSpiner.GetComponent<BarabanSpiner>().speed_1 = Move.GetComponent<Movie>().speed * 480;
        }
    }
    public void EmergancyShotDown()
    {
        Stop();
        AlarmLamp = GameObject.Find("AlartLampManager");
        ServerScript = GameObject.Find("ServerManager");
        ServerScript.GetComponent<ServerConnect>().SetSpeedConv_1();
        bool alarm_status = ServerScript.GetComponent<ServerConnect>().alarm_status;
        if (alarm_status == false)
        {
            AlarmLamp.GetComponent<AlarmLamp>().alarm();
            ServerScript.GetComponent<ServerConnect>().alarm_status = true;
        }
    }
}
