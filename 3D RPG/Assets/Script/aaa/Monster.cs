using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public enum Monster_State
    {
        IDLE,CHASE,ATTACK,DEAD,END
    }
    // Start is called before the first frame update
    void Start()
    {
        Cur_State = Monster_State.IDLE;
        
        Player = GameObject.FindGameObjectWithTag("Player");

        Hit_Effect.Stop();

        My_Animation = GetComponent<Animation>();

        My_Info = GetComponent<Monster_Info>();
        My_Info.Dead_Event.AddListener(Call_Dead_Event);
    }

    // Update is called once per frame
    void Update()
    {
        Update_State();
    }

    protected void Update_State()
    {
        switch (Cur_State)
        {
            case Monster_State.IDLE:
                Idle_State();
                break;
            case Monster_State.CHASE:
                Chase_State();
                break;
            case Monster_State.ATTACK:
                Attack_State();
                break;
            case Monster_State.DEAD:
                Dead_State();
                break;
            case Monster_State.END:
                break;
        }
    }

    protected void Idle_State()
    {
        if(Get_Dis_Player() < Chase_Dis)
        {
            Change_State(Monster_State.CHASE);
        }
    }

    protected void Chase_State()
    {
        if(Get_Dis_Player()<Attack_Dis)
        {
            Change_State(Monster_State.ATTACK);
        }
        else
        {
            Turn_To_Destination();
            Move_To_Destination();
        }
    }

    protected void Attack_State()
    {
        if(Get_Dis_Player() > Re_Chase_Dis)
        {
            Attack_Timer = 0f;
            Change_State(Monster_State.CHASE);
        }
        else
        {
            if(Attack_Timer > Attack_Delay)
            {
                transform.LookAt(Player.transform.position);
                Change_Animation(Monster_State.ATTACK);

                Attack_Timer = 0f;
            }
        }

        Attack_Timer += Time.deltaTime;
    }

    protected void Dead_State()
    {
        GetComponent<BoxCollider>().enabled = false;
    }

    public void Change_State(Monster_State _New_State)
    {
        if (Cur_State == _New_State)
            return;

        Cur_State = _New_State;
        Change_Animation(_New_State);
    }

    public void Change_Animation(Monster_State _New_State)
    {
        switch (_New_State)
        {
            case Monster_State.IDLE:
                My_Animation.CrossFade("idle");
                break;
            case Monster_State.CHASE:
                My_Animation.CrossFade("walk");
                break;
            case Monster_State.ATTACK:
                My_Animation.CrossFade("attack1");
                break;
            case Monster_State.DEAD:
                My_Animation.CrossFade("death1");
                break;
            case Monster_State.END:
                break;
        }

    }

    protected void Turn_To_Destination()
    {
        Quaternion LookRotation = Quaternion.LookRotation(Player.transform.position - transform.position);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, LookRotation, Time.deltaTime * Angle_Per_Speed);
    }

    protected void Move_To_Destination()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Move_Speed * Time.deltaTime);
    }

    protected float Get_Dis_Player()
    {
        float Dis = Vector3.Distance(transform.position, Player.transform.position);

        return Dis;
    }

    public void Active_Hit_Effect()
    {
        Hit_Effect.Play();
    }

    protected void Call_Dead_Event()
    {
        Change_State(Monster_State.DEAD);
        Player.SendMessage("Current_Enemy_Dead");
    }


    public Monster_State Cur_State;

    protected GameObject Player;

    protected float Chase_Dis;
    protected float Attack_Dis;
    protected float Re_Chase_Dis;

    protected float Angle_Per_Speed;
    protected float Move_Speed;

    protected float Attack_Delay;
    protected float Attack_Timer;


    public ParticleSystem Hit_Effect;

    Animation My_Animation;
    Monster_Info My_Info;
}
