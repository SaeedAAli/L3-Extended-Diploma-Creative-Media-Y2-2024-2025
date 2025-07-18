using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EndBarrier : MonoBehaviour
{
    public RectTransform EndPanel;
    public GameObject PanelEnd;
    public float BottomY, MiddleY;
    public float Duration;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TutorialEnd"))
        {
           PanelEnd.SetActive(true);
            SlidingTutorial();
            Time.timeScale = 0f;
            Debug.Log("Hello Hello");
        }
    }
    public void SlidingTutorial()
    {
        EndPanel.DOAnchorPosY(MiddleY, Duration).SetUpdate(true);    
    }
}
