using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public static EnemySpawnManager instance;

    [SerializeField] GameObject bigPredatorPrefab;
    [SerializeField] GameObject smallPredatorPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void SpawnBig(Collider2D spawnableAreaCollider)
    {
        Vector2 spawnPosition = GetRandomSpawnPosition(spawnableAreaCollider);
        Instantiate(bigPredatorPrefab, spawnPosition, Quaternion.identity);
    }

    public void SpawnSmall(Collider2D spawnableAreaCollider)
    {
        Vector2 spawnPosition = GetRandomSpawnPosition(spawnableAreaCollider);
        Instantiate(smallPredatorPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector2 GetRandomSpawnPosition(Collider2D spawnableAreaCollider)
    {
        Vector2 spawnPosition = Vector2.zero;
        bool isSpawnPositionValid = false;

        int attemptCount = 0;
        int maxAttempts = 100;

        int layerToNotSpawnOn = LayerMask.NameToLayer("Enemy");

        while (!isSpawnPositionValid && attemptCount < maxAttempts)
        {
            spawnPosition = GetRandomPointInCollider(spawnableAreaCollider);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPosition, 2f);

            bool isInvalidCollision = false;
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.layer == layerToNotSpawnOn)
                {
                    isInvalidCollision = true;
                    break;
                }
            }

            if (!isInvalidCollision)
            {
                isSpawnPositionValid = true;
            }

            attemptCount++;
        }

        if (!isSpawnPositionValid)
        {
            Debug.LogWarning("Could not find a valid spawn position after " + maxAttempts + " attempts.");
        }

        return spawnPosition;
    }

    private Vector2 GetRandomPointInCollider(Collider2D collider, float offset = 1f)
    {
        Bounds collBounds = collider.bounds;

        Vector2 minBounds = new Vector2(collBounds.min.x + offset, collBounds.min.y + offset);
        Vector2 maxBounds = new Vector2(collBounds.max.x - offset, collBounds.max.y - offset);

        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomY = Random.Range(minBounds.y, maxBounds.y);

        return new Vector2(randomX, randomY);
    }
}
