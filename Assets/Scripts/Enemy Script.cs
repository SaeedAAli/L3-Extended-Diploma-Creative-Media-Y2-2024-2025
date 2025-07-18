using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform Player;
    public Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float distance = 10f;
        float speed = 7.5f;

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(Player.position.x, transform.position.y), speed * Time.deltaTime);
        
        if (Player.position.x - transform.position.x > distance)
        {
            transform.position = new Vector2(Player.position.x - distance, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BlockEnemy"))
        {
            rb2d.velocity = Vector2.zero;
            GetComponent<EnemyScript>().enabled = false;
        }
    }
}

