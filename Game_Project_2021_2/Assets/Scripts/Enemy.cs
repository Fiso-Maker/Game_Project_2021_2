using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject prfHpBar;
    public GameObject canvas;

    RectTransform hpBarPos;
    GameObject hpBar;

    public float height = 1.3f;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");

        hpBar = Instantiate(prfHpBar, canvas.transform);
        hpBarPos = hpBar.GetComponent<RectTransform>();

        hpBar.GetComponent<HPandTP>().a = this.gameObject.GetComponent<FSM>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hpBar != null)
        {
            if(hpBar.GetComponent<Slider>().value <= 0)
            {
                Destroy(hpBar);
            }
            else{
                Vector3 _hpBarPos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x+0.3f, transform.position.y + height, 0));
                hpBarPos.position = _hpBarPos;
            }
        }
    }
}
