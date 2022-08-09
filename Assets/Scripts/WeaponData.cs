using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : MonoBehaviour
{
    public string weaponName;
    public int attackDamage;

    public int price;
    public float atkSpeed = 0f;

    public WeaponData(string name, int damage)
    {
        weaponName = name;
        attackDamage = damage;
    }
}
