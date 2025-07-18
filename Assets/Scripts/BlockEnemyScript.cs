using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEnemyScript : MonoBehaviour
{

    public Rigidbody2D rb2d;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            rb2d.velocity = Vector2.zero;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
