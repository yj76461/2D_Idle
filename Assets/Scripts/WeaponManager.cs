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
        weaponData.Add("lv1gum", 10);
        weaponData.Add("lv2gum", 11);
        weaponData.Add("lv3gum", 12);
        weaponData.Add("lv4gum", 13);
        weaponData.Add("lv5gum", 14);
        weaponData.Add("lv6gum", 15);
    }
    
    public int getWeapon(string name)
    {
        return weaponData[name];
    }
}
