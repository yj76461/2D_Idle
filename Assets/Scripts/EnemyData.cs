using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public int enemyFloor;
    public string enemyName;
    public int enemyHP;
    public float enemyExp;

    public int enemyMoney;
    

    public void GenerateEnemyData(int floor, int HP, float exp, int money)
    {
        enemyFloor = floor;
        //enemyName = name;
        enemyHP = HP;
        enemyExp = exp;
        enemyMoney = Random.Range(money - 3, money + 3);
    }
}
