using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] Enemy;
    public int money = 0;
    public Text moneyText;
    public Slider expBar;
    //public PlayerController playerController;
    

    
    void Start()
    {
        
    }

    void Update()
    {

    }
    public int GetMoney(Collider2D enemy)
    {
        money += enemy.GetComponent<EnemyData>().enemyMoney;
        Debug.Log("현재 에너미의 몸값은 " + enemy.GetComponent<EnemyData>().enemyMoney);
        moneyText.text = money.ToString();
        return money;
    }

    
    public void SpawnEnemy(){
        int randSpawn = Random.Range(0, Enemy.Length);
        GameObject enemy = Instantiate(Enemy[randSpawn], new Vector3(3.3f, -1.07f, 0), Quaternion.identity);
    }

    
}
