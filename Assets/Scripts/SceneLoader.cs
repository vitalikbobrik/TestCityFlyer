using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void  CubesCount(int cube)
    {
        NumberOfCubes.m_numberOfCubes = cube;
    }

    public void ThisLevel(int level)
    {
        CurrentLevel.m_Level = level;
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ReloadLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void ChooseAirPlane()
    {
        SceneManager.LoadScene("PlaneChoose");
    }

    public void ChooseLevel()
    {
        SceneManager.LoadScene("ChooseLevel");
    }

    public void LoadRecords()
    {
        SceneManager.LoadScene("Records");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
   
}
