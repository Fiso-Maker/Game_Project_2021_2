using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameUI : MonoBehaviour
{
    public GameObject[] hpBars;
    // Start is called before the first frame update
    void Start()
    {
        if(hpBars == null)
        {
            hpBars = GameObject.FindGameObjectsWithTag("PlayerUI");
        }
        
        foreach(GameObject hpBar in hpBars)
        {
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
