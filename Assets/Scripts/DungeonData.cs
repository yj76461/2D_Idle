using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonData : MonoBehaviour
{
    public GameManager gameManager;
    public DungeonManager dungeonManager;
    public int dungeonId;
    public int dungeonPrice;
    public GameObject button;
    public Button btn;
    
    public bool isActivated = false;

    public GameObject dungeonEnemy;

    public SpriteRenderer transLayer;

    void Awake()
    {
        transLayer.material.color = new Color(0f, 0f, 0f, 0.8f);
    }

    void Start()
    {
        btn.onClick.AddListener(OperateDungeon);
    }

    void Update()
    {
        // 아래 함수가 실행되었을 때 버튼이 비활성화 됐는데 오류 메시지를 띄우진 않음. 추후 오류 발생 시 확인해야할 부분.
        btn.transform.position = Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(0, -1.0f, 0));
    }

    public void OperateDungeon()
    {
        isActivated = true;
        gameManager.SpawnEnemy(dungeonId);
        button.SetActive(false);
        transLayer.material.color = new Color(0f, 0f, 0f, 0.0f);

        if(dungeonManager.dungeons.Length - 1 > dungeonId) // 배열 벗어나는 것 예외 처리
            dungeonManager.nextActivation(dungeonId + 1); // 다음 층 set active하게
    }

    public void GenerateDungeonData(int currentFloor, int price, GameObject enemy, bool activate)
    {
        dungeonId = currentFloor;
        dungeonPrice = price;
        dungeonEnemy = enemy;
        isActivated = activate;
    }
}
