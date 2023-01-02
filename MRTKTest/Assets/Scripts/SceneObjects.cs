using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObjects : MonoBehaviour
{
    public GameObject model;
    void Start()
    {
        model.SetActive(false);
    }

    // Update is called once per frame
    public void showModel()
    {
        model.SetActive(true);
    }
}
