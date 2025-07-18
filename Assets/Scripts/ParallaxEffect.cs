using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ParallaxEffect : MonoBehaviour
{
    private float Sposiiton, length;
    public GameObject cameramm;
    public float Parallaxeffect;

    public void Start()
    {
     Sposiiton = transform.position.x;
     length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = cameramm.transform.position.x * Parallaxeffect;
        float movement = cameramm.transform.position.x * (1 - Parallaxeffect);

        transform.position = new Vector3(Sposiiton + distance, transform.position.y, transform.position.z);

        if (movement > Sposiiton + length)
        {
            Sposiiton += length;
        }

        else if (movement < Sposiiton - length)
        {
            Sposiiton -= length;
        }
        }
    }
    
 

