using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerabound : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera virtualcamera;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            virtualcamera.gameObject.SetActive(false);
        }
    }
}
