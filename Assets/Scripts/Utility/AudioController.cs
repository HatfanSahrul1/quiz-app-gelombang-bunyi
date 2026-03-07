using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private List<AudioSource> audioSources;
    private bool isMuted = false;

    // Start is called before the first frame update
    void Start()
    {
        // Find all AudioSources in the scene
        audioSources = new List<AudioSource>(FindObjectsOfType<AudioSource>());
    }

    public void ToggleAudio()
    {
        isMuted = !isMuted;
        foreach (var audioSource in audioSources)
        {
            audioSource.mute = isMuted;
        }
    }
}
