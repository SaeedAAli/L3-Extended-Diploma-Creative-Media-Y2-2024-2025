using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
public class DeathPanel : MonoBehaviour
{
    public CoinCollector DeathCoinPanel;
    public GameObject deathpanel;
    public float duration;
    public float BottomPositionY, MiddlePosY;
    public RectTransform Panel;
    public AudioSource GameOver;
    public TextMeshProUGUI SurvivedTime;
    public TextMeshProUGUI CoinCollected;
    private float elaspedtime = 0f;
    public void Start()
    {
    }

    public void Update()
    {
        if(Time.timeScale > 0f)
        {
            elaspedtime += Time.deltaTime;
        }
    }

    public void SlidingDeath()
    {
        Panel.DOAnchorPosY(MiddlePosY, duration).SetUpdate(true);
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Time.timeScale = 0f;
            deathpanel.SetActive(true);
            SurvivedTime.text = elaspedtime.ToString("F2");

            if(SceneManager.GetActiveScene().name == "Level 6")
            {
                CoinCollected.text = DeathCoinPanel.Coincount.ToString() + " / 10";
            }
            else if(SceneManager.GetActiveScene().name == "Level 7")
            {
                CoinCollected.text = DeathCoinPanel.Coincount.ToString() + " / 13";
            }
            SlidingDeath();
            GameOver.Play();
        }
    }
}
