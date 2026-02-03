using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MateriManager : MonoBehaviour
{
    [SerializeField] SceneMovement moveScene;
    [SerializeField] ObjectContainer objectContainer;
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] GameObject slideVideo;
    int currentId = 0;
    GameObject[] materi;


    void Start()
    {
        materi = objectContainer.GetAllObjects();
        currentId = 0;
        ShowMateri();
    }

    void ShowMateri()
    {
        for(int i = 0; i < materi.Length; i++)
        {
            if(i != currentId) materi[i].SetActive(false);
        }

        materi[currentId].SetActive(true);

        if(currentId == 2 && slideVideo.activeSelf)
        {
            ResetVideo();
            videoPlayer.Play();
        }
        else
        {
            videoPlayer.Pause();    
        }
    }

    void ResetVideo()
    {
        videoPlayer.Pause();
        videoPlayer.time = 0;
    }

    public void NextMateri()
    {
        if (currentId < 25)
        {
            currentId++;
            ShowMateri();
        }
        else
        {
            moveScene.MoveToScene("LKPD");
        }
    }

    public void PrevMateri()
    {
        if (currentId > 0)
        {
            currentId--;
            ShowMateri();
        }
        else
        {
            moveScene.MoveToScene("Indikator");
        }
    }
}
