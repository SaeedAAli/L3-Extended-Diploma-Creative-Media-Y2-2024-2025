using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn1 : MonoBehaviour
{
    public CoinCollector DeathCoinPanel;
    public GameObject deathpanel;
    public float duration;
    public float BottomPositionY, MiddlePosY;
    public RectTransform Panel;
    public AudioSource GameOver;
    //public MusicManager StopBackgroundMusic;
    public TextMeshProUGUI SurvivedTime;
    public TextMeshProUGUI CoinCollected;
    private float elaspedtime = 0f;

    // public GameObject TimerTMP;
    public void Start()
    {
        //StopBackgroundMusic = FindObjectOfType<MusicManager>();
    }

    public void Update()
    {
        if (Time.timeScale > 0f)
        {
            elaspedtime += Time.deltaTime;
        }
    }

    public void SlidingDeath()
    {
        Panel.DOAnchorPosY(MiddlePosY, duration).SetUpdate(true);
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Time.timeScale = 0f;
            deathpanel.SetActive(true);
            SurvivedTime.text = elaspedtime.ToString("F2");

            if (SceneManager.GetActiveScene().name == "Level 6")
            {
                CoinCollected.text = DeathCoinPanel.Coincount.ToString() + " / 10";
            }
            else if (SceneManager.GetActiveScene().name == "Level 7")
            {
                CoinCollected.text = DeathCoinPanel.Coincount.ToString() + " / 13";
            }
            SlidingDeath();
            GameOver.Play();
            //StopBackgroundMusic.Stop();
        }
    }
}
