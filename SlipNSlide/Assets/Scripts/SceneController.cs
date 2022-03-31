using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;


public class SceneController : MonoBehaviour
{
    public GameObject helpPanel;
    public Button playButton;
    public Button helpButton;
    public Button quitGame;
    public Button closeHelpPanel;

    //close window in webgl
    //taken from https://answers.unity.com/questions/1576906/close-tab-from-webgl-build.html
    [DllImport("__Internal")]
    private static extern void closewindow();


    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            //Add onclick listeners to buttons 
            playButton.onClick.AddListener(PlayButtonPressed);
            helpButton.onClick.AddListener(HelpButtonPressed);
            quitGame.onClick.AddListener(Quit);
            closeHelpPanel.onClick.AddListener(HelpButtonPressed);
        }else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            playButton.onClick.AddListener(PlayButtonPressed);
            quitGame.onClick.AddListener(Quit);
        }

    }

    public void Quit()
    {
        Application.Quit();
        closewindow();
    }

    //Loads the game scene which should be at buildindex 1 
    public void PlayButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void HelpButtonPressed() {

        //Check if helppanel is active and flip state
        if (!helpPanel.activeSelf) {
            helpPanel.SetActive(true);
        }
        else
        {
            helpPanel.SetActive(false);
        }
    }

    public void EndScene()
    {
        SceneManager.LoadScene(2);
    }

}
