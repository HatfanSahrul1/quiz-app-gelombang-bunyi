using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMovement : MonoBehaviour
{
    public void MoveToScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
