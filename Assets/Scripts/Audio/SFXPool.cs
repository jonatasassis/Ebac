using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Singleton;

public class SFXPool : Singleton<SFXPool>
{
    private List<AudioSource> audioSourceList;
    public int poolSize = 10;
    private int index = 0;

    private void Start()
    {
        CreatePool();
    }
    private void CreatePool()
    {
        audioSourceList = new List<AudioSource>();

        for(int i=0;i<poolSize;i++)
        {
            CreateAudioSourceItem();
        }
    }

    private void CreateAudioSourceItem()
    {
        GameObject go = new GameObject("SFX_Pool");
        go.transform.SetParent(gameObject.transform);
        audioSourceList.Add(go.AddComponent<AudioSource>());
    }

    public void Play(SFXType sfxType)
    {
        if(sfxType==SFXType.NONE)
        {
            return;

        }
        var sfx= SoundManager.Instance.GetSFXByType(sfxType);
        audioSourceList[index].clip=sfx.sfxAudioClip;
        audioSourceList[index].Play();

        index++;

        if(index>= audioSourceList.Count)
        {
            index = 0;
        }
    }
}
