using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    Dictionary<string, int> weaponData;
    
    public Sprite[] swordList;
    
    void Awake()
    {
        weaponData = new Dictionary<string, int>();
        GenerateWeaponData();

    }

    void GenerateWeaponData(){
        weaponData.Add("lv1gum", 80);
        weaponData.Add("lv2gum", 90);
        weaponData.Add("lv3gum", 110);
        weaponData.Add("lv4gum", 120);
        weaponData.Add("lv5gum", 130);
        weaponData.Add("lv6gum", 150);
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
