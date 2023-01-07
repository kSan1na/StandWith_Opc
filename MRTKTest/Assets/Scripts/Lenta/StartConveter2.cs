using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
public class StartConveter2 : MonoBehaviour
{
    public GameObject Move;
    public Rigidbody lenta2;
    public Material mat;
    public GameObject Lenta;
    private GameObject ServerScript;
    private GameObject AlarmLamp;
    private GameObject BarabanSpiner;
    private bool working_status = false;
    public GameObject speedBar2;
    private float StartspeedBarStatus = 0.5f;
    private float currentSpeedOfBar;
    

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
        speedBar2.GetComponent<SliderSounds>().playTickSounds = true;
        Move.GetComponent<MoveCon2>().speed = 0.1f;
        working_status = true;
    }
    public void Stop()
    {
        Move.GetComponent<MoveCon2>().speed_of_conv = 0;
        Move.GetComponent<MoveCon2>().speed = 0;
        BarabanSpiner.GetComponent<BarabanSpiner>().speed_2 = Move.GetComponent<MoveCon2>().speed * 100;
        working_status = false;
        speedBar2.GetComponent<PinchSlider>().SliderValue = (Move.GetComponent<MoveCon2>().speed / 2) + 0.5f;
        speedBar2.GetComponent<SliderSounds>().playTickSounds = false;
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
            
        }
    }

    public void speed_bar()
    {
        //max = 1;
        //min = -1;


        currentSpeedOfBar = speedBar2.GetComponent<PinchSlider>().SliderValue;
        if (currentSpeedOfBar != StartspeedBarStatus)
        {
            if (working_status) {
                float deltaSpeed = currentSpeedOfBar - StartspeedBarStatus;
                Move.GetComponent<MoveCon2>().speed = deltaSpeed * 2;
                BarabanSpiner.GetComponent<BarabanSpiner>().speed_2 = Move.GetComponent<MoveCon2>().speed * 480;
                Move.GetComponent<MoveCon2>().speed_of_conv = deltaSpeed * 20; 
            }
            else
            {
                speedBar2.GetComponent<PinchSlider>().SliderValue = 0.5f;
            }
        }

    }
}
