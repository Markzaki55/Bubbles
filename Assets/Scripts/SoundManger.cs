using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    private AudioSource soundeffectS;
    [SerializeField] private AudioClip[] sondClips;
    [SerializeField] GameObject Soundtrack;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(Soundtrack);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        soundeffectS = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clipName)
    {
        if (instance == null)
        {
            GameObject soundManagerGO = new GameObject("SoundManager");
            instance = soundManagerGO.AddComponent<SoundManager>();
        }

        AudioClip clipToPlay = instance.GetClipByName(clipName);
        if (clipToPlay == null)
        {
            Debug.LogError($"Sound clip not found: {clipName}");
            return;
        }

        instance.soundeffectS.PlayOneShot(clipToPlay);
    }

    private AudioClip GetClipByName(string clipName)
    {
        foreach (AudioClip clip in sondClips)
        {
            if (clip.name == clipName)
            {
                return clip;
            }
        }

        return null;
    }
}

