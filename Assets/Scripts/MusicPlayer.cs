using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] float defaultVolume = 0.5f;

    private void Awake()
    {
        int numMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;
        if (numMusicPlayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        Debug.Log("AWAKE");
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayerPrefsController.SetMasterVolume(defaultVolume);
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
        Debug.Log("START");
    }

    // Update is called once per frame
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
    public void DeleteMusic()
    {
        Destroy(gameObject);
    }
}
