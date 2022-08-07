using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] Enemy;
    public int money = 0;
    public Text moneyText;
    public Text lvText;
    public Slider expBar;
    //public PlayerController playerController;
    
    int level = 1;

    void Awake()
    {

    }
    void Start()
    {
        SpawnEnemy();
    }

    void Update()
    {

    }
    public int GetMoney(Collider2D enemy)
    {
        money += Random.Range(enemy.GetComponent<EnemyData>().enemyMoney - 5,
                             enemy.GetComponent<EnemyData>().enemyMoney + 5); // 돈 범위 정해서 랜덤하게 주어지게
        Debug.Log("현재 에너미의 몸값은 " + enemy.GetComponent<EnemyData>().enemyMoney);
        moneyText.text = money.ToString();
        return money;
    }

    
    public void SpawnEnemy(){
        int randSpawn = Random.Range(0, Enemy.Length);
        GameObject enemy = Instantiate(Enemy[randSpawn], new Vector3(3.3f, -1.07f, 0), Quaternion.identity);
    }

    public void LevelUp(){
        level += 1;
        lvText.text = "lv    " + level;
    }
}
