using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : MonoBehaviour
{
    public WeaponManager weaponManager;
    public string weaponName;
    public int attackDamage;
    public int price;
    public bool canUse = false;
    public float atkSpeed = 0f;

    public SpriteRenderer weaponSprite;

    void Awake()
    {
        weaponSprite = gameObject.GetComponent<SpriteRenderer>();
        weaponSprite.sprite = weaponManager.swordList[0];
    }
    
}
