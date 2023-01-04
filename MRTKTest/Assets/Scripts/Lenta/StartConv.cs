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
        
        
    }
    public void Stop()
    {
        Move.GetComponent<Movie>().speed_of_conv = 0;
        Move.GetComponent<Movie>().speed = 0;
       
    }
    public void speed_up()
    {
        Move.GetComponent<Movie>().speed += (float)(1) / 10;
        
    }
    public void speed_down()
    {
        Move.GetComponent<Movie>().speed -= (float)(1) / 10;
        
    }
}
