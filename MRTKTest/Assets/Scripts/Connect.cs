using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using Microsoft.MixedReality.Toolkit.Input;
using System.Linq;

public class Connect : MonoBehaviour
{
    public float speed;
    private GameObject Speed;
    private GameObject Move;
    public void Update()
    {

        String line;


        StreamReader sr = new StreamReader("C:\\Users\\oleck\\PycharmProjects\\pythonProject8\\Speed.txt");

        line = sr.ReadLine();
        
        while (line != null)
        {
            bool a = float.TryParse(line, out speed);
           

            line = sr.ReadLine();
        }
        speed = speed * (float)0.01;
        sr.Close();
        Move = GameObject.Find("Move");
        Move.GetComponent<Movie>().speed=speed;
    }   

}