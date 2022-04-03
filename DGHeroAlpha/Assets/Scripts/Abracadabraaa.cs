using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abracadabraaa : MonoBehaviour
{
    public GameObject player;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private Color invisible = Color.clear;

    void Start()
    {
        boxCollider = player.GetComponent<BoxCollider2D>();
        spriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Disco.disco == false)
        {
            Activate();
        }
    }

    void Activate()
    {
        if (Input.GetKey(KeyCode.T))
        {
            spriteRenderer.color = invisible;
            boxCollider.enabled = false;
            Debug.Log("Woosh");
        }
        else
        {
            spriteRenderer.color = CustomColor.og;
            boxCollider.enabled = true;
        }
    }
}