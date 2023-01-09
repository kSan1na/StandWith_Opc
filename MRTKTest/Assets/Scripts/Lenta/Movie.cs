using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movie : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public Material mt;
    public float speedOfConv;


    // Update is called once per frame
    void FixedUpdate()
    {
        mt.mainTextureOffset = new Vector2(0f,Time.time * speedOfConv * Time.deltaTime);
        Vector3 pos = rb.position;
        rb.position += Vector3.right * speed*(-1) * Time.fixedDeltaTime;
        rb.MovePosition(pos);

    }

}   
