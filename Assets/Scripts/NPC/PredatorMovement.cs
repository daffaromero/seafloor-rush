using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorMovement : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Random movement
        transform.position = transform.position + (Vector3.down * moveSpeed) * Time.deltaTime;
    }
}