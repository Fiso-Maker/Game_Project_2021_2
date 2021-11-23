using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeManager : MonoBehaviour
{
    private float temp_timeScale;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    public void Doublespeed_ButtonClick()
    {
        if(Time.timeScale == 1.0f)
        {
            Time.timeScale = 2.0f;
        }
        else if(Time.timeScale == 2.0f)
        {
            Time.timeScale = 1.0f;
        }
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }
    public void Pause_ButtonClick()
    {
        if(Time.timeScale != 0.0f)
        {
            temp_timeScale = Time.timeScale;
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = temp_timeScale;
        }
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }
}
