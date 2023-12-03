using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        // Grab the needed components
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        
        // Calculate the direction and rotation of the bullet
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroy the bullet when it hits an enemy
        if (collision.gameObject.TryGetComponent<Predator>(out Predator predatorComponent))
        {
            predatorComponent.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
