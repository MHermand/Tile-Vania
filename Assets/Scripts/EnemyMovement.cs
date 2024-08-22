using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidBody;
    
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        myRigidBody.velocity = new Vector2 (moveSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hazards")
        {
            moveSpeed = -moveSpeed;
            FlipEnnemy();
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag != "Hazards")
        {
            moveSpeed = -moveSpeed;
            FlipEnnemy();
        } 
    }

    void FlipEnnemy()
    {
        transform.localScale = new Vector2 (-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
    }
}
