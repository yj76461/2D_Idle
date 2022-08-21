using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    Dictionary<string, int> weaponData;
    public List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
    
    public Sprite[] swordList;
    
    void Awake()
    {
        data = CSVReader. Read("weaponInfo");
        weaponData = new Dictionary<string, int>();


        // for(int i = 0; i < data.Count; i++)
        // {
        //     Debug.Log("weapon ID: "+ data[i]["weaponId"] + " " +
        //     "weapon name: " + data[i]["weaponName"] + " " + 
        //     "weapon atk: " + data[i]["weaponAtk"] + " ");
        // }

    }


    // public void GenerateWeaponData(int weaponId, string name, int damage, int price)
    // {
    //     weaponName = name;
    //     attackDamage = damage;
    // }

    public int getWeaponAtk(string name)
    {
        return weaponData[name];
    }

    

    
}
