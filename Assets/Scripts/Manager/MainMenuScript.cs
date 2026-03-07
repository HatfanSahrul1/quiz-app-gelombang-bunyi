using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    string sceneName;
    [SerializeField] SceneMovement sceneMovement;
    
    public void SetTargetScene(string sceneName)
    {
        this.sceneName = sceneName;
    }

    public void GoToScene()
    {
        sceneMovement.MoveToScene(sceneName);
    }
}
