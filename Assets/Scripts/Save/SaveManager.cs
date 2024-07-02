using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Singleton;

public class SaveManager : Singleton<SaveManager>
{
    [SerializeField]private SaveSetup saveSetup;
    private string path = Application.streamingAssetsPath + "/save.txt";
    public int lastLevel,coinsToLoad,healthToLoad;
    public Action<SaveSetup> FileLoaded;
    public float playerCurrentLifeToLoad;
    public Vector3 playerPositionToLoad;
    public SaveSetup setup
    {
        get { return saveSetup; }
    }

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);

        
        
    }

    private void CreateNewSave()
    {
        saveSetup = new SaveSetup();
        saveSetup.lastLevel = 1;
        saveSetup.playerName = "jogador";
        saveSetup.lastPlayerPosition = new Vector3(442, -7, -76);
        saveSetup.playerCurrentLife = 5;

    }
    private void Start()
    {
       Invoke(nameof(Load),.1f);
    }

    #region SAVE
    [NaughtyAttributes.Button]
    private void Save()
    {
        string setupToJson = JsonUtility.ToJson(saveSetup, true);
        Debug.Log(setupToJson);
        SaveFile(setupToJson);
    }

    public void SaveLastLevel(int level)
    {
        saveSetup.lastLevel = level;
        SaveItens();
        Save();
    }

    public void SaveLastPlayerPosition(Vector3 playerPosition)
    {
        saveSetup.lastPlayerPosition = playerPosition;
        SaveItens();
        Save();
    }

    public void SavePlayerCurrentLife(float currentLife)
    {
        saveSetup.playerCurrentLife=currentLife;
        Save();
    }

    public void SaveItens()
    {
        saveSetup.coins = Itens.ItemManager.Instance.GetItemByType(Itens.ItemType.COIN).soInt.value;
        saveSetup.health = Itens.ItemManager.Instance.GetItemByType(Itens.ItemType.LIFE_PACK).soInt.value;
        Save();
    }
    #endregion

    
    private void SaveFile(string json)
    {
        Debug.Log(path);
        File.WriteAllText(path, json);
    }
    [NaughtyAttributes.Button]
    public void Load()
    {
        string fileLoaded = "";
        if(File.Exists(path))
        {
            fileLoaded = File.ReadAllText(path);
            saveSetup = JsonUtility.FromJson<SaveSetup>(fileLoaded);
            lastLevel = saveSetup.lastLevel;
            coinsToLoad= saveSetup.coins;
            healthToLoad=saveSetup.health;
            playerCurrentLifeToLoad= saveSetup.playerCurrentLife;
            playerPositionToLoad = saveSetup.lastPlayerPosition;

        }
        else
        {
            CreateNewSave();
            Save();
        }

       
        FileLoaded.Invoke(saveSetup);
    }
}

[System.Serializable]
public class SaveSetup
{
    public int lastLevel;
    public string playerName;
    public Vector3 lastPlayerPosition;
    public int coins;
    public int health;
    public float playerCurrentLife;
}