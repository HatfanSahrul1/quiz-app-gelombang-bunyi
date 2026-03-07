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
        isMuted = PlayerPrefs.GetInt("IsMute") == 1;
        // Find all AudioSources in the scene
        audioSources = new List<AudioSource>(FindObjectsOfType<AudioSource>());
        SetAudio();
    }

    public void SetAudio()
    {
        foreach (var audioSource in audioSources)
        {
            audioSource.mute = isMuted;
        }
    }

    public void ToggleAudio()
    {
        isMuted = !isMuted;
        foreach (var audioSource in audioSources)
        {
            audioSource.mute = isMuted;
        }
        PlayerPrefs.DeleteKey("IsMute");
        PlayerPrefs.SetInt("IsMute", isMuted ? 1 : 0);
    }
}
