using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Scripts.Singleton;


public class SaveManager : Singleton <SaveManager>
{
    private SaveSetup saveSetup;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        saveSetup = new SaveSetup();
        saveSetup.lastLevel = 2;
        saveSetup.playerName = "jogador";
    }


    [NaughtyAttributes.Button]
  private void Save()
    {
        
        string setupToJson=JsonUtility.ToJson(saveSetup,true);
        SaveFile(setupToJson);

    }

    public void SaveName(string text)
    {
        saveSetup.playerName = text;
        Save();
    }
    public void SaveLastLevel(int level)
    {
        saveSetup.lastLevel = level;
        Save();
    }
    private void SaveFile(string json)
    {
        string path = Application.persistentDataPath + "/save.txt";
        File.WriteAllText(path, json);
    }

    
    public void SaveLevelOne(int level)
    {
        SaveLastLevel(1);
    }
    
}

[System.Serializable]

public class SaveSetup
{
    public int lastLevel;
    public string playerName;
}
