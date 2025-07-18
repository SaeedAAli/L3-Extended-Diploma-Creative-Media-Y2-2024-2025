using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroy : MonoBehaviour
{

    private float Delay = 0.5f;
    private float DestroyDelay = 0.5f;

    public Rigidbody2D r2bd;

    public AudioSource PlatformDestroyer;




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DestroyPlatform());
        }
    }

        IEnumerator DestroyPlatform()
        {
            yield return new WaitForSeconds(Delay);
            r2bd.bodyType = RigidbodyType2D.Dynamic;
            Destroy(gameObject, DestroyDelay);
            PlatformDestroyer.Play();
        
        }
    }

 