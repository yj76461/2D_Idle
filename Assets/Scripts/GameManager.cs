using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Enemy;
    public int money = 0;
    public Text moneyText;
    //public PlayerController playerController;

    
    void Start()
    {
        
    }

    public int GetMoney()
    {
        money += 10;
        moneyText.text = money.ToString();
        return money;
    }
    public void SpawnEnemy(){
        GameObject enemy = Instantiate(Enemy, new Vector3(3.3f, -1.0f, 0), Quaternion.identity);
    }
}
