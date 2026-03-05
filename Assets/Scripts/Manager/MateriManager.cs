using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MateriManager : MonoBehaviour
{
    [SerializeField] SceneMovement moveScene;
    [SerializeField] ObjectContainer objectContainer;
    [SerializeField] VideoPlayer videoPlayer;
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
    }

    void ResetVideo()
    {
        videoPlayer.Pause();
        videoPlayer.time = 0;
    }

    void ResetVideo(VideoPlayer vp)
    {
        vp.Pause();
        vp.time = 0;
    }

    public void PlayMateriVideo(VideoClip vid)
    {
        videoPlayer.clip = vid;
        ResetVideo();
        videoPlayer.Play();
    }

    public void PlayMateriVideo(VideoClip vid, RenderTexture texture)
    {
        videoPlayer.targetTexture = texture;
        videoPlayer.clip = vid;
        ResetVideo();
        videoPlayer.Play();
    }

    public void PlayMateriVideo(PublicVideoClass publicVideoClass)
    {
        VideoPlayer vp2 = publicVideoClass.videoPlayer;
        vp2.targetTexture = publicVideoClass.texture;
        vp2.clip = publicVideoClass.video;
        ResetVideo(vp2);
        vp2.Play();
    }

    public void DisplayMateriVideo()
    {
        videoPlayer.clip = null;
        ResetVideo();
    }

    public void DisplayMateriVideo(VideoPlayer vp2)
    {
        vp2.clip = null;
        ResetVideo(vp2);
    }

    public void NextMateri()
    {
        if (currentId < materi.Length - 1)
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
