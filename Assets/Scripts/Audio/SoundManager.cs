using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Singleton;

public class SoundManager : Singleton<SoundManager>
{
    public List<MusicSetup> musicSetups;
    public List<SFXSetup> sfxSetups;
    public AudioSource musicSource;

    public void PlayMusicByType(MusicType musicType)
    {
        var music = GetMusicByType(musicType);
        musicSource.clip = music.audioClip;
        musicSource.Play();
    }

    public MusicSetup GetMusicByType(MusicType musicType)
    {
        return musicSetups.Find(i => i.musicType == musicType);
    }


    public SFXSetup GetSFXByType(SFXType sfxType)
    {
        return sfxSetups.Find(i => i.sfxType == sfxType);
    }


}


public  enum MusicType
{
    TYPE_1,
    TYPE_2,
    TYPE_3,
}
[System.Serializable]
public class MusicSetup
{
    public MusicType musicType;
    public AudioClip audioClip;
}

public enum SFXType
{
    NONE,
    TYPE_1,
    TYPE_2,
    TYPE_3,
    TYPE_4,
}
[System.Serializable]
public class SFXSetup
{
    public SFXType sfxType;
    public AudioClip sfxAudioClip;
}

