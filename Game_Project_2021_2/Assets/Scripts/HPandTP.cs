using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPandTP : MonoBehaviour
{
    public FSM a;

    public Slider slider1;
    public Slider slider2;

    public enum Type
    {
        HP,
        TP
    }

    public Type type;

    // Start is called before the first frame update
    void Start()
    {
        if(a.CharacterType == FSM.Type.Character)
        {
            gameObject.tag="PlayerUI";
        }

        if(slider1 == null && slider2 == null) 
        {
            if(type == Type.HP)
                {
                    slider1 = GetComponent<Slider>();
                }
                else if(type == Type.TP)
                {
                    slider2 = GetComponent<Slider>();
                }
        }         
    }

    // Update is called once per frame
    void Update()
    {
        if(a != null)
        {
            if(type == Type.HP)
            {
                slider1.value = (float) a.health/a._stat._health;
            }
            else if(type == Type.TP)
            {
                slider2.value = (float) a.TP/a._stat._needTP;
            }  

        }   
    }
}
