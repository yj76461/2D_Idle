using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public string enemyName;
    public int enemyHP;
    public float enemyExp;

    public int enemyMoney;
    

    public EnemyData(string name, int HP, float exp, int money)
    {
        enemyName = name;
        enemyHP = HP;
        enemyExp = exp;
        enemyMoney = Random.Range(money - 3, money + 3);
    }
}
