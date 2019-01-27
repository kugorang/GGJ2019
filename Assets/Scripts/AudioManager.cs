using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private Sound[] sounds;
    private float _originVolume;

    private List<AudioSource> _pauseSources;
    private bool _isMute;
		
    // Use this for initialization
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
			
        foreach (var s in sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.Clip;
            s.Source.volume = s.Volume;
            s.Source.pitch = s.Pitch;
            s.Source.loop = s.Loop;
        }

        _pauseSources = new List<AudioSource>();
    }

    private void Start()
    {
        Play("SadTheme");
        
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

    private void Play(string soundName)
    {
        FindSound(soundName)?.Source.Play();
    }

    private void Stop(string soundName)
    {
        FindSound(soundName)?.Source.Stop();
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