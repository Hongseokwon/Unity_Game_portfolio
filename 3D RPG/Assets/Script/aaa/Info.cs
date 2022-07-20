using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Info : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Set_Info();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Set_Info() { }

    public int Get_Random_Attack()
    {
        int rand_Attack = Random.Range(Attack_Min, Attack_Max + 1);
        return rand_Attack;
    }

    public void Set_Enemy_Attack(int _Enemy_Attack_Power)
    {
        Hp -= _Enemy_Attack_Power;
        Update_After_Receive_Attack();
    }

    protected virtual void Update_After_Receive_Attack()
    {
        print(name + "'s HP:" + Hp);

        if (Hp <= 0)
        {
            Hp = 0;
            Is_Dead = true;
            Dead_Event.Invoke();
        }
    }



    public int Level { get; set; }
    public int Max_Hp { get; set; }
    public int Hp { get; set; }
    public int Attack_Min { get; set; }
    public int Attack_Max { get; set; }
    public int Defense { get; set; }
    public bool Is_Dead { get; set; }

    [System.NonSerialized]
    public UnityEvent Dead_Event = new UnityEvent();
}
