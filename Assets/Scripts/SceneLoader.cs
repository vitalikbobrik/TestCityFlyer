using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("BuilderScene");
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void ChooseAirPlane()
    {
        SceneManager.LoadScene("PlaneChoose");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
