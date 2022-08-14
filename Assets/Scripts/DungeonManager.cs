using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    public GameObject[] dungeons;
    public GameManager gameManager;
    
    void Awake()
    {
        for(int i = 1; i < 5; i++)
        {
            dungeons[i].transform.position = dungeons[i-1].transform.position + new Vector3(0, 3.0f, 0); //던전 위치 배정
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }



}
