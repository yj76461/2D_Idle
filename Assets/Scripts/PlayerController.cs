using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public WeaponManager weaponManager;
    public int dmg= 0;
    Vector3 dirVec = Vector3.right;
    float h, v;
    Rigidbody2D rigid;
    Animator anim;
    GameObject scannedObject;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        if(scannedObject != null)
        {
            anim.SetBool("canAttack", true);
            //Debug.Log(scannedObject); 인식하는지 아닌지 디버깅 용
            dmg = weaponManager.getWeapon("lv1gum");
            //Debug.Log(dmg + " is my damage!");

        }
        else
        {
            anim.SetBool("canAttack", false);
            //Debug.Log(dmg + " is my damage!");
        }

    }

    void FixedUpdate()
    {
        Debug.DrawRay(rigid.position, dirVec * 1.5f, new Color(1, 0, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 1.5f, LayerMask.GetMask("Enemy"));

        if(rayHit.collider != null )
        {
            scannedObject = rayHit.collider.gameObject;
        }
        else
            scannedObject = null;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            col.GetComponent<EnemyController>().TakeDamage(10);
            Debug.Log("성공");
        }
        else
            Debug.Log("fail!");
    }
}
