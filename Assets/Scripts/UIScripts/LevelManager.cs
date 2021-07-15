using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
    }


    public void changeScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }
}
