using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float rotationSpeed;
    private static ObstacleScript obstacle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        obstacle = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }

    public static ObstacleScript Instance { get { return obstacle; } }

    public void SetGravityScale(float newGravityScale)
    {
        /*print("Before Inc Gravity Scale : " + rb.gravityScale);
        
        print("After Inc Scale : " + rb.gravityScale);*/

        rb.gravityScale += newGravityScale;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "StickMan")
        {
            Destroy(collision.gameObject);
            GameManager.instance.GameOver();
        }

        if(collision.gameObject.tag == "Ground")
        {
            GameManager.instance.incrementScore();

            Destroy(this.gameObject);
        }
    }
}
