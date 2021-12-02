using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeaweedsTimer : MonoBehaviour
{
    
    [SerializeField] float levelTime = 20f;
    [SerializeField] AudioClip alarmSFX;

    bool timeIsOver = false;

    Slider slider;

    private void Start()
    {
       
        slider = GetComponent<Slider>();
    }
    // Update is called once per frame
    void Update()
    {
        if (timeIsOver) {return;}

        slider.value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            var player = FindObjectOfType<Player>();
            AudioSource.PlayClipAtPoint(alarmSFX, player.transform.position);
            foreach (var item in FindObjectsOfType<VerticalScroll>())
            {
                item.TimeUp();
            }
            timeIsOver = true;
        }
    }
}
