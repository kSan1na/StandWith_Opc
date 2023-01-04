using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MRTK;
using Microsoft.MixedReality.Toolkit.Input;

public class AlarmLamp : MonoBehaviour
{
    public Light light;
    public Material AlarmColor;
    public Material NeytralColor;
    public GameObject lamp;
    private GameObject ServerConnect;
    private int flag = 0;
    // Update is called once per frame
    private void Start()
    {
        ServerConnect = GameObject.Find("ServerManager");
    }
    public void alarm()
    {
        switc();

        if (flag == 1)
        {
            ServerConnect.GetComponent<ServerConnect>().alarm_status = true;
            lamp.GetComponent<MeshRenderer>().material = AlarmColor;
            light.range = 1;
        }
        else
        {
            ServerConnect.GetComponent<ServerConnect>().alarm_status = false;
            lamp.GetComponent<MeshRenderer>().material = NeytralColor;
            light.range = 0;
        }
    }
    void switc()
    {
        if (flag == 0)
        {
            flag = 1;
        }
        else
        {
            flag = 0;
        }
        
    }
   
}
