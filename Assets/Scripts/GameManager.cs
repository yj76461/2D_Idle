using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Enemy;
    //public PlayerController playerController;

    void SpawnEnemy(){
        GameObject enemy = Instantiate(Enemy, new Vector3(3.3f, -0.9f, 0), Quaternion.identity);
    }
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 6.0f, 5.0f);
    }

    void Update()
    {
        
    }
}
