using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float LimitTime;
    public Text text_Timer;

    int minute;
    float second;
    // Start is called before the first frame update
    void Start()
    {
        text_Timer = this.GetComponent<Text>();
        minute = (int)LimitTime/60;
        second = LimitTime%60;
        text_Timer.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(LimitTime <= 0f)
        {
            LimitTime = 0f;
        }
        else{
            LimitTime -= Time.deltaTime;
        }
         
        minute = (int)LimitTime/60;
        second = (int)LimitTime%60;

        text_Timer.text = minute + ": " +Mathf.Round(second);
    }
}
