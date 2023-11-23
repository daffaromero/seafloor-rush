using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // Reference the Rigidbody2D component of the bird
    public Rigidbody2D birdRigidbody2D;
    public float flapStrength;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Go up if spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            birdRigidbody2D.velocity = Vector2.up * flapStrength;
        }
    }
}
