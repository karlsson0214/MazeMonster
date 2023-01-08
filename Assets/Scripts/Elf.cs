using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Elf : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 10;
    private int direction = 0;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        
    }

    // Update is called once per frame
    private void FixedUpdate()
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
        SelectDirection(FreeDirections());
        SnapToGrid();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        SelectDirection(FreeDirections());
        SnapToGrid();
    }
    private void SelectDirection(List<int> noObjectDirections)
    {
        if (noObjectDirections.Count > 0)
        {
            // New random direction, but possible to move in that direction.
            int randomIndex = Random.Range(0, noObjectDirections.Count);
            direction = noObjectDirections[randomIndex];
        }
        else
        {
            // new random direction
            int deltaDirection = Random.Range(1, 3); // 1, 2 or 3
            direction += deltaDirection;
            direction = direction % 4;
        }
    }
    private List<int> FreeDirections()
    {
        // search for direction with no obstacle
        // choose one of these directions randomly
        List<int> noObjectDirections = new List<int>();
        // right - check for object
        RaycastHit2D hit = Physics2D.Raycast(rb.position + Vector2.right * 0.5f, Vector2.right, 0.2f);
        if (hit.transform == null)
        {
            //Debug.Log("object to the right at x: " + hit.transform.position.x);
            noObjectDirections.Add(0);
        }

        // up - check for object
        hit = Physics2D.Raycast(rb.position + Vector2.up * 0.5f, Vector2.up, 0.2f);
        if (hit.transform == null)
        {
            //Debug.Log("object to the right at x: " + hit.transform.position.x);
            noObjectDirections.Add(1);
        }
        // left - check for object
        hit = Physics2D.Raycast(rb.position - Vector2.right * 0.5f, -Vector2.right, 0.2f);
        // object to right
        if (hit.transform == null)
        {
            //Debug.Log("object to the right at x: " + hit.transform.position.x);
            noObjectDirections.Add(2);
        }
        // down - check for object
        hit = Physics2D.Raycast(rb.position - Vector2.up * 0.5f, -Vector2.up, 0.2f);
        if (hit.transform == null)
        {
            //Debug.Log("object to the right at x: " + hit.transform.position.x);
            noObjectDirections.Add(3);
        }

        // Debug empty directions
        string debugDirections = "empty directions: ";
        foreach(int direction in noObjectDirections)
        {
            debugDirections += direction + ", ";
        }
        Debug.Log(debugDirections);

        return noObjectDirections;
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
