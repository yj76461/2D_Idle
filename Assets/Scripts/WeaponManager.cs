using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    Dictionary<string, int> weaponData;
    
    void Awake()
    {
        weaponData = new Dictionary<string, int>();
        GenerateData();

    }

    void GenerateData(){
        weaponData.Add("lv1gum", 80);
        weaponData.Add("lv2gum", 20);
        weaponData.Add("lv3gum", 50);
        weaponData.Add("lv4gum", 13);
        weaponData.Add("lv5gum", 14);
        weaponData.Add("lv6gum", 15);
    }

    public int getWeaponAtk(string name)
    {
        return weaponData[name];
    }
}
