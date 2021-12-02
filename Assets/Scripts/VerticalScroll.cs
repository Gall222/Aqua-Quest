using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 0.3f;
    bool isTimeUp = false;
    // Update is called once per frame
    void Update()
    {
        if (isTimeUp)
        {
            float yMove = scrollSpeed * Time.deltaTime;
            transform.Translate(new Vector2(0, yMove));
        }
        
    }
    public void TimeUp()
    {
        isTimeUp = true;
    }
}
