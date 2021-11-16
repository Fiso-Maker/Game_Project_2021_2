using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public Component[] CharacterSpawnTransforms;
    public GameObject[] prfCharacter;

    public GameObject[] prfEnemy;


    // Start is called before the first frame update
    void Start()
    {
        int i=0;

        CharacterSpawnTransforms = this.GetComponentsInChildren<Transform>();
        foreach(Transform ST in CharacterSpawnTransforms)
        {
            Instantiate(prfCharacter[i], ST);
            
            prfCharacter[i].GetComponent<Character>().cnt = i;
            GameManager.instance.CharacterAliveCount++;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
