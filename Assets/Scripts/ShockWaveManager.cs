using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWaveManager : MonoBehaviour
{
    [SerializeField] private float shockWaveTime = 0.75f;
    [SerializeField] private float yOffset = -100f;
    public static ShockWaveManager Instance;
    private Coroutine shockWaveCoroutine;

    private Material material;

    private static int waveDistanceFromCenter = Shader.PropertyToID("_WaveDistanceFromCenter");

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        transform.position += new Vector3(0f, yOffset, 0f);

    }

    // private void Update()
    // {
    // if (Input.GetKeyDown(KeyCode.Space))
    // {
    //     CallShockWave();
    // }
    // }

    public void CallShockWave()
    {
        shockWaveCoroutine = StartCoroutine(ShockWaveAction(-0.1f, 1f));
    }

    private IEnumerator ShockWaveAction(float startPos, float endPos)
    {
        material.SetFloat(waveDistanceFromCenter, startPos);

        float lerpedAmount = 0f;

        float elapsedTime = 0f;
        while (elapsedTime < shockWaveTime)
        {
            elapsedTime += Time.deltaTime;

            lerpedAmount = Mathf.Lerp(startPos, endPos, elapsedTime / shockWaveTime);
            material.SetFloat(waveDistanceFromCenter, lerpedAmount);

            yield return null;
        }
    }

}
