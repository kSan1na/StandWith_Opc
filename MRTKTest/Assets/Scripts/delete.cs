using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete : MonoBehaviour
{
    public GameObject cube;
    public float z;
    public Vector3 v;
    void Update()
    {   
        while (z < 12)
        {
            v = this.transform.position;
            z = this.transform.localPosition.z;
            Debug.Log(z);
        }
        Destroy(cube);
    }
}
