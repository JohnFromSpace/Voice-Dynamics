using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    float startTime = 300f;

    [SerializeField] Text countdown;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;  
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        print(currentTime);
        countdown.text = currentTime.ToString("f1");

        if (currentTime <= 0)
        {
            currentTime = 0;
        }

    }
}
