using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Wave_Check : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = GameManager.instance.Cur_Monster_Wave + "/" +GameManager.instance.Max_Monster_Wave;
    }
}
