using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [Range(0, 1)]
    [SerializeField] float musicVolume;
    [Range(0, 1)]
    [SerializeField] float sfxVolume;

    private float _sfxVolume;
    private float _musicVolume;

    [SerializeField] AudioSource musicAudioSource;
    [SerializeField] AudioSource sfxAudioSource;

    [SerializeField] public AudioClip MenuMusic;
    [SerializeField] public AudioClip GameMusic;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void PlaySfx(AudioClip audioClip)
    {
        sfxAudioSource.PlayOneShot(audioClip);
    }
    public void PlayMusic(AudioClip audioClip)
    {
        if (musicAudioSource.clip != audioClip)
        {

            musicAudioSource.clip = audioClip;
            musicAudioSource.loop = true;
            musicAudioSource.Play();
        }
    }

    private void Update()
    {
        if (musicVolume != _musicVolume)
        {
            _musicVolume = musicVolume;
            musicAudioSource.volume = musicVolume;
        }
        if (sfxVolume != _sfxVolume)
        {
            _sfxVolume = sfxVolume;
            sfxAudioSource.volume = sfxVolume;
        }
    }
}
