using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveInfos : MonoBehaviour
{
    public List<GameObject> saveInfosObjects;
    public GameObject player;
    public HealthBase playerHealth;
  

    private void Awake()
    {
        saveInfosObjects.ForEach(i => i.SetActive(false));
    }
    private void OnTriggerEnter(Collider other)
    {
        Player p = other.transform.GetComponent<Player>();

        if ( p != null)
        {
            ShowSaveInfo();
        }
    }

    private void ShowSaveInfo()
    {

        saveInfosObjects.ForEach(i => i.SetActive(true));

        foreach (var i in saveInfosObjects)
        {
            i.SetActive(true);
            i.transform.DOScale(0, .2f).SetEase(Ease.OutBack).From();
            SaveManager.Instance.SaveLastPlayerPosition(player.transform.position);
            SaveManager.Instance.SavePlayerCurrentLife(playerHealth.currentLife);
        }
    }
}
