using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour {

    public GameObject primaryMenu;
    public GameObject settingsMenu;

    //This function is designed for the settings button. It hides the primary menu panel and shows the settings panel.

	public void SettingsMenu()
    {
        primaryMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
}
