using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioSource bgmInstance;
    static AudioSource sfxInstance;
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource sfx;

    public bool IsMute { get => bgm.mute; }
    public float BGMVolume { get => bgm.volume; }
    public float SFXVolume { get => sfx.volume; }


    private void Awake() {
        if (bgmInstance != null)
        {
            Destroy(bgm.gameObject);
            bgm = bgmInstance;
        } else {
            bgmInstance = bgm;
            bgm.transform.SetParent(null);
            DontDestroyOnLoad(bgm.gameObject);
        }

        if (sfxInstance != null)
        {
            Destroy(sfx.gameObject);
            sfx = sfxInstance;
        } else {
            sfxInstance = sfx;
            sfx.transform.SetParent(null);
            DontDestroyOnLoad(sfx.gameObject);
        }

        bgm.volume = PlayerPrefs.GetFloat("bgmVolume", 1);
        sfx.volume = PlayerPrefs.GetFloat("sfxVolume", 1);
        bgm.mute = PlayerPrefs.GetInt("mute") == 0 ? false : true;
        
    }

    public void PlayBGM(AudioClip clip, bool loop = true)
    {
        if (bgm.isPlaying)
        {
            bgm.Stop();
        }
        
        bgm.clip = clip;
        bgm.loop = loop;
        bgm.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (sfx.isPlaying)
        {
            sfx.Stop();
        }

        sfx.clip = clip;
        sfx.Play();
    }

    public void SetMute(bool value)
    {
        bgm.mute = value;
        sfx.mute = value;
    }
    public void SetBGMVolume(float value)
    {
        bgm.volume = value;
    }

    public void SetSFXVolume(float value)
    {
        sfx.volume = value;
    }
}
