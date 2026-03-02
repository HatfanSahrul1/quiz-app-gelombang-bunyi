using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoMateri : MonoBehaviour
{    
    [SerializeField] MateriManager manager;
    [SerializeField] VideoClip video;
    void OnEnable()
    {
        manager.PlayMateriVideo(video);
    }

    void OnDisable()
    {
        manager.DisplayMateriVideo();
    }
}