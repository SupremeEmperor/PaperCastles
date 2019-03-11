using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject manager;
    bool check;

    public void Start()
    {
        check = true;
    }

    public void Update()
    {
        if (check)
        {
            manager.GetComponent<GameManager>().setTurn(true);
            check = false;
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
