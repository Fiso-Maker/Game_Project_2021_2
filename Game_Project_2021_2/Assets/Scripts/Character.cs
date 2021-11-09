using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject prfHpBar;
    public GameObject prfTPBar;

    public GameObject prfButton;
    public GameObject canvas;

    public RectTransform hpBarPos;
    [HideInInspector]
    GameObject hpBar;

    RectTransform tpBarPos;
    GameObject tpBar;

    GameObject UPButton;
    RectTransform UPButtonPos;


    void Awake()
    {
        canvas = GameObject.Find("Canvas");

        UPButton = Instantiate(prfButton, canvas.transform);
        UPButtonPos = UPButton.GetComponent<RectTransform>();

        hpBar = Instantiate(prfHpBar, canvas.transform);
        hpBarPos = hpBar.GetComponent<RectTransform>();

        hpBar.GetComponent<HPandTP>().a = this.gameObject.GetComponent<FSM>();

        tpBar = Instantiate(prfTPBar, canvas.transform);
        tpBarPos = tpBar.GetComponent<RectTransform>();

        tpBar.GetComponent<HPandTP>().a = this.gameObject.GetComponent<FSM>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _hpBarPos = new Vector3(487,123,0);
        hpBarPos.position = _hpBarPos;

        Vector3 _tpBarPos = new Vector3(_hpBarPos.x,_hpBarPos.y-50,_hpBarPos.z);
        tpBarPos.position = _tpBarPos;

        Vector3 Up_ButtonPos = new Vector3(_hpBarPos.x,_hpBarPos.y+125,_hpBarPos.z);
        UPButtonPos.position = Up_ButtonPos;
    }
}
