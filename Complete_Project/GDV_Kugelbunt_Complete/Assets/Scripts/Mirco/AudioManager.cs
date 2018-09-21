using UnityEngine.Audio;
using UnityEngine;
using System;


//eigener AudioManager
public class AudioManager : MonoBehaviour {

    private static AudioManager instance;

    public Sound[] sounds;

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
            }

            return instance;
        }
    }

    // Use this for initialization
    void Awake () {
        // eigene Soundeinstellungen in den UnityAudioManager übertragen
		foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
	}

    public void Play(string name)
    {
        //Die richtige Sounddatei finden und abspielen, falls gefunden
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
        if (s == null){
            Debug.Log("Sound: " + name + "not found"); //Fehlermeldung falls Sounddatei nicht gefunden wurde.
            return;
        }
        s.source.Play();
    }

    
	
}
