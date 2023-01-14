using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    bool stopTimeActive = false;
    float currentime;
    float defaultTime = 31;
    public Text currentimeText, countTime;
    public GameObject ShowDialog;

    void Start()
    {
        currentime = defaultTime; //กำหนดเวลาเริ่มต้น
        Start_Stopwatch();
    }

    void Update()
    {
        if (stopTimeActive == true)
        {
            currentime = currentime - Time.deltaTime; // + เพิ่มเวลา , - ลดเวลา
            if (currentime <= 0)
            {
                stopTimeActive = false;
                ShowDialog.SetActive(true);
                Debug.Log("End Time");
            }

        }
        TimeSpan time = TimeSpan.FromSeconds(currentime);
        currentimeText.text = time.ToString(@"ss\:ff");

        TimeSpan remainTime = TimeSpan.FromSeconds(defaultTime - currentime);
        countTime.text = remainTime.ToString(@"ss\:ff");
    }
    public void Start_Stopwatch()
    {
        stopTimeActive = true;
    }
    public void Stop_Stopwatch()
    {
        stopTimeActive = false;
    }

}


