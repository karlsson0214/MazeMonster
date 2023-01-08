using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject brickPrefab;
    public GameObject trollPrefab;
    public GameObject elfPrefab;
    public GameObject gargoylePrefab;
    public GameObject phonixPrefab;

    // Start is called before the first frame update
    private void Start()
    {
        // read screen size i world coordinates
        int yMax = (int)Camera.main.orthographicSize;
        int xMax = (int)(Camera.main.orthographicSize * Screen.width / Screen.height);

        for (int x = -xMax; x <= xMax; ++x)
        {
            // wall top
            Instantiate(brickPrefab, new Vector3(x, yMax, 0), Quaternion.identity);
            // wall bottom
            Instantiate(brickPrefab, new Vector3(x, -yMax, 0), Quaternion.identity);
        }
        for (int y = -yMax + 1; y < yMax; ++y)
        {
            // wall right
            Instantiate(brickPrefab, new Vector3(xMax, y, 0), Quaternion.identity);
            // wall left
            Instantiate(brickPrefab, new Vector3(-xMax, y, 0), Quaternion.identity);
        }

        // List of wall elements (bricks) to put in the scene.
        List<Vector3> bricks = new List<Vector3>();
        // upper left
        bricks.Add(new Vector3(-7, 3, 0));
        bricks.Add(new Vector3(-6, 3, 0));
        bricks.Add(new Vector3(-5, 3, 0));
        bricks.Add(new Vector3(-7, 2, 0));
        // lower left
        bricks.Add(new Vector3(-7, -3, 0));
        bricks.Add(new Vector3(-6, -3, 0));
        bricks.Add(new Vector3(-5, -3, 0));
        bricks.Add(new Vector3(-7, -2, 0));
        // mid left and right
        bricks.Add(new Vector3(-8, 0, 0));
        bricks.Add(new Vector3(8, 0, 0));

        // 4 left up and down
        bricks.Add(new Vector3(-3, 4, 0));
        bricks.Add(new Vector3(-3, -4, 0));

        // L left
        bricks.Add(new Vector3(-5, 1, 0));
        bricks.Add(new Vector3(-4, 1, 0));
        bricks.Add(new Vector3(-3, 1, 0));
        bricks.Add(new Vector3(-3, 2, 0));
        // mirror in x-axis
        bricks.Add(new Vector3(-5, -1, 0));
        bricks.Add(new Vector3(-4, -1, 0));
        bricks.Add(new Vector3(-3, -1, 0));
        bricks.Add(new Vector3(-3, -2, 0));

        // Add element in list to the scene
        foreach (Vector3 vector3 in bricks)
        {
            Instantiate(brickPrefab, vector3, Quaternion.identity);
        }

        // troll
        Instantiate(trollPrefab, new Vector3(-8, 4, 0), Quaternion.identity);
        Instantiate(trollPrefab, new Vector3(-8, -4, 0), Quaternion.identity);
        Instantiate(trollPrefab, new Vector3(8, 4, 0), Quaternion.identity);
        Instantiate(trollPrefab, new Vector3(8, -4, 0), Quaternion.identity);

        // elf
        Instantiate(elfPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        // gargoyle
        Instantiate(gargoylePrefab, new Vector3(2, 2, 0), Quaternion.identity);

        // phonix
        GameObject phonix = Instantiate(phonixPrefab);
        Rigidbody2D rbPhonix = phonix.GetComponent<Rigidbody2D>();
        rbPhonix.position = new Vector2(2, -2);
        

    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
