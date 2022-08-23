using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonManager : MonoBehaviour
{
    public GameObject[] dungeons;
    public GameObject dungeonPrefab;
    public GameObject fakeDungeon;
    public GameObject buyButton;
    public List<GameObject> dungeonList;
    public GameObject[] enemyArray; // enemy는 배열로. 적 냉장고 정도의 역할을 할 뿐이다.
    public GameManager gameManager;
    public WeaponManager weaponManager;
    public List<Dictionary<string, object>> enemyInfo = new List<Dictionary<string, object>>();
    public List<Dictionary<string, object>> dungeonInfo = new List<Dictionary<string, object>>();

    int currentIdx = 0;

    void Awake()
    {
        enemyInfo = CSVReader.Read("enemyInfo");
        dungeonInfo = CSVReader.Read("dungeonInfo"); // dungeon id 는 1부터 시작 dungeon list는 0부터 시작
        // 특별히 id를 지칭해야 하는 상황이 나오지 않는 이상 currentIdx 변수를 사용하여 0부터 표현하는 식으로 구성할 것이다.

        dungeonList.Add(dungeonPrefab);
        Instantiate(dungeonPrefab, new Vector3(0,0,0), Quaternion.identity); // 첫던전 리스트에 넣고 판 깔고 시작

        for (int i = 0; i < enemyArray.Length; i++)
        {
            // 적 정보 대입
            enemyArray[i].GetComponent<EnemyData>().GenerateEnemyData((int)enemyInfo[i]["enemyId"],
                                                                    enemyInfo[i]["enemyName"].ToString(),
                                                                    (int)enemyInfo[i]["enemyHP"],
                                                                    (int)enemyInfo[i]["enemyMoney"],
                                                                    enemyInfo[i]["enemyItem"].ToString());
        }

        for (int i = 0; i < 6; i++) // 던전 정보 모두 대입
            SetDungeonData(i);
        

    }
    void Start()
    {
            buyButton.GetComponent<Button>().onClick.AddListener(ActivateEmptyDungeon);
            ActivateEmptyDungeon(); // 최초 인덱스 0에 접근하여 첫 던전 문 연다.
    }

    void Update()
    {
        //button 은 UI 계열이라 좌표 건들 때 조금 특이한 방식으로 변경
        buyButton.GetComponent<Button>().transform.position = Camera.main.WorldToScreenPoint(
            dungeonList[currentIdx].transform.position + new Vector3(0, 3.0f, 0));
    }

    public void nextActivation(int nextIdx)
    {
        // 가림막용 가짜던전은 맵 완전 구석에 치워두고 이 함수가 최초로 실행될 때부터 정상적인 좌표를 갖도록 구성
        fakeDungeon.transform.position = dungeonList[nextIdx].transform.position + new Vector3(0, 3.0f, 0);

        GameObject currentWeapon = dungeonList[nextIdx].transform.GetChild(0).GetChild(0).GetChild(0).gameObject; // active 됐을 때 무기 스프라이트 정보 받아옴
        currentWeapon.GetComponent<SpriteRenderer>().sprite = weaponManager.swordList[gameManager.weaponIdx];
    }

    public void SetDungeonData(int Idx) // 여기서 던전에 필요한 모든 정보를 기입해야함.
    {
            dungeonList.Add(dungeonPrefab); // 정보를 입력할 던전을 리스트에 넣기
            GameObject Enemy = FindProperEnemy((int)dungeonInfo[Idx]["dungeonEnemyId"]);
            dungeonList[Idx].GetComponent<DungeonData>().GenerateDungeonData( // 던전 정보 입력
                (int)dungeonInfo[Idx]["dungeonId"],
                (int)dungeonInfo[Idx]["dungeonPrice"],
                Enemy,
                false
            );

            // 던전 내 플레이어의 층을 알려준다.
            dungeonList[Idx].transform.GetChild(0).GetChild(0).GetComponent<PlayerController>().myFloor =Idx;

            // 좌표 정보
            if(currentIdx > 0)
                dungeonList[currentIdx].transform.position = new Vector3(0f, dungeonList[currentIdx - 1].transform.position.y + 3.0f, 0f);
            else  // currentIdx 가 0일 때
                dungeonList[currentIdx].transform.position = new Vector3(0f, 0f, 0f);       
    }

    public void ActivateEmptyDungeon() // SetDungeonData에서 완성된 정보를 바탕으로 소환만 때린다. 전역변수 currentIdx에 기반하여 작동.
    {
        dungeonList[currentIdx].GetComponent<DungeonData>().isActivated = true;
        //dungeonList[currentIdx].GetComponent<DungeonData>().transLayer.sharedMaterial.color = new Color(0f, 0f, 0f, 0.0f);

        Instantiate(dungeonList[currentIdx]);
        gameManager.SpawnEnemy(currentIdx);

        if(dungeonList.Count - 1 > currentIdx) // 리스트 길이보다 긴 것은 다음 문장을 실행하지 않음.
            nextActivation(currentIdx); // 다음 층 set active하게
        
        currentIdx++; 
    }

    public GameObject FindProperEnemy(int id)
    {
        for(int i = 0; i < enemyArray.Length; i ++)
        {
            if(id == enemyArray[i].GetComponent<EnemyData>().enemyId){
                return enemyArray[i];
            }
        }
        Debug.Log("Error: no One is matched with Input!!");
        return enemyArray[0];
    }
}
