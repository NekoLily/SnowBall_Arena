using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private AudioClip backsound;
    private AudioSource source;
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
