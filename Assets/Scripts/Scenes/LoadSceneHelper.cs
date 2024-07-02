using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneHelper : MonoBehaviour
{
    public SaveManager saveManager;
    public static int levelToLoad ;
   public void LoadLevel()
    {
        saveManager.Load();
        SceneManager.LoadScene(SaveManager.Instance.lastLevel);
    }

   
}
