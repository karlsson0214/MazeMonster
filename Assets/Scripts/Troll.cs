using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 10;
    // directions
    // 0 - right
    // 1 - up
    // 2 - left
    // 3 - down
    private int direction = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // gravity has no effect on Troll
        rb.gravityScale = 0;
        // prevent physics enginge to rotate Troll
        rb.freezeRotation = true;

        
    }

    // Update is called once per physics update
    void FixedUpdate()
    {
        if (direction == 0)
        {
            // right
            rb.MovePosition(rb.position + new Vector2(speed, 0) * Time.deltaTime);
        }
        else if (direction == 1)
        {
            // up
            rb.MovePosition(rb.position + new Vector2(0, speed) * Time.deltaTime);
        }
        else if (direction == 2)
        {
            // left
            rb.MovePosition(rb.position + new Vector2(-speed, 0) * Time.deltaTime);
        }
        else if (direction == 3)
        {
            // down
            rb.MovePosition(rb.position + new Vector2(0, -speed) * Time.deltaTime);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int deltaDirection = Random.Range(1, 3); // 1, 2 or 3
        direction += deltaDirection;
        direction = direction % 4;
        SnapToGrid();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        int deltaDirection = Random.Range(1, 3); // 1, 2 or 3
        direction += deltaDirection;
        direction = direction % 4;
        SnapToGrid();
    }
    private void SnapToGrid()
    {
        if (direction == 0 || direction == 2)
        {
            // moving right or left
            SnapToGridY();
        }
        else
        {
            // moving up or down
            SnapToGridX();
        }
    }
    private void SnapToGridX()
    {
        rb.position = new Vector2((float)System.Math.Round(rb.position.x), rb.position.y);
    }
    private void SnapToGridY()
    {
        rb.position = new Vector2(rb.position.x, (float)System.Math.Round(rb.position.y));
    }

}
