using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuckerPlatformMoving : MonoBehaviour
{
    public Rigidbody rb;
    private Vector3 startpos;
    private float speed=0.1F;
    private float minY;
    private float maxY;
    private int flag = 0;
    public void Get_Start_Pos()
    {
        startpos = rb.position;
        maxY = startpos[1] + 0.1F;
        minY = startpos[1] - 0.3F;

    }

    // Update is called once per frame
    public void MoveUp()
    {
        flag = 1;
        
    }
    public void MoveDown()
    {
        flag = -1;
    }
    void FixedUpdate()
    {
        Vector3 corrent_pos = startpos;
        if (flag == 1)
        {
            if (rb.position[1] < maxY)
            {

                rb.position += Vector3.up * speed * Time.fixedDeltaTime;
            }
            else
            {
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
            }
        }
    }
    public void Stop()
    {
        flag = 0;
    }
}
