using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public int HP = 100;
    public float speed;
    public SpriteRenderer sr;
    public PlayerController playerController;
    Vector2 moveVec = new Vector2(0, 0);
    Vector3 dirVec = Vector3.left;
    Rigidbody2D rigid;
    Animator anim;
    GameObject scannedObject;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = this.GetComponent<SpriteRenderer>();
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


    void Defeated(){

        Destroy(this.gameObject);
    }

    public void TakeDamage(int dmg)
    {
        HP -= dmg;
        Debug.Log(HP+ " is left!!");
        if(HP <= 0){
            sr.material.color = new Color(1 ,1, 1, 0.4f);
            Invoke("Defeated", 1.0f);
        }
    }
}
