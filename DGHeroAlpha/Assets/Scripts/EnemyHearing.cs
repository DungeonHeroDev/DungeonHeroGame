using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHearing : MonoBehaviour
{
    private GameObject movement;

    void Start()
    {
        movement = GameObject.FindGameObjectWithTag("EnemyMovement");
        movement.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            movement.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            movement.SetActive(false);
        }
    }
}
