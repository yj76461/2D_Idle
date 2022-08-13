using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    public GameObject[] dungeons;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ActivateDungeon(int i)
    {
        dungeons[i].SetActive(true);
        dungeons[i].GetComponent<DungeonData>().isActivated = true;
    }


}
