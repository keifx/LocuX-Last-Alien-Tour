using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public void changeScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void exitApp(){
        Application.Quit();
    }
}
