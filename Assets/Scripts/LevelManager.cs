using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLvelAfter;
    
    private void Start()
    {
        if (autoLoadNextLvelAfter == 0)
        {
            Debug.Log("desabilitado");
        }
        else
        {
            Invoke("LoadNextLevel", autoLoadNextLvelAfter);
        }
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);       
    }

    public void QuitRequest()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

  
}
