using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int HP;
    public float speed;
    Vector2 moveVec = new Vector2(0, 0);
    Vector3 dirVec = Vector3.left;
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
        moveVec = new Vector2(-speed, 0);
        if(scannedObject != null){
            anim.SetBool("doRun", false);
            rigid.velocity = new Vector2(0, 0);
        }
        else{
            anim.SetBool("doRun", true);
            rigid.velocity = moveVec * speed;
        }
    }

    void FixedUpdate()
    {
        Debug.DrawRay(rigid.position, dirVec * 1.0f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 1.0f, LayerMask.GetMask("Player"));

        if(rayHit.collider != null )
        {
            scannedObject = rayHit.collider.gameObject;
        }
        else
            scannedObject = null;
    }
}
