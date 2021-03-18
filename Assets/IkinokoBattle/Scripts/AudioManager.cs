using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [SerializeField] private AudioSource _audioSource;
    private readonly Dictionary<string, AudioClip> _clips = new Dictionary<string, AudioClip>();

    public static AudioManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
       if(null != instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        instance = this;

        var audioClips = Resources.LoadAll<AudioClip>("2D_SE");
        foreach (var clip in audioClips) {
            _clips.Add(clip.name, clip);
        }
    }


    public void Play(string clipName)
    {
        if (!_clips.ContainsKey(clipName)) {
            throw new System.Exception("Sound" + clipName + "is not defined");
        }

        _audioSource.clip = _clips[clipName];
        _audioSource.Play();
    }

}
