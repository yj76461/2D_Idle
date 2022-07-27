using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

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
            Debug.Log(scannedObject);
        }
        else
        {
            anim.SetBool("canAttack", false);
        }

    }

    // Update is called once per frame
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
}
