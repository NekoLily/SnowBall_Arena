using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    public AudioClip backsound;
    private AudioSource source;
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
