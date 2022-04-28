using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickmanController : MonoBehaviour
{

    Rigidbody2D rb;
    public float moveSpeed;
    SpriteRenderer sp;
    public static StickmanController instance;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x < (Screen.width / 2))
            {
                // move left
                rb.velocity = Vector2.left * moveSpeed;
                sp.flipX = true;
            }
            else
            {
                // move right

                rb.velocity = Vector2.right * moveSpeed;
                sp.flipX = false;
            }
            // sp.flipX = false;

        }
    }
    public void moveLeft()
    {
        rb.velocity = Vector2.left * moveSpeed;
        sp.flipX = true;
    }

    public void moveRight()
    {
        rb.velocity = Vector2.right * moveSpeed;
        sp.flipX = false;
    }
    public static StickmanController Instance { get { return instance; } }
    public void increseMoveSpeed()
    {
        this.moveSpeed += 0.5f;
        print("MoveSpeed Changed to : " + moveSpeed);
    }
}
