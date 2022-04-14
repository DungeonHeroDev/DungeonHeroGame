using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private Rigidbody2D enemyRb;
    private SpriteRenderer enemySr;

    //chase variables
    [SerializeField] private float chaseSpeed = 5f;
    private Vector3 chaseDirection;

    //wander variables
    [SerializeField] private float wanderStrength = 0.1f;
    [SerializeField] private float wanderSpeed = 2f;
    private Vector3 wanderDirection;
    private static bool isWandering = true;

    private void Start()
    {
        enemyRb = gameObject.GetComponent<Rigidbody2D>();
        enemySr = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Debug.Log("Collided with a wall, I am a dummy");
            wanderDirection = (other.transform.position * -1).normalized;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isWandering = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isWandering = true;
        }
    }

    private void FixedUpdate()
    {
        if (isWandering)
        {
            Vector3 randomDirection = Random.insideUnitCircle;
            wanderDirection = (wanderDirection + randomDirection * wanderStrength).normalized;
            enemyRb.MovePosition(gameObject.transform.position + wanderDirection * wanderSpeed * Time.fixedDeltaTime);
            Flip(wanderDirection);

            // gameObject.transform.Translate((wanderDirection * Time.deltaTime) * wanderSpeed);
        }
        else
        {
            chaseDirection = (player.transform.position - gameObject.transform.position).normalized;
            enemyRb.MovePosition(gameObject.transform.position + chaseDirection * chaseSpeed * Time.fixedDeltaTime);
            Flip(chaseDirection);
        }
    }

    void Flip(Vector3 direction)
    {
        if (direction.x > 0)
        {
            enemySr.flipX = true;
        }
        else if (direction.x < 0)
        {
            enemySr.flipX = false;
        }
    }
}