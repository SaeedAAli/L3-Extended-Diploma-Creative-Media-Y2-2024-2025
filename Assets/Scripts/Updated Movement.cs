using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatedMovement : MonoBehaviour
{

    public Animator Animator;
    public Rigidbody2D Rigidbody;

    public bool Grounded;
    public float Jumping;
    private float Speed = 30f;



    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        Rigidbody= GetComponent<Rigidbody2D>();

        AnimationHolder();
    }

    private void AnimationHolder()
    {
        Animator.SetFloat("yVelocity", Rigidbody.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody.velocity = new Vector3(Speed, Rigidbody.velocity.x, Rigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            Animator.SetBool("JumpBlend", true);
            Rigidbody.velocity = Jumping * Vector2.up;
        }

        else
        {
            Animator.SetBool("JumpBlend", false);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grounded"))
        {
            Grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Grounded = false;
    }
}
