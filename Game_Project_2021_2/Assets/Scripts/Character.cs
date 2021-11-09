using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject UPButton;
    [HideInInspector]
    RectTransform UPButtonPos;


    void Awake()
    {
        canvas = GameObject.Find("Canvas");

        UPButton = Instantiate(prfButton, canvas.transform);
        UPButton.GetComponent<Image>().color = new Color32(155,155,155,255);
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
        // 237씩 밀어야 함
        Vector3 _hpBarPos = new Vector3(487,123,0);
        hpBarPos.position = _hpBarPos;

        Vector3 _tpBarPos = new Vector3(_hpBarPos.x,_hpBarPos.y-50,_hpBarPos.z);
        tpBarPos.position = _tpBarPos;

        Vector3 Up_ButtonPos = new Vector3(_hpBarPos.x,_hpBarPos.y+125,_hpBarPos.z);
        UPButtonPos.position = Up_ButtonPos;
    }

    public void UPButton_Click()
    {
        if(this.GetComponent<FSM>().able_to_use_tpskill)
        {
            UPButton.GetComponent<Image>().color = new Color32(155,155,155,255);
            this.GetComponent<FSM>().able_to_use_tpskill = false;
        }
    }
}
