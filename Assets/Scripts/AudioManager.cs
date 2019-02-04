using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private Sound[] sounds;
    private float _originVolume;

    private List<AudioSource> _pauseSources;
    private bool _isMute;

    private WaitForSeconds _fadeWait;
		
    // Use this for initialization
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
        _pauseSources = new List<AudioSource>();
        _fadeWait = new WaitForSeconds(0.01f);

        if (sounds == null)
        {
            Debug.LogWarning("No sounds on AudioManager");
            return;
        }
        
        foreach (var s in sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.Clip;
            s.Source.volume = s.Volume;
            s.Source.pitch = s.Pitch;
            s.Source.loop = s.Loop;
        }
    }

    private void Start()
    {
        Play("Main");
        
        loadingEnd = true;
    }

    private Sound FindSound(string soundName)
    {
        var s = Array.Find(sounds, sound => sound.Name == soundName);

        if (s != null) 
            return s;
			
        Debug.LogWarningFormat("Sound: {0} not found!", soundName);
        return null;
    }

    public void Play(string soundName)
    {
        var s = FindSound(soundName);

        if (s == null) 
            return;
        
        StartCoroutine(FadeIn(s.Source));
    }

    private IEnumerator FadeIn(AudioSource s)
    {
        s.Play();
        
        while (s.volume < 1f)
        {
            s.volume += 0.01f;
            yield return _fadeWait;
        }
    }

    public void Stop(string soundName)
    {
        var s = FindSound(soundName);

        if (s == null)
            return;

        StartCoroutine(FadeOut(s.Source));
    }
    
    private IEnumerator FadeOut(AudioSource s)
    {
        while (s.volume > 0f)
        {
            s.volume -= 0.02f;
            yield return _fadeWait;
        }
        
        s.Stop();
    }

    public bool IsPlay(string soundName)
    {
        var s = FindSound(soundName);

        return s != null && s.Source.isPlaying;
    }

    public void Mute()
    {
        foreach (var s in sounds)
        {
            if (!s.Source.isPlaying) 
                continue;
            
            _pauseSources.Add(s.Source);
            s.Source.Pause();
            
            _isMute = true;
        }
    }

    public void Replay()
    {
        if (!_isMute)
            return;
        
        foreach (var s in _pauseSources)
            s.UnPause();

        _isMute = false;
        _pauseSources.Clear();
    }
}