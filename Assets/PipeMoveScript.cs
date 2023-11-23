using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed;
    public float despawnZone = -32;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < despawnZone)
        {
            Debug.Log("PIPE DOWN SON");
            Destroy(gameObject);
        }
    }
}
