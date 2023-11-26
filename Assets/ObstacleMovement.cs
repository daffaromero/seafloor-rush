using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float moveSpeed;
    public float despawnZone = -1200;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.down * moveSpeed) * Time.deltaTime;
        
        if (transform.position.y < despawnZone)
        {
            Debug.Log("Obstacle despawned");
            Destroy(gameObject);
        }
    }
}
