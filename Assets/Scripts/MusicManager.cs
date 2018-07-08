using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad (gameObject);
        Debug.Log("Don't destroy on load: " + name);
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        Debug.Log("OnDisabled called");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnSceneLoaded (Scene scene, LoadSceneMode mode)
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        AudioClip thisLevelMusic = levelMusicChangeArray[SceneManager.GetActiveScene().buildIndex];
        Debug.Log("Playing clip: " + thisLevelMusic);
        
        if (thisLevelMusic)
        {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
            audioSource.volume = PlayerPrefsManager.GetMasterVolume();
        }
    }

    public void SetVolume (float volume)
    {
        audioSource.volume = volume;
    }
}
