using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource anbiantAudioSource;

    [SerializeField] private float[] musicVolume;
    [SerializeField] private AudioClip[] anbiantclip;

    private void Start()
    {
        anbiantAudioSource.clip = anbiantclip[0];
        anbiantAudioSource.volume = musicVolume[0];
        anbiantAudioSource.Play();
    }

    private void Update()
    {
        if (anbiantAudioSource.isPlaying == false)
        {
            var rnd = Random.Range(0, 3);
            anbiantAudioSource.clip = anbiantclip[rnd];
            anbiantAudioSource.volume = musicVolume[rnd];
            anbiantAudioSource.Play();
        }
    }
}
