using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public TextMeshProUGUI coimText;
    public AudioSource CoinNoise;
    public int Coincount;
    public Animator deathpanelanim;

    public DeathPanel deathpanel;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        coimText.text = " : " + Coincount;
    }

    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            CoinNoise.Play();
            Coincount++;
        }
    }
}

