using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnOOB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the object that collided with this object is tagged as "Bullet"
            Debug.Log("Object despawned");
            // Destroy the object
            Destroy(collision.gameObject);
    }
}
