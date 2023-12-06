using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizableCharacter : MonoBehaviour
{
    public int skinNr;
    public SkinnedMeshRenderer[] skins;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SkinChoice()
    {
        if (spriteRenderer.sprite.name.Contains("Skin1")) ;

    }
}