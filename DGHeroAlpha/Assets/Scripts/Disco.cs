using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Disco : MonoBehaviour
{
    public static bool disco = false;

    private SpriteRenderer spriteRenderer;

    private Color primaryColor = Color.yellow;
    private Color secondaryColor = Color.green;
    private Color thirdColor = Color.red;
    private Color fourthColor = Color.blue;
    private Color fifthColor = Color.magenta;
    private Color sixthColor = Color.cyan;
    private Color seventhColor = Color.clear;

    private Vector2 primaryScale = new Vector2(1, 1);
    private Vector2 secondaryScale = new Vector2(2, 2);

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        notCrazy();
    }

    public void notCrazy()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            disco = !disco;
            if (disco == true)
            {
                goCrazy();
            }
            else
            {
                spriteRenderer.color = CustomColor.og;
                gameObject.transform.localScale = primaryScale;
            }
        }
    }

    public void goCrazy()
    {
        gameObject.transform.localScale = secondaryScale;
        StartCoroutine(FlashOne());
    }

    public IEnumerator FlashOne()
    {
        while (disco == true)
        {
            spriteRenderer.color = primaryColor;
            yield return new WaitForSeconds(.1f);
            spriteRenderer.color = secondaryColor;
            yield return new WaitForSeconds(.1f);
            spriteRenderer.color = thirdColor;
            yield return new WaitForSeconds(.1f);
            spriteRenderer.color = fourthColor;
            yield return new WaitForSeconds(.1f);
            spriteRenderer.color = fifthColor;
            yield return new WaitForSeconds(.1f);
            spriteRenderer.color = sixthColor;
            yield return new WaitForSeconds(.1f);
            spriteRenderer.color = seventhColor;
            yield return new WaitForSeconds(.1f);
            yield return new WaitForSeconds(.0f);
            spriteRenderer.color = sixthColor;
            yield return new WaitForSeconds(.0f);
            spriteRenderer.color = seventhColor;
            yield return new WaitForSeconds(.0f);
        }
    }
}