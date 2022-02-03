using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public void PressStart()
    {
        SceneManager.LoadScene("Game");
    }

    public void PressExit()
    {
        Application.Quit();
    }
}
