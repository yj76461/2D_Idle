using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public int enemyFloor;
    public int enemyId;
    public string enemyName;
    public int enemyHP;
    public float enemyExp;

    public int enemyMoney;
    
    void Awake()
    {

    }

    public void GenerateEnemyData(int Id, string name, int HP, int money, string items)
    {
        enemyId = Id;
        enemyName = name;
        enemyHP = HP;
        enemyMoney = money;
    }
}
