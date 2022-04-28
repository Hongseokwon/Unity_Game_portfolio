using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public struct Monster_Info
    {
        int Hp;
        int Att;
    }

    public enum Monster_State
    {
        Monster_Idle, Monster_Move, Monster_Dead, Monster_End
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        State_Check();
        State_Act();
    }

    protected virtual void State_Check() { }
    protected virtual void State_Act() { }
    protected virtual void State_Idle() { }
    protected virtual void State_Move() { }
    protected virtual void State_Attack() { }
    protected virtual void State_Dead() { }
    


    protected Monster_State State;
    protected Monster_Info Info;
}
