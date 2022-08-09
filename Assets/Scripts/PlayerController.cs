using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public WeaponManager weaponManager;
    public GameManager gameManager;
    public BarController barController;
    public int dmg= 0;
    public float atkSpeed = 0.2f;
    public float myExp = 0;
    public float enemyExp = 0;
    public int enemyHP;
    Vector3 dirVec = Vector3.right;
    float h, v;
    Rigidbody2D rigid;
    Animator anim;
    GameObject scannedObject;

    bool canSpawn = true;
    bool canAttack = true;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(scannedObject != null)
        {
            anim.SetBool("doAttack", true);
            //Debug.Log(scannedObject); 인식하는지 아닌지 디버깅 용
            dmg = weaponManager.getWeapon("lv1gum");
            //Debug.Log(dmg + " is my damage!");
            enemyExp = scannedObject.GetComponent<EnemyData>().enemyExp;

        }
        else
        {
            anim.SetBool("doAttack", false);
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
            if(canAttack == true){
                enemyHP = col.GetComponent<EnemyController>().TakeDamage(dmg);
                canAttack = false;
                StartCoroutine("AttackDelay"); // 딜레이줘서 한번에 여러대 때리기 방지
            }

            //Debug.Log(enemyHP); // 현 어택 속도일 때, 한번의 공격에서 네번의 충돌 발생 확인.
            if(enemyHP <= 0 && canSpawn == true)
            {
                canSpawn = false;
                //Debug.Log("소환합니다.");
                myExp += enemyExp;
                gameManager.GetMoney(col);
                gameManager.CheckLevelUp(myExp);
        
                StartCoroutine("SpawnDelay");
                SpawnCall();
            }
        }
        else
            Debug.Log("fail!");
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(0.3f);
        canAttack = true;
    }

    IEnumerator SpawnDelay() // 한번에 여러번 돈이 오르고 스폰이 되는 것을 방지
    {
        yield return new WaitForSeconds(0.5f);
        canSpawn = true;
    }

    public void SpawnCall()
    {
        gameManager.SpawnEnemy();
    }
}
