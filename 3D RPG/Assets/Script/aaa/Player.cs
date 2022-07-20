using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public enum Player_State
    {
        IDLE, MOVE, ATTACK, ATTACKWAIT, DEAD, END
    }

    // Start is called before the first frame update
    void Start()
    {
        Player_Animator = GetComponent<Animator>();

        Cur_State = Player_State.IDLE;

        Rotate_Speed = 360f;
        Move_Speed = 2f;
        Attack_Delay = 2f;
        Attack_Timer = 0f;
        Attack_Distance = 1.5f;
        Chase_Distance = 2.5f;

        My_Info = GetComponent<Player_Info>();

        My_Info.Set_Info();
    }

    // Update is called once per frame
    void Update()
    {
        Update_State();
    }

    private void Change_State(Player_State _NewState)
    {
        if (Cur_State == _NewState)
            return;

        Player_Animator.SetInteger("Aniname", (int)_NewState);
        Cur_State = _NewState;
    }

    private void Update_State()
    {
        switch (Cur_State)
        {
            case Player_State.IDLE:
                Idle_State();
                break;
            case Player_State.MOVE:
                Move_State();
                break;
            case Player_State.ATTACK:
                Attack_State();
                break;
            case Player_State.ATTACKWAIT:
                Attack_Wait_State();
                break;
            case Player_State.DEAD:
                Dead_State();
                break;
            case Player_State.END:
                break;
        }
    }

    public void MoveTo(Vector3 _Pos)
    {
        Cur_Enemy = null;
        curTargetPos = _Pos;
        Change_State(Player_State.MOVE);
    }

    private void TurnToDestination()
    {
        Quaternion LookRotateion = Quaternion.LookRotation(curTargetPos - transform.position);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, LookRotateion, Time.deltaTime * Rotate_Speed);
    }

    private void MoveToDestination()
    {
        transform.position = Vector3.MoveTowards(transform.position, curTargetPos, Move_Speed * Time.deltaTime);

        if (Cur_Enemy == null)
        {
            if (transform.position == curTargetPos)
            {
                Change_State(Player_State.IDLE);
            }
        }
        else if (Vector3.Distance(transform.position, curTargetPos) < Attack_Distance)
        {
            Change_State(Player_State.ATTACK);
        }
    }


    private void Idle_State()
    {

    }

    private void Move_State()
    {
        TurnToDestination();
        MoveToDestination();
    }

    private void Attack_State()
    {
        Attack_Timer = 0f;

        transform.LookAt(curTargetPos);
        Change_State(Player_State.ATTACKWAIT);
    }

    private void Attack_Wait_State()
    {
        if(Attack_Timer>Attack_Delay)
        {
            Change_State(Player_State.ATTACK);
        }

        Attack_Timer += Time.deltaTime;
    }

    private void Dead_State()
    {

    }

  

    public void Attack_Enemy(GameObject _Enemy)
    {
        if (Cur_Enemy != null && Cur_Enemy == _Enemy)
            return;

        Cur_Enemy = _Enemy;

        if (Cur_Enemy.GetComponent<Monster_Info>().Is_Dead == false)
        {
            curTargetPos = Cur_Enemy.transform.position;

            Change_State(Player_State.MOVE);
        }
    }

    public void Attack_Calculate()
    {
        if(Cur_Enemy == null)
            return;

        Cur_Enemy.GetComponent<Monster>().Active_Hit_Effect();

        int Attack_Power = My_Info.Get_Random_Attack();
        Cur_Enemy.GetComponent<Monster_Info>().Set_Enemy_Attack(Attack_Power);
    }
  
    Animator Player_Animator;

    public Player_State Cur_State;

    Vector3 curTargetPos;

    private float Rotate_Speed;
    private float Move_Speed;

    private float Attack_Delay;
    private float Attack_Timer;
    private float Attack_Distance;
    private float Chase_Distance;

    GameObject Cur_Enemy;

    Player_Info My_Info;
}
