using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    public Component[] EnemySpawnTransforms;
    public GameObject[] prfEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void init()
    {
        int i=0;

        EnemySpawnTransforms = this.GetComponentsInChildren<Transform>();
        foreach(Transform ST in EnemySpawnTransforms)
        {
            Instantiate(prfEnemy[i], ST);
            i++;
            GameManager.instance.EnemyAliveCount++;
        }
    }
}
