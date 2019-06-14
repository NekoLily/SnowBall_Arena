using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameObject : MonoBehaviour
{
    
    public void LoadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadGameMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
