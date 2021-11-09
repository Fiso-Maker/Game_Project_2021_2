﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 스킬 구현 필요

public class FSM : MonoBehaviour
{
    #region Stat Variable declare
    
    public Stat _stat;

    public int health;
    [HideInInspector]
    private int TPRegeneration;
    private int defense;
    private int damage;
    private float moveSpeed;
    private int needTP;
    private float range;
    private float attackdelayTime;

    #endregion

    #region Variable

    public bool m_Death;
    public bool able_to_attack;
    public bool able_to_use_tpskill;
    
    private float timer;

    public int TP;
    [HideInInspector]
    
    Animator anim;
    SpriteRenderer spriteRenderer;

    #endregion

    public enum Type
    {
        Character,
        Enemy
    }
    public Type CharacterType;

    public enum State
    {
        Idle,
        Move,
        Attack,
        Death,
        Win
    }
    public State startState = State.Idle;
    private State currentState;


    #region Internal-------------------------- # Please close # --------------------------
    private enum StateFlow
    {
        ENTER,
        UPDATE,
        EXIT
    }

    private void SetStartState(State startState)
    {
        currentState = startState;

        switch (currentState)
        {
            case State.Idle: Idle(StateFlow.ENTER); break;
            case State.Move: Move(StateFlow.ENTER); break;
            case State.Attack: Attack(StateFlow.ENTER);  break;
            case State.Death: Death(StateFlow.ENTER); break;
            case State.Win: Win(StateFlow.ENTER); break;
        }
    }

    void Update()
    {
        CommonUpdate();

        switch (currentState)
        {
            case State.Idle: Idle(StateFlow.UPDATE); break;
            case State.Move: Move(StateFlow.UPDATE); break;
            case State.Attack: Attack(StateFlow.UPDATE); break;
            case State.Death: Death(StateFlow.UPDATE); break;
            case State.Win: Win(StateFlow.UPDATE); break;
        }
    }

    private void ChangeState(State nextState)
    {
        switch (this.currentState)
        {
            case State.Idle: Idle(StateFlow.EXIT); break;
            case State.Move: Move(StateFlow.EXIT); break;
            case State.Attack: Attack(StateFlow.EXIT); break;
            case State.Death: Death(StateFlow.EXIT); break;
            case State.Win: Win(StateFlow.EXIT); break;
        }

        this.currentState = nextState;

        switch (this.currentState)
        {
            case State.Idle: Idle(StateFlow.ENTER); break;
            case State.Move: Move(StateFlow.ENTER); break;
            case State.Attack: Attack(StateFlow.ENTER); break;
            case State.Death: Death(StateFlow.ENTER); break;
            case State.Win: Win(StateFlow.ENTER); break;
        }
    }
    #endregion;


    void Start()
    {
        Init();
        SetStartState(startState);
    }


    private void CommonUpdate()
    {
        if(able_to_use_tpskill)
        {
            var a = this.GetComponent<Character>().UPButton.GetComponent<Image>();
            a.color = new Color32(255,255,255,255);
        }
    }

    private void Init()
    {
        health  =_stat._health;
        TPRegeneration  =_stat._TPRegeneration;
        defense =_stat._defense;
        damage  =_stat._damage;
        moveSpeed = _stat._moveSpeed;
        needTP = _stat._needTP;
        range = _stat._range;

        m_Death = false;
        able_to_use_tpskill= false;
        able_to_attack = true;

        attackdelayTime = _stat._AttackdelayTime;
        timer = 0f;
        TP = 0;

        anim = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        if(CharacterType == Type.Enemy)
        {
            transform.localScale = new Vector3(-1,1,1);
            spriteRenderer.color = new Color32(255,255,255,100);
        } 
    }
#region State FSM 관련
//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  
    
    private void Idle(StateFlow stateFlow)
    {
        switch (stateFlow)
        {
            case StateFlow.ENTER:
                Debug.Log($"<color=yellow>{this.name}</color> - 상태 : {currentState},   상태단계 : {stateFlow}");
                Idle_Enter();
                break;
            case StateFlow.UPDATE:
                Idle_Update();
                break;
            case StateFlow.EXIT:
                Debug.Log($"<color=yellow>{this.name}</color> - 상태 : {currentState},   상태단계 : {stateFlow}");
                break;
        }
    }

    private void Idle_Enter()
    {
        if(m_Death) ChangeState(State.Death);
    }

    private void Idle_Update()
    {
        if(RayCastCheck())
        {
            ChangeState(State.Attack);
        }
        else{
            ChangeState(State.Move);
        }
    }

//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    private void Move(StateFlow stateFlow)
    {
        switch (stateFlow)
        {
            case StateFlow.ENTER:
                Debug.Log($"<color=yellow>{this.name}</color> - 상태 : {currentState},   상태단계 : {stateFlow}");
                Move_Enter();
                break;
            case StateFlow.UPDATE:
                Move_Update();
                break;
            case StateFlow.EXIT:
                Debug.Log($"<color=yellow>{this.name}</color> - 상태 : {currentState},   상태단계 : {stateFlow}");
                Move_Exit();
                break;
        }
    }

    private void Move_Enter()
    {
        if(m_Death) ChangeState(State.Death);
    }
    private void Move_Update()
    {
        anim.SetBool("isWalk", true);

       if(RayCastCheck())
        {
            ChangeState(State.Attack);
        }
        else{
            if(CharacterType == Type.Character)
                this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
            else
                this.transform.Translate(Vector3.right*-1 * Time.deltaTime * moveSpeed);
        }
    }
    
    private void Move_Exit()
    {
        anim.SetBool("isWalk", false);
    }


//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    private void Attack(StateFlow stateFlow)
    {
        switch (stateFlow)
        {
            case StateFlow.ENTER:
                Debug.Log($"<color=yellow>{this.name}</color> - 상태 : {currentState},   상태단계 : {stateFlow}");
                Attack_Enter();
                break;
            case StateFlow.UPDATE:
                Attack_Update();
                break;
            case StateFlow.EXIT:
                Debug.Log($"<color=yellow>{this.name}</color> - 상태 : {currentState},   상태단계 : {stateFlow}");
                break;
        }
    }

    private void Attack_Enter()
    {
        if(m_Death) ChangeState(State.Death);
    }

    private void Attack_Update()
    {
        if(able_to_attack)
        {   
            if(RayCastCheck())
            {
                
                GameObject damagedObject = RayCastCheck().collider.gameObject;
                anim.SetTrigger("Attack");
                damagedObject.GetComponent<FSM>().TakeHit(damage);
                Debug.Log($"공격한 주체 : <color=green>{gameObject.name}</color> 공격받은 대상 : <color=red>{damagedObject.name}</color> - 대상의 남은 체력 : {damagedObject.GetComponent<FSM>().health}");

                TP += TPRegeneration;
                
                Able_To_Use_TPSkill_Check();
                
                able_to_attack = false;
            }
            else
            {
                ChangeState(State.Idle);
            }
        }
        else
        {
            timer += Time.deltaTime;

            if (timer >= attackdelayTime)

            {

                timer = 0f;

                able_to_attack = true;

            }
        }
    }

//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    private void Death(StateFlow stateFlow)
    {
        switch (stateFlow)
        {
            case StateFlow.ENTER:
                Debug.Log($"<color=yellow>{this.name}</color> - 상태 : {currentState},   상태단계 : {stateFlow}");
                Death_Enter();
                break;
            case StateFlow.UPDATE:
                break;
            case StateFlow.EXIT:
                Debug.Log($"<color=yellow>{this.name}</color> - 상태 : {currentState},   상태단계 : {stateFlow}");
                break;
        }
    }
    private void Death_Enter()
    {
        anim.SetTrigger("isDie");
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }


//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    private void Win(StateFlow stateFlow)
    {
        switch (stateFlow)
        {
            case StateFlow.ENTER:
                Debug.Log($"<color=yellow>{this.name}</color> - 상태 : {currentState},   상태단계 : {stateFlow}");
                break;
            case StateFlow.UPDATE:
                break;
            case StateFlow.EXIT:
                Debug.Log($"<color=yellow>{this.name}</color> - 상태 : {currentState},   상태단계 : {stateFlow}");
                break;
        }
    }

#endregion

#region Method
    private RaycastHit2D RayCastCheck()
    {
        

        if(CharacterType == Type.Character)
        {
            int layerMask = (1 << LayerMask.NameToLayer("Character"));
            layerMask = ~layerMask;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, range, layerMask);
            Debug.DrawRay(transform.position, transform.right*range, Color.blue, 0);
         
            return hit;
        }
        else
        {
            int layerMask = (1 << LayerMask.NameToLayer("Enemy"));
            layerMask = ~layerMask;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right*-1, range, layerMask);
            Debug.DrawRay(transform.position, transform.right*range*-1, Color.blue, 0);
          
            return hit;
        }

    }

    private void TakeHit(int damage)
    {
        if(m_Death) return;

        health -= (damage/(1 + (defense/100)));
        TP += (damage/(1 + (defense/100)))/_stat._health;

        if(health <= 0)
        {
            ChangeState(State.Death);
        }
    }

    private void Able_To_Use_TPSkill_Check()
    {
        if(TP >= needTP)
        {
            able_to_use_tpskill = true;
            TP = needTP;
        }
    }

#endregion
}