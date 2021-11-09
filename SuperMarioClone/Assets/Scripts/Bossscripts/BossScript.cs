using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject stone;
    public Transform attackInstantiate;
    private Animator anim;
    private string coroutine_Name = "StartAttack";
    private BossHealth bossHealth;
    private bool isBossDead;


    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        bossHealth = GetComponent<BossHealth>();
       
        
        
        
      
    }

    private void Start()
    {
        StartCoroutine(coroutine_Name);
        isBossDead = false;
      
        
        
    }
    private void Update()
    {
        
        if(bossHealth.BossHealthValue == 0 && isBossDead == false )
        {
            DeadBoss();
            StopCoroutine(coroutine_Name);
          
        }
       
        
    }
   
    void BackToIdle()
    {
        anim.Play("BossIdle");
    }

    void BossAttack()
    {
       GameObject obj =  Instantiate(stone, attackInstantiate.position, Quaternion.identity);
    }

    void DeadBoss()
    {
        isBossDead = true;
        anim.Play("BossDead");
    }

  public  IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        anim.Play("BossAttack");
        StartCoroutine(coroutine_Name);
    }


















}//CLASS
