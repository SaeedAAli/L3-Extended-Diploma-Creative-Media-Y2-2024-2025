using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePanel : MonoBehaviour
{
    public GameObject SlideUI;
    void Start()
    {
        SlideUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SlideUI.SetActive(true);
            Time.timeScale = 0.09f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(SlideUI.activeSelf && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Time.fixedDeltaTime =  0.02f;
            Time.timeScale = 1f;
            SlideUI.SetActive(false);
            Destroy(gameObject);
        }
    }
}
