using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePadRight : MonoBehaviour
{

    public float bounceY = 10f;
    public float bounceX = 5;
    
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = new Vector2(bounceX, bounceY);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
