using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostPanel : MonoBehaviour
{
    public GameObject SpeedBoostUI;
    // Start is called before the first frame update
    void Start()
    {
        SpeedBoostUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 1.0f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            SpeedBoostUI.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SpeedBoostUI)
        {
            Time.timeScale = 1.0f;
            Destroy(gameObject);
            SpeedBoostUI.SetActive(false);

        }
    }
}
