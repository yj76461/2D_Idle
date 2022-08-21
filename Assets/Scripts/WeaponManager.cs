using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<Dictionary<string, object>> weaponInfo = new List<Dictionary<string, object>>();
    
    public Sprite[] swordList;
    
    void Awake()
    {
        weaponInfo = CSVReader.Read("weaponInfo");

        // for(int i = 0; i < weaponInfo.Count; i++)
        // {
        //     Debug.Log("weapon ID: "+ weaponInfo[i]["weaponId"] + " " +
        //     "weapon name: " + weaponInfo[i]["weaponName"] + " " + 
        //     "weapon atk: " + weaponInfo[i]["weaponAtk"] + " ");
        // }

    }

    
}
