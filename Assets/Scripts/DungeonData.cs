using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonData : MonoBehaviour
{
    public GameManager gameManager;
    public int dungeonId;
    public int dungeonPrice;
    public GameObject button;
    public Button btn;
    
    public bool isActivated = false;

    public GameObject[] enemy;

    void Awake()
    {

    }

    void Start()
    {
        btn.onClick.AddListener(ActivateDungeon);
    }

    void Update()
    {
        // 아래 함수가 실행되었을 때 버튼이 비활성화 됐는데 오류 메시지를 띄우진 않음. 추후 오류 발생 시 확인해야할 부분.
        btn.transform.position = Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(0, -1.0f, 0));
    }

    public void ActivateDungeon()
    {
        isActivated = true;
        gameManager.SpawnEnemy(dungeonId);
        button.SetActive(false);
    }
}
