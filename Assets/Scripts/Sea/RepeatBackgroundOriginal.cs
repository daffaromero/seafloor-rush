using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgroundOriginal : MonoBehaviour
{
    Vector3 startPos;
    float repeatHeight = 4320;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < startPos.y - repeatHeight)
        {
            transform.position = startPos;
        }
    }
}

