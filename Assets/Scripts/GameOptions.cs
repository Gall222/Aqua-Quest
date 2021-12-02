using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOptions : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    MusicPlayer musicPlayer;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        musicPlayer = FindObjectOfType<MusicPlayer>();
    }
    private void Update()
    {
        //var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        FindObjectOfType<Menu>().GoToStart();
    }
}
