using UnityEngine;

public class DimBackground : MonoBehaviour
{
    public float dimDuration = 30.0f; // Time in seconds to dim the background
    public Color dimColor = new Color(0.2f, 0.2f, 0.2f, 1.0f); // Dark gray color
    public float dimSpeed = 0f; // Speed at which the background dims

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private float timer = 0.0f;
    private bool isDimming = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Store the original color
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        if (!isDimming)
        {
            timer += Time.deltaTime;

            // Check if it's time to start dimming
            if (timer >= dimDuration)
            {
                isDimming = true;
                timer = 0.0f;
            }
        }
        else
        {
            timer += Time.deltaTime;

            // Calculate the progress of dimming
            float dimProgress = timer / dimSpeed;

            // Interpolate between original color and dim color
            spriteRenderer.color = Color.Lerp(originalColor, dimColor, dimProgress);

            // Check if dimming is complete
            if (dimProgress >= 1.0f)
            {
                isDimming = false;
                timer = 0.0f;
                spriteRenderer.color = dimColor; // Ensure it reaches the final dim color
            }
        }
    }
}
