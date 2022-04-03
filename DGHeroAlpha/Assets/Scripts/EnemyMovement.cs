using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private GameObject enemy;
    private Rigidbody2D enemyRb;
    private SpriteRenderer enemySr;

    private Vector3 direction;
    [SerializeField] private float speed = 5f;

    private void Start()
    {
        enemy = transform.parent.gameObject;
        enemyRb = enemy.GetComponent<Rigidbody2D>();
        enemySr = enemy.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        direction = (player.transform.position - enemy.transform.position).normalized;
        if (direction.x > 0)
        {
            enemySr.flipX = true;
        }
        else if (direction.x < 0)
        {
            enemySr.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        enemyRb.MovePosition(enemy.transform.position + direction * speed * Time.fixedDeltaTime);
    }
}
