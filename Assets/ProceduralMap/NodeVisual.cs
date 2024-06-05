using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeVisual : MonoBehaviour
{
    public Sprite[] tilesetSprites;

    void Start()
    {
        AssignRandomSprite();
    }

    public void AssignRandomSprite()
    {
        if (tilesetSprites != null && tilesetSprites.Length > 0)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            int indiceAleatorio = Random.Range(0, tilesetSprites.Length);
            spriteRenderer.sprite = tilesetSprites[indiceAleatorio];
            spriteRenderer.drawMode = SpriteDrawMode.Sliced;
        }
    }
}

