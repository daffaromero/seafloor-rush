using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float _speed = 600f;
    public LogicScript logic;
    public bool isAlive = true;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Vector2 moveInput = ctx.ReadValue<Vector2>();
        Vector2 newPosition = _rigidbody.position + moveInput * _speed * Time.fixedDeltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        _rigidbody.MovePosition(newPosition);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        isAlive = false;
    }
}
