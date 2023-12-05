using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaytoNightCycle : MonoBehaviour
{
    public float changeInterval = 2.0f; // Time interval in seconds to change color
    public Color[] colors; // Array of colors for day and night

    private SpriteRenderer spriteRenderer;
    private int currentIndex = 0;
    private float timer = 0.0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set initial color
        spriteRenderer.color = colors[currentIndex];
    }

    void Update()
    {
        // Increment timer
        timer += Time.deltaTime;

        // Check if it's time to change color
        if (timer >= changeInterval)
        {
            timer = 0.0f; // Reset timer

            // Change to the next color
            currentIndex = (currentIndex + 1) % colors.Length;
            spriteRenderer.color = colors[currentIndex];
        }
    }
}
