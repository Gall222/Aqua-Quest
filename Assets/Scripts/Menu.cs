using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void StartFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToStart()
    {
        SceneManager.LoadScene("Start");
    }
    public void GoToOptions()
    {
        SceneManager.LoadScene("Options");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
