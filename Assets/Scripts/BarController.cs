using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    public Slider expBar;
    public GameManager gameManager;
    float targetExp = 0.0f;
    float timeScale = 0.0f;
    bool lerpingExp = false;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    
    public void touchExpBar(float exp, float nextLevelUpExp)
    {
        targetExp = (exp / nextLevelUpExp); // 총 exp량 / 현 레벨 경험치 통
        Debug.Log("target exp is " + targetExp);
        if(targetExp >= 1.0f) // lv up했을때 경험치 바 다시 원복 시켜주기
        {  
            targetExp %= 1.0f;
        }

        if(!lerpingExp)
        {
            StartCoroutine(LerpExp());
        }
    }
    // exp 바 부드럽게 해주는 코루틴
    IEnumerator LerpExp()
    {
        float speed = 2.0f;
        float startExp = expBar.value;
        Debug.Log("exp bar: " + expBar.value);
        lerpingExp = true;

        while(timeScale < 1)
        {
            yield return new WaitForEndOfFrame(); // 매 프레임마다 한번씩 기다려주기, 이거 없으면 너무 빠르게 증가해서 부드러운 동작이 안보임.
            timeScale += Time.deltaTime * speed;
            
            expBar.value = Mathf.Lerp(startExp, targetExp, timeScale);
        }
        
        timeScale = 0.0f;
        lerpingExp = false;
    }
}
