using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {
    public GameObject mainmenupanel;
    public GameObject creditspanel;
    public GameObject optionspanel;

    public void mainmenu()
    {
        creditspanel.SetActive(false);
        optionspanel.SetActive(false);
        mainmenupanel.SetActive(true);
    }

    public void credits()
    {
        creditspanel.SetActive(true);
        optionspanel.SetActive(false);
        mainmenupanel.SetActive(false);
    }
    public void options()
    {
        creditspanel.SetActive(false);
        optionspanel.SetActive(true);
        mainmenupanel.SetActive(false);
    }
}
