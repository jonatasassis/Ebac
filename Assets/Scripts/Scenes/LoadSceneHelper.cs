using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneHelper : MonoBehaviour
{
    public static int levelToLoad = 1;
   public void LoadLevel()
    {
        
        SceneManager.LoadScene(levelToLoad);
    }
}
