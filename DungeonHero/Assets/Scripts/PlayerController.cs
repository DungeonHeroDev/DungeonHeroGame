using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public Camera cam;

    [SerializeField] private float speed = 500f;

    private bool facingRight;

    private Vector2 movement;
    // private Vector2 mousePos;

    private Rigidbody2D rb;
    private Rigidbody2D weaponRb;

    private SpriteRenderer sr;
    private GameObject weapon;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        weapon = GameObject.FindGameObjectWithTag("Weapon");
        this.GetComponent<SpriteRenderer>().color = CustomColor.og;
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        movement.Normalize();
        rb.velocity = new Vector2(movement.x * speed * Time.fixedDeltaTime, movement.y * speed * Time.fixedDeltaTime);

        float h = Input.GetAxisRaw("Horizontal");
        if (h > 0 && facingRight)
        {
            Flip();
        }
        else if (h < 0 && !facingRight)
        {
            Flip();
        }

        // Vector2 lookDir = mousePos - rb.position;

        // float mangle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        // rb.rotation = mangle;

        /*Vector2 moveDirection = GetComponent<Rigidbody2D>().velocity;*/

        /*if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }*/
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}