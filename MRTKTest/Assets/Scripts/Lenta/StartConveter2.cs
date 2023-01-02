using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartConveter2 : MonoBehaviour
{
    public GameObject Move;
    public Rigidbody lenta2;
    public Material mat;
    public GameObject Lenta;
    public void PUSK()
    {
        Lenta = GameObject.Find("lenta2");
        Move.GetComponent<MoveCon2>().speed_of_conv = (float)1;
        Move.GetComponent<MoveCon2>().speed = (float)(1) / 10;
        lenta2 = Lenta.GetComponent<Rigidbody>();
        Move.GetComponent<MoveCon2>().rb = lenta2;
        Move.GetComponent<MoveCon2>().mt = mat;
        Lenta.GetComponent<Rigidbody>().isKinematic = true;
    }
    public void Stop()
    {
        Move.GetComponent<MoveCon2>().speed_of_conv = 0;
        Move.GetComponent<MoveCon2>().speed = 0;
        Lenta.GetComponent<Rigidbody>().isKinematic = false;
    }
    public void speed_up()
    {
        Move.GetComponent<MoveCon2>().speed += (float)(1) / 10;
    }
    public void speed_down()
    {
        Move.GetComponent<MoveCon2>().speed -= (float)(1) / 10;
    }
}
