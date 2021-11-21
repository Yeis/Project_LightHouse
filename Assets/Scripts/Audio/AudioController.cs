using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
  

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public bool IsPlaying(AudioClip audioClip) {
        return audioSource.clip == audioClip && audioSource.isPlaying;
    }

    public void PlayAudioClip(AudioScriptableObject audio) {
        audioSource.clip = audio.audioClip;
        audioSource.PlayOneShot(audio.audioClip, audio.volume);
    }

}
