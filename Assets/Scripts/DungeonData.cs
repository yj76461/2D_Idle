using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonData : MonoBehaviour
{
    public int dungeonIdx;
    public int dungeonId;
    public int dungeonPrice;
    
    public bool isActivated = false;

    public GameObject dungeonEnemy;

    public SpriteRenderer transLayer;

    void Awake()
    {
        //transLayer.material.color = new Color(0f, 0f, 0f, 0.8f);
    }

    void Start()
    {
    }

    void Update()
    {
        
    }

    

    public void GenerateDungeonData(int idx, int id, int price, GameObject enemy, bool activate)
    {
        dungeonIdx = idx;
        dungeonId = id;
        dungeonPrice = price;
        dungeonEnemy = enemy;
        isActivated = activate;
    }
}
