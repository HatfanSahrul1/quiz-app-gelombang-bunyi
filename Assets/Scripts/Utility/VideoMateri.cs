using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoMateri : MonoBehaviour
{    
    [SerializeField] MateriManager manager;
    [SerializeField] VideoClip video;
    [SerializeField] RenderTexture texture;
    
    [SerializeField] UnityEvent onSecondVideo, onSecondVideoEnd;
    void OnEnable()
    {
        manager.PlayMateriVideo(video, texture);
        onSecondVideo?.Invoke();
    }

    void OnDisable()
    {
        manager.DisplayMateriVideo();
        onSecondVideoEnd?.Invoke();
    }
}