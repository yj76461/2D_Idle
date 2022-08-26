using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] Enemy;
    //public Button storeBtn;
    public GameObject store;
    public int money = 0;
    public int weaponIdx;
    public Text moneyText;
    public Text lvText;
    public Text weaponInformation;
    public Slider expBar;
    public BarController barController;
    public DungeonManager dungeonManager;
    public WeaponManager weaponManager;
    GameObject currentWeapon;
    bool storeIsOpen = false;
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
        
        //storeBtn.onClick.AddListener(OpenCloseStore);
    }
    void Start()
    {
        dungeonManager.SpawnDungeon(); // 최초 인덱스 0에 접근하여 첫 던전 문 연다.
        InitializeWeapon();
        //SpawnEnemy(0, new Vector3(0f,0f,0f));

    }

    void Update()
    {

    }
    public int GetItems(Collider2D enemy)
    {
        money += Random.Range(enemy.GetComponent<EnemyData>().enemyMoney - 5,
                             enemy.GetComponent<EnemyData>().enemyMoney + 5); // 돈 범위 정해서 랜덤하게 주어지게
        moneyText.text = money.ToString();
        return money;
    }

    
    public void SpawnEnemy(int floor, Vector3 currentPosition){
        GameObject currentDungeon = dungeonManager.dungeonList[floor];
        Vector3 currentDungeonPosition = currentPosition;
        
        if(currentDungeon.GetComponent<DungeonData>().isActivated == true){
            GameObject enemy = Instantiate(currentDungeon.GetComponent<DungeonData>().dungeonEnemy , new Vector3(currentDungeonPosition.x + 3.0f, currentDungeonPosition.y - 2.0f, 0), Quaternion.identity);
        }

        //int randSpawn = Random.Range(0, Enemy.Length);
        //GameObject enemy = Instantiate(Enemy[randSpawn], new Vector3(3.3f, -1.07f, 0), Quaternion.identity);
    }

    public void RespawnEnemy(GameObject enemy)
    {
        
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

    public void OpenCloseStore()
    {
        if(storeIsOpen == false)
        {
            store.SetActive(true);
            storeIsOpen = true;
        }
        else
        {
            store.SetActive(false);
            storeIsOpen = false;
        }

    }

    public void ChangeWeapon()
    {
        int idx = Random.Range(0,6);
        for(int i = 0; i < dungeonManager.dungeonList.Count ; i++) // 각 던전에 모두 적용
        {
            // 각 던전 내 소속된 무기에 접근
            currentWeapon = dungeonManager.dungeonList[i].transform.GetChild(0).GetChild(0).GetChild(0).gameObject; // 자식 오브젝트 접근법

            currentWeapon.GetComponent<SpriteRenderer>().sprite = weaponManager.swordList[idx];
            currentWeapon.GetComponent<WeaponData>().weaponName = weaponManager.weaponInfo[idx]["weaponName"].ToString();
            currentWeapon.GetComponent<WeaponData>().weaponAtk = (int)weaponManager.weaponInfo[idx]["weaponAtk"];

        }
        //디스플레이에 디버그 로그(현 무기정보) 띄우기
        weaponInformation.text ="weapon Name" + '\n' + currentWeapon.GetComponent<WeaponData>().weaponName + '\n' +
                                "weaponAtk" + currentWeapon.GetComponent<WeaponData>().weaponAtk + '\n' +
                                "weapon Price" + currentWeapon.GetComponent<WeaponData>().weaponPrice;
        weaponIdx = idx;
    }

    public void InitializeWeapon()
    {
        for(int i = 0; i < dungeonManager.dungeonList.Count ; i++) // 각 던전에 모두 적용
        {
            // 각 던전 내 소속된 무기에 접근
            currentWeapon = dungeonManager.dungeonList[i].transform.GetChild(0).GetChild(0).GetChild(0).gameObject; // 자식 오브젝트 접근법

            currentWeapon.GetComponent<SpriteRenderer>().sprite = weaponManager.swordList[0];
            currentWeapon.GetComponent<WeaponData>().weaponName = weaponManager.weaponInfo[0]["weaponName"].ToString();
            currentWeapon.GetComponent<WeaponData>().weaponAtk = (int)weaponManager.weaponInfo[0]["weaponAtk"];
        }

         weaponInformation.text ="weapon Name" + '\n' + currentWeapon.GetComponent<WeaponData>().weaponName + '\n' +
                                "weaponAtk" + currentWeapon.GetComponent<WeaponData>().weaponAtk + '\n' +
                                "weapon Price" + currentWeapon.GetComponent<WeaponData>().weaponPrice;
    }
}
