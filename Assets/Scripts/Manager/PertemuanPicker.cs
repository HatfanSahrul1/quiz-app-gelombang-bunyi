using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PertemuanPicker : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggered;
    public void SetPertemuan(int id)
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Pertemuan", id);
        onTriggered?.Invoke();
    }
}
