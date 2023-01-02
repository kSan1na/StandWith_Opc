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
        Move.GetComponent<Movie>().speed = (float)(-1)/10;
        Move.GetComponent<Movie>().rb = lenta1;
        Move.GetComponent<Movie>().mt = mat;
        Move.GetComponent<Movie>().enabled = true;
        SetValue();
    }
    public void Stop()
    {
        Move.GetComponent<Movie>().speed_of_conv = 0;
        Move.GetComponent<Movie>().speed = 0;
        SetValue();
    }
    public void speed_up()
    {
        Move.GetComponent<Movie>().speed -= (float)(1) / 10;
        SetValue();
    }
    public void speed_down()
    {
        Move.GetComponent<Movie>().speed += (float)(1) / 10;
        SetValue();
    }
    void SetValue()
    {
        string opcUrl = "opc.tcp://127.0.0.1:49300";
        var client = new OpcClient(opcUrl);
        client.Connect();
        float speed = Move.GetComponent<Movie>().speed*(10);
        if (speed < 0)
        {
            speed = speed * -1;
        }
        client.WriteNode("ns=2;i=2", speed);
        client.Disconnect();
    }
}
