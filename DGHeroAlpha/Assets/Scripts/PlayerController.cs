using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    public Camera cam;

    [SerializeField] private float speed = 500f;

    private Vector2 movement;
    private Vector2 mousePos;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        this.GetComponent<SpriteRenderer>().color = CustomColor.og;
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(movement.x * speed * Time.fixedDeltaTime, movement.y * speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;

        float mangle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = mangle;

        movement.Normalize();

        /*Vector2 moveDirection = GetComponent<Rigidbody2D>().velocity;*/

        /*if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }*/
    }
}