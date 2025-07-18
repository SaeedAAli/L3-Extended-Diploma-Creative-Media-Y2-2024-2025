using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EndScript : MonoBehaviour
{

    public RectTransform Paragraph;
    public RectTransform Level1;
    public RectTransform Level2;
    public RectTransform Home;
    public float duration;
    // Start is called before the first frame update
    void Start()
    {
        Paragraph.DOAnchorPosY(318f, duration).SetDelay(1f).SetUpdate(true);
        Level1.DOAnchorPosY(-52.9f, duration).SetDelay(2f).SetUpdate(true);
        Level2.DOAnchorPosY(-154.5f, duration).SetDelay(3f).SetUpdate(true);
        Home.DOAnchorPosY(-259f, duration).SetDelay(4f).SetUpdate(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
