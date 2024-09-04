using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }


    public void GoToScene2()
    {
        SceneManager.LoadScene("Scene2Naam");
    }

    public void QuitTheGame () 
    {
        Application.Quit();
    }
}

