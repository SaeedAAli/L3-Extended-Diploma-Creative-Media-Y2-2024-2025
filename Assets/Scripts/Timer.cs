using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI timetext;

    float timerunning;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerunning += Time.deltaTime;
        timetext.text = timerunning.ToString();
    }
}
