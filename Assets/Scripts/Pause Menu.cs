using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausemenu;
    public float TopPosition, middlePos;
    public RectTransform PAUSEMENUTRANSFORM;
    public float duration;
    public void Pause()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        IntroSliding();
        Debug.Log("Testing Testing Testing");
    }

    public void HomeMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;

    }

    public void Resume()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        OutroSliding();
    }

    public void Restart(string scenename)
    {
        SceneManager.LoadScene(scenename);
        Time.timeScale = 1f;
    }

    public void IntroSliding()
    {
        PAUSEMENUTRANSFORM.DOAnchorPosY(middlePos, duration).SetUpdate(true);
    }

    public void OutroSliding() {

        PAUSEMENUTRANSFORM.DOAnchorPosY(TopPosition, duration).SetUpdate(true);
    
    }
}

