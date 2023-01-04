using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Opc.UaFx.Client;
public class BuckerPlatformMoving : MonoBehaviour
{
    public Rigidbody rb;
    private GameObject ServerScript;
    private Vector3 startpos;
    private float speed=0.1F;
    private float minY;
    private float maxY;
    private int flag = 0;
    public void Get_Start_Pos()
    {
        ServerScript = GameObject.Find("ServerManager");
        if (flag == 0)
        {
            startpos = rb.position;
            maxY = startpos[1] + 0.1F;
            minY = startpos[1] - 0.3F;
            flag = 1;
            ServerScript.GetComponent<ServerConnect>().move_of_bunker = "Moving Up";
        }
    }

    // Update is called once per frame
    
    void FixedUpdate()
    {
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
        
    }
    public void Stop()
    {
        flag = 0;
        ServerScript.GetComponent<ServerConnect>().move_of_bunker = "stay";
    }
   

}
