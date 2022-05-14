using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abracadabraaa : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private GameObject weapon;
    private SpriteRenderer weaponSr;
    private BoxCollider2D boxCollider;
    private BoxCollider2D weaponBc;

    private Color invisible = Color.clear;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        // weapon = GameObject.FindGameObjectWithTag("Weapon");
        // weaponSr = weapon.GetComponent<SpriteRenderer>();
        // weaponBc = weapon.GetComponent<BoxCollider2D>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
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
        if (Input.GetKey(KeyCode.Q))
        {
            spriteRenderer.color = invisible;
            // weaponSr.color = invisible;
            // weaponBc.enabled = false;
            boxCollider.enabled = false;
            // Debug.Log("Woosh");
        }
        else
        {
            spriteRenderer.color = CustomColor.og;
            // weaponSr.color = CustomColor.og;
            // weaponBc.enabled = true;
            boxCollider.enabled = true;
        }
    }
}