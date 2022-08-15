using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : MonoBehaviour
{
    public string weaponName;
    public int attackDamage;
    public int price;
    public bool canUse = false;
    public float atkSpeed = 0f;

    public void GenerateWeaponData(string name, int damage)
    {
        weaponName = name;
        attackDamage = damage;
    }
}
