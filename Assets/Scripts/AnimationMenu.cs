using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationMenu : MonoBehaviour
{
    public RectTransform PlayButton;
    public RectTransform OptionsButton;
    public RectTransform TitleName;
    public float transitionTime = 1.0f;


        void Start()
        {
            PlayButton.anchoredPosition = new Vector2(PlayButton.anchoredPosition.x, -500f);
            OptionsButton.anchoredPosition = new Vector2(OptionsButton.anchoredPosition.x, -500f);  
            TitleName.anchoredPosition = new Vector2(TitleName.anchoredPosition.x, -500f); 
        ShowMenu();
        }   
        
    public void ShowMenu()
    {
        TitleName.DOAnchorPosY(283f, transitionTime).SetDelay(4f).SetUpdate(true);
        PlayButton.DOAnchorPosY(155f, transitionTime).SetDelay(1f).SetUpdate(true);
        OptionsButton.DOAnchorPosY(-34f, transitionTime).SetDelay(3f).SetUpdate(true);
    }

}
