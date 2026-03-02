using UnityEngine;

public class LinkManager : MonoBehaviour
{
    public void OpenGoogleDocs(string googleDocsUrl)
    {
        if (!string.IsNullOrEmpty(googleDocsUrl))
        {
            Application.OpenURL(googleDocsUrl);
        }
        else
        {
            Debug.LogError("URL-nya mana? Jangan kosong dong.");
        }
    }
}