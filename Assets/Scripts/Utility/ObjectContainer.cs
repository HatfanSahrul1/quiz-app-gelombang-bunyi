using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectContainer : MonoBehaviour
{
    [SerializeField] GameObject[] objects;

    public GameObject[] GetAllObjects() => objects;
}
