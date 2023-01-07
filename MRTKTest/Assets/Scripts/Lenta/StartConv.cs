using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
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
    public  GameObject speedBar;
    private float StartspeedBarStatus=0.5f;
    private float currentSpeedOfBar;
    private float max_speed = 1;
    private float min_speed = -1;
    public void PUSK()
    {

        Stend = GameObject.Find("unitystend");
        Lenta = GameObject.Find("lenta1");
        Stend.GetComponent<Rigidbody>().isKinematic=true;
        Stend.GetComponent<BoxCollider>().enabled = false;
        lenta1 = Lenta.GetComponent<Rigidbody>();
        Move = GameObject.Find("Moving_CONV_1");
        Move.GetComponent<Movie>().speed = (float)(1)/10;
        Move.GetComponent<Movie>().speed_of_conv = 1;
        Move.GetComponent<Movie>().rb = lenta1;
        Move.GetComponent<Movie>().mt = mat;
        Move.GetComponent<Movie>().enabled = true;
        BarabanSpiner = GameObject.Find("BarabanManager");
        BarabanSpiner.GetComponent<BarabanSpiner>().speed_1 = Move.GetComponent<Movie>().speed * 480;
        working_status = true;
        speedBar.GetComponent<PinchSlider>().SliderValue = (Move.GetComponent<Movie>().speed / 2)+0.5f;
        speedBar.GetComponent<SliderSounds>().playTickSounds = true;

    }
    public void Stop()
    {
        Move.GetComponent<Movie>().speed_of_conv = 0;
        Move.GetComponent<Movie>().speed = 0;
        BarabanSpiner.GetComponent<BarabanSpiner>().speed_1 = Move.GetComponent<Movie>().speed * 480;
        working_status = false;
        speedBar.GetComponent<PinchSlider>().SliderValue = (Move.GetComponent<Movie>().speed / 2) + 0.5f;
        speedBar.GetComponent<SliderSounds>().playTickSounds = false;
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
            
        }
     
    }
    public void speed_bar()
    {
        //max = 1;
        //min = -1;
        
        currentSpeedOfBar=speedBar.GetComponent<PinchSlider>().SliderValue;
        if (currentSpeedOfBar != StartspeedBarStatus)
        {
            if (working_status)
            {
                float deltaSpeed = currentSpeedOfBar - StartspeedBarStatus;
                Move.GetComponent<Movie>().speed = deltaSpeed * 2;
                BarabanSpiner.GetComponent<BarabanSpiner>().speed_1 = Move.GetComponent<Movie>().speed * 480;
                Move.GetComponent<Movie>().speed_of_conv = deltaSpeed * 20;
            }
            else
            {
                speedBar.GetComponent<PinchSlider>().SliderValue = 0.5f;
            }
        }
        
     }
}
