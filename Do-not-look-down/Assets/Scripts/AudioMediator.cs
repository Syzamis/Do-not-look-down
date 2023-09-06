using System;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class AudioMediator : MonoBehaviour
{

    public Sound[] soundsArray;

    public static AudioMediator Instance;
    
    private void Awake()
    {

        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        
        foreach (Sound s in soundsArray)
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
        Play("Main Menu");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(soundsArray, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + " not found!");
        }
        s.source.Play();
    }
    
}
