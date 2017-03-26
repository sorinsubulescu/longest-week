using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMainMenuButton : MonoBehaviour {

    public GameObject settingsMenu;
    public GameObject primaryMenu;

    //This function is designed for the BACK TO MAIN MENU button. It hides the settings panel and shows the primary menu panel.

    public void BackToMainMenu()
    {      
        settingsMenu.SetActive(false);
        primaryMenu.SetActive(true);
    }
}
