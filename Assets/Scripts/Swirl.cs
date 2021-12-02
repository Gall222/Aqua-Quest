using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swirl : MonoBehaviour
{
    [SerializeField] float power = 2f;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        ActiveObject activeObject = collision.gameObject.GetComponent<ActiveObject>();
        if (activeObject)
        {
            activeObject.InSwirl(power);
        }
        var player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            player.InSwirlAnim();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            player.EndSwirlAnim();
        }
    }

}
