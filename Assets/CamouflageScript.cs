using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamouflageScript : MonoBehaviour
{
    public string temporaryLayer = "Phantom";
    public KeyCode camouflageKey = KeyCode.X;
    public float timeToLive = 5f;
    public float timeToRecharge = 10f;
    public float timeToRechargeLeft = 0f;
    public bool isCamouflaged = false;
    public bool isRecharging = false;
    private int originalLayer;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        originalLayer = gameObject.layer;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRecharging)
        {
            timeToRechargeLeft -= Time.deltaTime;
            if (timeToRechargeLeft <= 0)
            {
                timeToRechargeLeft = 0;
                isRecharging = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(camouflageKey))
            {
                if (!isCamouflaged)
                {
                    isCamouflaged = true;
                    StartCoroutine(DisableCollisions());
                }
            }
        }   
    }

    IEnumerator DisableCollisions()
    {
        gameObject.layer = LayerMask.NameToLayer(temporaryLayer);
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
        isCamouflaged = true;
        isRecharging = false;
        yield return new WaitForSeconds(timeToLive);

        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        gameObject.layer = originalLayer;
        isCamouflaged = false;
        isRecharging = true;
        StartCoroutine(Recharge());
    }

    IEnumerator Recharge()
    {
        yield return new WaitForSeconds(timeToRecharge);
        isRecharging = false;
    }
}
