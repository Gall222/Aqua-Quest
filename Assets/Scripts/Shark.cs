using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    [SerializeField] float moveSpeed = -2f;
    [SerializeField] float jumpSpeed = 5f;
    int direction = 1;
    bool flipPause = false;

    Rigidbody2D rigidbody;
    CircleCollider2D backCollider;
    BoxCollider2D faceCollider;
    CapsuleCollider2D bodyCollider;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        backCollider = GetComponent<CircleCollider2D>();
        faceCollider = GetComponent<BoxCollider2D>();
        bodyCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SharkMoving();
    }
    private void SharkMoving()
    {
        rigidbody.velocity = new Vector2(moveSpeed * direction, rigidbody.velocity.y);
        
        bool isTouchingLayer = faceCollider.IsTouchingLayers(LayerMask.GetMask("Foreground"));
        if (isTouchingLayer && !flipPause)
        {
            StartCoroutine(FlipSprite());
        }
    }
    IEnumerator FlipSprite()
    {
        flipPause = true;
        direction *= -1;
        transform.localScale = new Vector2(direction, transform.localScale.y);
        yield return new WaitForSeconds(0.2f);
        flipPause = false;
        //Debug.Log(direction);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isBackTouching = backCollider.IsTouching(collision);
        var activeObject = collision.gameObject.GetComponent<ActiveObject>();
        if (isBackTouching && activeObject)
        {
            activeObject.AddJump(jumpSpeed);
        }
    }

}
