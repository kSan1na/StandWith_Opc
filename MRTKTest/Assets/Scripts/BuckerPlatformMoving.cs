using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
public class BuckerPlatformMoving : MonoBehaviour
{
    public Rigidbody rb;
    private GameObject ServerScript;
    private Vector3 startpos;
    private float speed=0.1F;
    private float minY;
    private float maxY;
    private int flag = 0;
    private GameObject marker;
    private bool isFirst = true;
    private int _previosFlag=1;
    private void Get_Start_Pos()
    {   
        marker = GameObject.Find("BuckerMarket");
        ServerScript = GameObject.Find("ServerManager");
        if (flag == 0)
        {
            startpos = rb.position;
            maxY = startpos[1] + 0.2F;
            minY = startpos[1] - 0.8F;
            flag = 1;
            ServerScript.GetComponent<ServerConnect>().move_of_bunker = "Moving Up";
            isFirst = false;
        }
    }
    public void Pusk()
    {
        if (isFirst)
        {
            Get_Start_Pos();
            
        }
        flag = _previosFlag;
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        float deltaFromMax = maxY - rb.position[1];
        if (flag == 1)
        {
            if (rb.position[1] < maxY)
            {

                rb.position += Vector3.up * speed * Time.fixedDeltaTime;
            }
            else
            {
                ServerScript.GetComponent<ServerConnect>().move_of_bunker = "Moving Down";
                flag = -1;
                
            }
        }   
        if (flag == -1)
        {
            if (rb.position[1] > minY)
            {
                rb.position += Vector3.down * speed * Time.fixedDeltaTime;
            }
            else
            {
                flag = 1;
                ServerScript.GetComponent<ServerConnect>().move_of_bunker = "Moving Up";
            }
        }
        if(flag!=0) marker.GetComponent<PinchSlider>().SliderValue = 1-deltaFromMax / 1f;
        
    }
    public void Stop()
    {
        _previosFlag = flag;
        flag = 0;
        ServerScript.GetComponent<ServerConnect>().move_of_bunker = "stay";
    }
    

}
