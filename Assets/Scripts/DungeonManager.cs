using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    public GameObject[] dungeons;
    public GameObject[] enemyList;
    public GameObject basicDungeon;
    public GameManager gameManager;
    public WeaponManager weaponManager;
    public List<Dictionary<string, object>> enemyInfo = new List<Dictionary<string, object>>();
    
    void Awake()
    {
        enemyInfo = CSVReader.Read("enemyInfo");

        dungeons[0].transform.position = new Vector3(0, 0, 0);
        for(int i = 0; i < dungeons.Length; i++)
        {
            // 각 층별 적 정보 대입
            enemyList[i].GetComponent<EnemyData>().GenerateEnemyData(i, 
                                                                    enemyInfo[i]["enemyName"].ToString(), 
                                                                    (int)enemyInfo[i]["enemyHP"],
                                                                    (int)enemyInfo[i]["enemyMoney"],
                                                                    enemyInfo[i]["enemyItem"].ToString());
            dungeons[i].GetComponent<DungeonData>().GenerateDungeonData(i, 100, enemyList[i], false);

            if(i > 0)
                dungeons[i].SetActive(false);
        }
        
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void nextActivation(int nextFloor)
    {
        dungeons[nextFloor].SetActive(true);
        dungeons[nextFloor].transform.position = dungeons[nextFloor - 1].transform.position + new Vector3(0, 3.0f, 0);

        GameObject currentWeapon = dungeons[nextFloor].transform.GetChild(0).GetChild(0).GetChild(0).gameObject; // active 됐을 때 무기 스프라이트 정보 받아옴
        currentWeapon.GetComponent<SpriteRenderer>().sprite = weaponManager.swordList[gameManager.weaponIdx];
    }


}
