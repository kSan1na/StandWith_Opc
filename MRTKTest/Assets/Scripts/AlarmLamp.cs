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
    private int flag = 0;
    // Update is called once per frame
    public void alarm()
    {
        switc();

        if (flag == 1)
        {
            lamp.GetComponent<MeshRenderer>().material = AlarmColor;
            light.range = 1;
        }
        else
        {
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
