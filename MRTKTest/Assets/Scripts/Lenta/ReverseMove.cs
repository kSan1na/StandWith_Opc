using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseMove : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public Material mt;
    public int speed_of_conv;


    // Update is called once per frame
    void FixedUpdate()
    {
        mt.mainTextureOffset = new Vector2(0f, Time.time * speed_of_conv * Time.deltaTime);
        Vector3 pos = rb.position;
        rb.position += Vector3.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(pos);

    }

}   
