using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;


public class ScoreboardScript : MonoBehaviour
{
    public CoinCollector AmountofPlayersCoinsCollected;
    public float duration;
    public float durationsliding;
    public float BottomPositionY, MiddlePosY;
    public GameObject SlidePanel;
    public RectTransform Scoreboard;
    public float TimeCompleted = 0f;
    public GameObject DisablePauseButton;

    [Header("RectTransform")]
    public RectTransform PostMatchResults;
    public RectTransform YouFinished;
    public RectTransform RankHolder;
    public RectTransform coinColleted;
    public RectTransform ButtonSliding;

    [Header("Results")]
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI Coins;
    public TextMeshProUGUI Rank;


    // Start is called before the first frame update
    void Start()
    {
        PostMatchResults.anchoredPosition = new Vector2(PostMatchResults.anchoredPosition.x, -604f);
        YouFinished.anchoredPosition = new Vector2(YouFinished.anchoredPosition.x, -763f);
        coinColleted.anchoredPosition = new Vector2(coinColleted.anchoredPosition.x, -909f);
        RankHolder.anchoredPosition = new Vector2(RankHolder.anchoredPosition.x, -1071f);
        ButtonSliding.anchoredPosition = new Vector2(ButtonSliding.anchoredPosition.x, -500f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Scoreboard")) {
            SlidePanel.SetActive(true);
            Time.timeScale = 0f;
            SlidingTowardstheCanvas();
            TextSlidingUpwards();
            DisablePauseButton.SetActive(false);
            RankingLevel1();
            RankingLevel2();
            ButtonSliding.gameObject.SetActive(true);
  

        }
    }
    
    public void TextSlidingUpwards()
    {
        Timer.text = TimeCompleted.ToString("F2");

       if (SceneManager.GetActiveScene().name == "Level 6")
        {
            Coins.text = AmountofPlayersCoinsCollected.Coincount.ToString() + "/ 10";
       }
        else if (SceneManager.GetActiveScene().name == "Level 7")
        {

            Coins.text = AmountofPlayersCoinsCollected.Coincount.ToString() + "/ 13";
       }

        PostMatchResults.DOAnchorPosY(215, duration).SetDelay(1f).SetUpdate(true);
        YouFinished.DOAnchorPosY(110, duration).SetDelay(2F).SetUpdate(true);
        coinColleted.DOAnchorPosY(-6.5f, duration).SetDelay(3f).SetUpdate(true);
        RankHolder.DOAnchorPosY(-124.3F, duration).SetDelay(4f).SetUpdate(true);
        Timer.rectTransform.DOAnchorPosY(95.8f, duration).SetDelay(5f).SetUpdate(true);
        Coins.rectTransform.DOAnchorPosY(2, duration).SetDelay(6F).SetUpdate(true);
        Rank.rectTransform.DOAnchorPosY(-120, duration).SetDelay(9f).SetUpdate(true);
        ButtonSliding.DOAnchorPosY(-250, duration).SetDelay(10f).SetUpdate(true);
 
    }

    public void RankingLevel1 ()
    {
        if(SceneManager.GetActiveScene().name == "Level 6")
        {
            if(AmountofPlayersCoinsCollected.Coincount > 9)
            {
                Rank.text = "S";
            }
            else if(AmountofPlayersCoinsCollected.Coincount > 8)
            {
                Rank.text = "A";
            }
            else if(AmountofPlayersCoinsCollected.Coincount > 6)
            {
                Rank.text = "B";
            }
            else if(AmountofPlayersCoinsCollected.Coincount > 3)
            {
                Rank.text = "C";
            }
            else
            {
               Rank.text = "D";
            }
        }
    }

    public void RankingLevel2()
    {
        if (SceneManager.GetActiveScene().name == "Level 7")
        {
            if (AmountofPlayersCoinsCollected.Coincount > 12)
            {
                Rank.text = "S";
            }
            else if (AmountofPlayersCoinsCollected.Coincount > 10)
            {
                Rank.text = "A";
            }
            else if (AmountofPlayersCoinsCollected.Coincount > 8)
            {
                Rank.text = "B";
            }
            else if (AmountofPlayersCoinsCollected.Coincount > 6)
            {
                Rank.text = "C";
            }
            else if(AmountofPlayersCoinsCollected.Coincount > 3)
            {
                Rank.text = "D";
            }
            else
            {
                Rank.text = "E"; 
            }   
        }
    }

    public void SlidingTowardstheCanvas()
    {
        Scoreboard.DOAnchorPosY(MiddlePosY, duration).SetUpdate(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0f)
        {
            TimeCompleted += Time.deltaTime;
        }
    }
}
