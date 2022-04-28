using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_1 : Monster
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void State_Check()
    {


    }

    protected override void State_Act()
    {
        switch (State)
        {
            case Monster_State.Monster_Idle:

                break;
            case Monster_State.Monster_Move:
                break;
            case Monster_State.Monster_Dead:
                break;
            case Monster_State.Monster_End:
                break;
            default:
                break;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Character")
        {
            Player_Manager.Instance.Get_Player().GetComponent<Character>().Collision_Back();
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }



    protected override void State_Idle()
    {
    }

    protected override void State_Move()
    {
    }

    protected override void State_Dead()
    {
    }



}