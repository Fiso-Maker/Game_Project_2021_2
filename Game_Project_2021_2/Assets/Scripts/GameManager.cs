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

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
