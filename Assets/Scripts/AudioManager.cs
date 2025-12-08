using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;


    public Sound[] sounds;
    public float musicVolume, sfxVolume;



    public static AudioSource audioSource; //reference to the audio source component on the game object

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }


    }

    private void Start()
    {
        ChangeMusicVolume(PlayerPrefs.GetFloat("musicVolume"));
        ChangeSFXVolume(PlayerPrefs.GetFloat("sfxVolume"));
        PlayClip("MainMenuMusic");
        PlayClip("ButtonPressWah");
    }

    public void PlayClip(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void StopClip(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void ChangeMusicVolume(float volume)
    {
        musicVolume = volume;
    }

    public void ChangeSFXVolume(float SFXVolume)
    {
        sfxVolume = SFXVolume;
    }

    public void ChangeAudioSourceVolume(string name, float vol)
    {
        Sound s = Array.Find(sounds, AudioSystem => AudioSystem.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "Not found!");
            return;
        }
        s.source.volume = vol;


    }


}
