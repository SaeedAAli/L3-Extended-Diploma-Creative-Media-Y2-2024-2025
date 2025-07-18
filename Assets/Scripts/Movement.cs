using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed = 30f;
    public float Jumping = 10f;
    public bool Grounded;
    public Animator Anim;
    private bool canDoubleJump = true;
    private int jumpcount = 0;
    private int maximumamountofjumps = 2;
    private float TimeinAir;
    public float SlideSpeed = 20f;
    public CoinCollector Coinc;

    public AudioSource PlayerRunning;
    public AudioSource PlayerJumping;
    public AudioSource SpeedSoundEffect;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        Sliding();
        TrackingJumping();
        rb2d.velocity = new Vector3(speed, rb2d.velocity.y, rb2d.velocity.x);
    }

    
    public void TrackingJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpcount < maximumamountofjumps)
        {
            if (Grounded)
            {
                rb2d.velocity = Jumping * Vector2.up;
                Anim.SetBool("isJump", true);
                Anim.SetBool("isDoubleJump", false);
                canDoubleJump = true;
                jumpcount = 1;
                PlayerJumping.Play();
            }
            else if (canDoubleJump)
            {
                rb2d.velocity = Jumping * Vector2.up;
                Anim.SetBool("isJump", false);
                Anim.SetBool("isDoubleJump", true);
                canDoubleJump = false;
                jumpcount = 2;
                PlayerJumping.Play();


            }
        }

        if (Grounded)
        {
            jumpcount = 0;
            canDoubleJump = true;

        }
    }


    IEnumerator SpeedBoost()
    {
        speed *= 3f;
        yield return new WaitForSeconds(3f);
        speed /= 3f;
    }

    public void SpeedBostActivated()
    {
        StartCoroutine(SpeedBoost());
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpeedBoost"))
        {
            SpeedBostActivated();
            SpeedSoundEffect.Play();
        }
    }
    public void Sliding()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Anim.SetBool("isSlide", true);
            rb2d.velocity = new Vector3(SlideSpeed * 2f, rb2d.velocity.y);
        }
        else
        {
            Anim.SetBool("isSlide", false);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grounded"))
        {
            Anim.SetBool("isLand", true);
            Grounded = true;
            PlayerRunning.Play();
            Anim.SetBool("isFalling", false);
            Anim.SetBool("isJump", false);
            Anim.SetBool("isDoubleJump", false);
            Anim.SetBool("isTransition", true);
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grounded"))
        {
            Anim.SetBool("isLand", false);
            PlayerRunning.Stop();
            Grounded = false;
            Anim.SetBool("isFalling", true);
            Anim.SetBool("isTransition", false);

        }
    }
}




 