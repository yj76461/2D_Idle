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

    public int currentIdx = 0; // 현재 층을 인덱스로 나타내는 전역 변수, 결코 감소하지 않는다. 현재 층에 대한 정보가 필요 없다면 웬만ㄴ하면 접근하지 말자
    Vector3 dungeonPosition = new Vector3(0f, 0f, 0f);
    void Awake()
    {
        enemyInfo = CSVReader.Read("enemyInfo");
        dungeonInfo = CSVReader.Read("dungeonInfo"); // dungeon id 는 1부터 시작 dungeon list는 0부터 시작
        // 특별히 id를 지칭해야 하는 상황이 나오지 않는 이상 currentIdx 변수를 사용하여 0부터 표현하는 식으로 구성할 것이다.

        for (int i = 0; i < enemyArray.Length; i++)
        {
            // 적 정보 대입
            enemyArray[i].GetComponent<EnemyData>().GenerateEnemyData((int)enemyInfo[i]["enemyId"],
                                                                    enemyInfo[i]["enemyName"].ToString(),
                                                                    (int)enemyInfo[i]["enemyHP"],
                                                                    (int)enemyInfo[i]["enemyMoney"],
                                                                    enemyInfo[i]["enemyItem"].ToString());
        }
        
    }
    void Start()
    {
            buyButton.GetComponent<Button>().onClick.AddListener(SpawnDungeon);
            
            Debug.Log("current idx: " + currentIdx);
    }

    void Update()
    {
        //button 은 UI 계열이라 좌표 건들 때 조금 특이한 방식으로 변경
        //Debug.Log(dungeonList[currentIdx - 1].transform.position);
        buyButton.transform.position = Camera.main.WorldToScreenPoint(
            dungeonList[currentIdx - 1].transform.position + new Vector3(0f, 3.0f, 0f));
    }

    public void nextActivation(int nextIdx)
    {
        // 가림막용 가짜던전은 맵 완전 구석에 치워두고 이 함수가 최초로 실행될 때부터 정상적인 좌표를 갖도록 구성
        fakeDungeon.transform.position = dungeonList[nextIdx].transform.position + new Vector3(0, 3.0f, 0);

        GameObject currentWeapon = dungeonList[nextIdx].transform.GetChild(0).GetChild(0).GetChild(0).gameObject; // active 됐을 때 무기 스프라이트 정보 받아옴
        currentWeapon.GetComponent<SpriteRenderer>().sprite = weaponManager.swordList[gameManager.weaponIdx];
    }

   
    public void SpawnDungeon()
    {
        GameObject newDungeon = Instantiate(dungeonPrefab, new Vector3(-10.0f, 0f, 0f), Quaternion.identity); // 외진 곳에 새로운 던전이 될 던전을 인스턴스화
        newDungeon.name = "dungeon idx : " + currentIdx;
        dungeonList.Add(newDungeon);
        DungeonData newDungeonData = dungeonList[currentIdx].GetComponent<DungeonData>(); // 생성한 던전을 리스트에 넣고 데이터 뽑아옴.
        


        newDungeonData.GenerateDungeonData(
            currentIdx,    
            (int)dungeonInfo[currentIdx]["dungeonId"],
            (int)dungeonInfo[currentIdx]["dungeonPrice"],
            FindProperEnemy((int)dungeonInfo[currentIdx]["dungeonEnemyId"]),
            true
        );
        newDungeon.transform.position = dungeonPosition;

        gameManager.SpawnEnemy(currentIdx, dungeonPosition);
        dungeonPosition.y = dungeonPosition.y + 3.0f;
        currentIdx++; // 다음 던전을 열기위해 하나 증가
        
    }

    public GameObject FindProperEnemy(int id)
    {
        for(int i = 0; i < enemyArray.Length; i ++)
        {
            if(id == enemyArray[i].GetComponent<EnemyData>().enemyId){
                //Debug.Log("Got it!! input id is " + id + "and enemyId is " + enemyArray[i].GetComponent<EnemyData>().enemyId + "and array index is " + i);
                return enemyArray[i];
            }
        }
        Debug.Log("Error: no One is matched with Input!! id is : " + id);
        return enemyArray[0];
    }
}
