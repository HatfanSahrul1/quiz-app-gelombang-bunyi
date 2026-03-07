using UnityEngine;

public class PlayerPrefsCleaner : MonoBehaviour
{
    private static PlayerPrefsCleaner instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

#if UNITY_EDITOR
    [UnityEditor.InitializeOnLoadMethod]
    private static void ClearPlayerPrefsOnEditorPlayMode()
    {
        UnityEditor.EditorApplication.playModeStateChanged += (UnityEditor.PlayModeStateChange state) =>
        {
            if (state == UnityEditor.PlayModeStateChange.ExitingPlayMode)
            {
                PlayerPrefs.DeleteAll();
                Debug.Log("PlayerPrefs cleared on exiting play mode.");
            }
        };
    }

    [UnityEditor.InitializeOnLoadMethod]
    private static void CreateInstanceInEditor()
    {
        UnityEditor.EditorApplication.playModeStateChanged += (UnityEditor.PlayModeStateChange state) =>
        {
            if (state == UnityEditor.PlayModeStateChange.EnteredPlayMode)
            {
                if (FindObjectOfType<PlayerPrefsCleaner>() == null)
                {
                    GameObject cleanerObject = new GameObject("PlayerPrefsCleaner");
                    cleanerObject.AddComponent<PlayerPrefsCleaner>();
                    DontDestroyOnLoad(cleanerObject);
                }
            }
        };
    }
#endif

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
}