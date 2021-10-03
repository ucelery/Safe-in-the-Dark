using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class PlayerMovement : MonoBehaviour
{
    // Move player in 2D space
    [Header("Misc")]
    public float maxSpeed = 3.4f;
    public Camera mainCamera;

    [Header("Jump Properties")]
    public float jumpHeight = 5f;
    public float jumpTimeCount;
    public float jumpTime = 0.35f;

    bool isJumping = false;
    bool facingRight = true;
    float moveDirection = 0;
    bool isGrounded = false;
    Vector3 cameraPos;
    Rigidbody2D rb;
    Collider2D mainCollider;
    // Check every collider except Player and Ignore Raycast
    LayerMask layerMask = ~(1 << 2 | 1 << 8);
    Transform t;

    // Use this for initialization
    void Start()
    {
        t = transform;
        rb = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<Collider2D>();
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        facingRight = t.localScale.x > 0;
        gameObject.layer = 8;

        if (mainCamera)
            cameraPos = mainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement controls
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.A))
                moveDirection = -1;
            else if (Input.GetKey(KeyCode.D))
                moveDirection = 1;
            else
                moveDirection = 0;
        }

        // Change facing direction
        if (moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            isJumping = true;
            jumpTimeCount = jumpTime;
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        } 
        if (Input.GetKey(KeyCode.W) && isJumping == true)
        {
            if (jumpTimeCount > 0)
            {
                rb.velocity = Vector2.up * jumpHeight;
                jumpTimeCount -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
            isJumping = false;

        // Camera follow
        if (mainCamera)
            mainCamera.transform.position = new Vector3(t.position.x, cameraPos.y, cameraPos.z);
    }

    void FixedUpdate()
    {
        Bounds colliderBounds = mainCollider.bounds;
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, 0.005f, 0);
        // Check if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheckPos, 0.23f, layerMask);

        // Apply movement velocity
        rb.velocity = new Vector2((moveDirection) * maxSpeed, rb.velocity.y);

        // Simple debug
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, 0.23f, 0), isGrounded ? Color.green : Color.red);
    }
}