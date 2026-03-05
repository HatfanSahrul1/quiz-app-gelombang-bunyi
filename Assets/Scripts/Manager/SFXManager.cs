using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    private bool isCoroutineRunning = false;

    public void PlayAudioClip(AudioClip clip)
    {
        if (clip != null)
        {
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    public void PlayAudioClipWithCoroutine(AudioClip clip)
    {
        if (!isCoroutineRunning && clip != null)
        {
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
            audioSource.clip = clip;
            audioSource.Play();
            StartCoroutine(WaitForClipToFinish(clip));
        }
    }

    private IEnumerator WaitForClipToFinish(AudioClip clip)
    {
        isCoroutineRunning = true;
        yield return new WaitForSeconds(clip.length);
        isCoroutineRunning = false;
        ResetAudioClip();
    }

    public void ResetAudioClip()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.clip = null;
        }
    }
}
