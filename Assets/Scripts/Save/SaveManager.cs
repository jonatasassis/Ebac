using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [NaughtyAttributes.Button]
  private void Save()
    {
        SaveSetup setup = new SaveSetup();
        setup.lastLevel = 2;
        setup.playerName = "jogador";

        string setupToJson=JsonUtility.ToJson(setup,true);
        SaveFile(setupToJson);

    }

    private void SaveFile(string json) 
    {
        string path = Application.persistentDataPath+ "/save.txt";
        File.WriteAllText(path, json);
    }
}

[System.Serializable]

public class SaveSetup
{
    public int lastLevel;
    public string playerName;
}
