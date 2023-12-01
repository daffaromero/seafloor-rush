using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float _speed = 600f;
    public LogicScript logic;
    public bool isAlive = true;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (isAlive)
        {
            rb.velocity = ctx.ReadValue<Vector2>() * _speed;
        }
    }

    private void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX), 
            Mathf.Clamp(transform.position.y, minY, maxY), 
            transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Does not happen when the player collides with the Phantom layer
        if (collision.gameObject.layer == 8)
        {
            return;
        }

        logic.gameOver();
        isAlive = false;
    }
}
