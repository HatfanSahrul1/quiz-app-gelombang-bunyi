using UnityEngine;
using UnityEngine.SceneManagement;

public class BackSoundManager : MonoBehaviour
{
    public static BackSoundManager Instance { get; private set; }

    private AudioSource audioSource;

    // List of scenes where the sound should be muted
    [SerializeField]
    private string[] muteScenes;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (ShouldMute(scene.name))
        {
            MuteSound();
        }
        else
        {
            UnmuteSound();
        }
    }

    private bool ShouldMute(string sceneName)
    {
        foreach (string muteScene in muteScenes)
        {
            if (sceneName == muteScene)
            {
                return true;
            }
        }
        return false;
    }

    public void MuteSound()
    {
        if (audioSource != null)
        {
            audioSource.mute = true;
        }
    }

    public void UnmuteSound()
    {
        if (audioSource != null)
        {
            audioSource.mute = false;
        }
    }
}