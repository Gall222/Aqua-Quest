using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObject : MonoBehaviour
{
    [SerializeField] float maxVerticalSpeed = 10f;
    Rigidbody2D myRigidbody;
    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }
    public void InSwirl(float power)
    {
        if (myRigidbody.velocity.y >= maxVerticalSpeed) { return; }
        Vector2 verticalVelocityToAdd = new Vector2(0f, power);
        myRigidbody.velocity += verticalVelocityToAdd;
    }
    public void AddJump(float jumpSpeed)
    {
        Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
        myRigidbody.velocity += jumpVelocityToAdd;
    }
}
