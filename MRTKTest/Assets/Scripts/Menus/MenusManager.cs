using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusManager : MonoBehaviour
{
    private GameObject MainMenu;
    private GameObject Conv_1_Menu;
    private GameObject Conv_2_Menu;
    void Start()
    {
        MainMenu = GameObject.Find("Main_Menu");
        Conv_1_Menu = GameObject.Find("Conv_1_Menu");
        Conv_2_Menu = GameObject.Find("Conv_2_Menu1");
        Conv_1_Menu.SetActive(false);
        Conv_2_Menu.SetActive(false);
    }

    // Update is called once per frame
    public void toMenu_of_conv_1()
    {
        MainMenu.SetActive(false);
        Conv_1_Menu.SetActive(true);
    }
    public void toMenu_of_conv_2()
    {
        MainMenu.SetActive(false);
        Conv_2_Menu.SetActive(true);
    }
    public void toMainfrom2()
    {
        MainMenu.SetActive(true);
        Conv_2_Menu.SetActive(false);
    }
    public void toMainfrom1()
    {
        MainMenu.SetActive(true);
        Conv_1_Menu.SetActive(false);
    }
}
