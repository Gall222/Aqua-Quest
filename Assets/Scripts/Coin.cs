using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip coinSFX;
    [SerializeField] int cost = 10;

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player)
        {
            AudioSource.PlayClipAtPoint(coinSFX, Camera.main.transform.position);
            FindObjectOfType<GameSession>().Addpoint(cost);
            Destroy(gameObject);
        }
        
        //Debug.Log(collision);
    }
}
