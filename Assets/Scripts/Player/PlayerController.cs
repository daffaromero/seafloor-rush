using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float _speed = 600f;
    public LogicScript logic;
    public LogicGOScript lgo;
    public bool isAlive = true;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    [SerializeField] GameObject gameOverScreen;

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

    private IEnumerator GameOverCoroutine()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime (0.2f);
        lgo = FindObjectOfType<LogicGOScript>();
        SceneManager.LoadScene("GameOverScene");
        lgo.gameOver();
        isAlive = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("Collision detected!");

        // If collided object is not on Layer 8
        if (collision.gameObject.layer != 8)
        {
            EventManager eventManager = FindObjectOfType<EventManager>();
            if (eventManager != null)
            {
                // Debug.Log("Triggering Game Over!");
                eventManager.TriggerGameOver();
            }
        }
    }
}
