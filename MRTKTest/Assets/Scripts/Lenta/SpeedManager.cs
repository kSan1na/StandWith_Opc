using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    private GameObject Move;
    private GameObject inverseMove;
    private Movie scriptMove;

    // Start is called before the first frame update
    public void zero()
    {
        Move = GameObject.Find("MOVE");
        Move.GetComponent<Movie>().speed_of_conv=0;
        Move = GameObject.Find("InverseMove");
        Move.GetComponent<ReverseMove>().speed_of_conv = 0;

    }
    public void speed_up()
    {
        Move = GameObject.Find("MOVE");
        Move.GetComponent<Movie>().speed_of_conv += 50;
        Move = GameObject.Find("InverseMove");
        Move.GetComponent<ReverseMove>().speed_of_conv +=50;

    }
    public void speed_down()
    {
        Move = GameObject.Find("MOVE");
        Move.GetComponent<Movie>().speed_of_conv -= 50;
        Move = GameObject.Find("InverseMove");
        Move.GetComponent<ReverseMove>().speed_of_conv -= 50;

    }
    public void restart()
    {
        Move = GameObject.Find("MOVE");
        Move.GetComponent<Movie>().speed_of_conv = 100;
        Move = GameObject.Find("InverseMove");
        Move.GetComponent<ReverseMove>().speed_of_conv = 100;

    }
}
