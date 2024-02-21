using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public AudioClip bgm;

    public AudioSource audioSource;

    private void Awake()
    {
        Instance = this;
        if (!GetComponent<AudioSource>()) gameObject.AddComponent<AudioSource>();

        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = bgm;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
