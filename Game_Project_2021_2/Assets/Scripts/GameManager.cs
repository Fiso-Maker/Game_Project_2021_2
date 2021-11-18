using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
#region 싱글톤
    public static GameManager instance = null;
    private void Awake()
    { 
        if (instance == null)
        { 
            instance = this; 
            DontDestroyOnLoad(gameObject);
        } 
    else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }
    }

#endregion   

    public int EnemyAliveCount;
    public int CharacterAliveCount;

    public bool isWin;
    public bool isLose;

    // Start is called before the first frame update
    void Start()
    {
        isWin = false;
        isLose = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.EnemyAliveCount == 0)
        {
            isWin=true;
        }
        else if(GameManager.instance.CharacterAliveCount == 0)
        {
            isLose = true;
        }
    }
}
