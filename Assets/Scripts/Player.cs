using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Config
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    //SFX
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] AudioClip damageSFX;
    //State
    bool isAlive = true;
    bool isJumping = false;
    bool inSwirl = false;

    //Cached component references
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D bodyCollider;
    BoxCollider2D feetCollider;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        bodyCollider = GetComponent<CapsuleCollider2D>();
        feetCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }
        Move();
        Jump();
        IsVerticalMoving();
        EnemyCollision();
    }

    private void EnemyCollision()
    {
        bool isTouchingEnemy = bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Dangerous"));
        
        if (isTouchingEnemy)
        {
            StartCoroutine(Death());
        }
    }
    IEnumerator Death()
    {
        //Debug.Log("Death!");
        isAlive = false;
        //myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, deathKick);
        AudioSource.PlayClipAtPoint(damageSFX, Camera.main.transform.position);
        myAnimator.SetTrigger("Dying");
        yield return new WaitForSeconds(2);
        FindObjectOfType<GameSession>().ProsessPlayerDeath();
    }
    private void IsVerticalMoving()
    {
       
        if (Mathf.Round(myRigidbody.velocity.y) != 0)
        {
            JumpAnim();
        }
        //Debug.Log(Mathf.Round(myRigidbody.velocity.y));
    }
    private void Jump()
    {
        bool isTouchingLayer = feetCollider.IsTouchingLayers(LayerMask.GetMask("Foreground", "Active Stuff"));
        if (Input.GetButtonDown("Jump") && isTouchingLayer)
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidbody.velocity += jumpVelocityToAdd;
            AudioSource.PlayClipAtPoint(jumpSFX, Camera.main.transform.position);
            JumpAnim();
        }
    }
    private void JumpAnim()
    {
        if (!isJumping)
        {
            myAnimator.SetTrigger("Jumping");
            isJumping = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Foreground" && isJumping)
        {
            myAnimator.SetBool("Landing", true);
        }
    }

    public void EndLanding()
    {
        myAnimator.SetBool("Landing", false);
        isJumping = false;
        AudioSource.PlayClipAtPoint(jumpSFX, Camera.main.transform.position);
        //Debug.Log("END Landing");
    }

    private void Move()
    {
        float controlThrow = Input.GetAxis("Horizontal") * moveSpeed;  // val -1 : 1
        var playerVelocity = new Vector2(controlThrow, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        FlipSprite();
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), transform.localScale.y);
        }
    }

    public void InSwirlAnim()
    {
        if (inSwirl) { return; }
        myAnimator.SetTrigger("Swirl Start");
        inSwirl = true;
    }
    public void EndSwirlAnim()
    {
        myAnimator.SetTrigger("Swirl End");
        inSwirl = false;
    }

}
