using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonData : MonoBehaviour
{
    public int dungeonId;
    public int dungeonPrice;
    public GameObject button;
    public bool isActivated = true;

    public GameObject[] enemy;

    void Awake()
    {

    }

    void Update()
    {
        
        button.transform.position = Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(0, -1.0f, 0));
    }
}
