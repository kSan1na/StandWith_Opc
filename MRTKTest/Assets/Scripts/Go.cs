using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Go : MonoBehaviour
{
    private GameObject ground;
    void Start()
    {
        ground = GameObject.Find("ground");
    }

    // Update is called once per frame
    public void minus()
    {
        ground.SetActive(false);
    }
}
