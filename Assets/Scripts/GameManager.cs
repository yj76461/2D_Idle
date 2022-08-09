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

    
    int level = 1;
    float currentExp = 0.0f;
    public float[] toLevelUp = new float[100]; // 경험치 배열 생성, 다음 레벨업에 필요한 경험치량이 아닌 그 레벨이 되기위한 총 경험치 량이다.
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
        //Debug.Log("현재 에너미의 몸값은 " + enemy.GetComponent<EnemyData>().enemyMoney);
        moneyText.text = money.ToString();
        return money;
    }

    
    public void SpawnEnemy(){
        int randSpawn = Random.Range(0, Enemy.Length);
        GameObject enemy = Instantiate(Enemy[randSpawn], new Vector3(3.3f, -1.07f, 0), Quaternion.identity);
    }

    public void CheckLevelUp(float exp){ 
        
        if(exp  >= toLevelUp[level - 1])
        {
            currentExp = exp - toLevelUp[level - 1]; // 레벨업 가능할 때
            level ++;
            Debug.Log(level +" 레벨에 필요한 총 경험치는  " + toLevelUp[level - 1] + " 입니다. 다음 레벨로 올라가기 위해 필요한 경험치는 " + (toLevelUp[level - 1] - toLevelUp[level - 2]));
        }
        else
        {   
            if(level > 1)
                currentExp = exp - toLevelUp[level - 2]; // 불가능하면 이전 레벨 요구 경험치를 빼서 대입.
            else
                currentExp = exp;
        }
        if(level > 1)
            barController.touchExpBar(currentExp, toLevelUp[level - 1] - toLevelUp[level - 2]);
        else
            barController.touchExpBar(currentExp, toLevelUp[level - 1]);
        
        
        lvText.text = "lv    " + level;
    }

    public int CurrentLevel()
    {
        return level;
    }
}
