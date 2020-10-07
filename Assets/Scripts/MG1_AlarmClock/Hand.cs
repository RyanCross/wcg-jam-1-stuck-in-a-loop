using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private float moveDirection = 1;
    private Transform t;
    private Rigidbody2D rb;

    public float moveSpeed = 1; // the speed to move the hand back and forth along the x-axis
    public float slamSpeed = 1; // the speed at which to slam the hand down onto the button
    public bool shouldSlam = false;
    public Vector2 leftBound;
    public Vector2 rightBound;

    // Move the hand back and forth between two set points
    void Move()
    {
        if (t.localPosition.x <= leftBound.x)
        {
            moveDirection = 1;
        }
        else if (t.localPosition.x >= rightBound.x)
        {
            moveDirection = -1;
        }
      
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
    }

    // Slam the hand down 
    void Slam()
    {
        moveSpeed = 0;
        rb.velocity = new Vector2(0, slamSpeed * -1);
        // stop at snooze button
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        t = GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // start moving in default direction
        
    }

    private void FixedUpdate()
    {
        Move();
        if(shouldSlam)
        {
            Slam();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            shouldSlam = true;
        }
    }
}
