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
    public BarController barController;
    //public PlayerController playerController;
    
    int level = 1;
    float expSum = 0.0f;
    float currentExp = 0.0f;
    int loopStop = 0;
    public float[] toLevelUp = new float[100]; // 경험치 배열 생성
    void Awake()
    {
        toLevelUp[0] = 100; // 초기 경험치량 세팅
        for(int i = 1; i < toLevelUp.Length; i++) // 경험치량 세팅
        {
            toLevelUp[i] = toLevelUp[i - 1] * 2.0f;
        }
        
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

    public void CheckLevelUp(float exp){ // level up system issue happened! must see again
        
        if(exp - toLevelUp[level - 1] >= 0)
        {
            currentExp = exp - toLevelUp[level - 1];
            level ++;
        }
        else   {}
        
        barController.touchExpBar(currentExp );
            
        lvText.text = "lv    " + level;
    }

    public int CurrentLevel()
    {
        return level;
    }
}
