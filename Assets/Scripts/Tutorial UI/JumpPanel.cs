using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPanel : MonoBehaviour
{
    public GameObject JumpUI;

    // Start is called before the first frame update
    void Start()
    {
        JumpUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            JumpUI.SetActive(true);
            Time.timeScale = 0.09f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (JumpUI.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            JumpUI.SetActive(false);
            Time.fixedDeltaTime = 0.02f;
            Time.timeScale = 1f;
            Destroy(gameObject);

        }
    }
}
