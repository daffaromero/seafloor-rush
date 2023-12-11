using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    Vector3 startPos;
    Vector3 continuePos;
    float repeatHeight;
    float colliderHeight;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        colliderHeight = GetComponent<BoxCollider2D>().size.y;
        repeatHeight = 4320 + colliderHeight;
        continuePos = startPos;
        continuePos.y = startPos.y - colliderHeight;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < startPos.y - repeatHeight)
        {
            transform.position = continuePos;
        }
    }
}
