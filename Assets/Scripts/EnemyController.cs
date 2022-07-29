using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public int HP = 100;
    public float speed = 10.0f;
    public SpriteRenderer sr;
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
            rigid.velocity = moveVec / speed;
        }
        else{
            anim.SetBool("doRun", true);
            rigid.velocity = moveVec;
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
            anim.SetBool("isAttacked", true);
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        anim.SetBool("isAttacked", false);
    }

    void Defeated(){
        Destroy(this.gameObject);
    }

    public int TakeDamage(int dmg)
    {
        
        if(HP > 0)
            HP -= dmg;
        else{
            //rigid.bodyType = RigidbodyType2D.Static;
            sr.material.color = new Color(1 ,1, 1, 0.4f);
            Invoke("Defeated", 0.2f);
        }
        return HP;
    }
}
