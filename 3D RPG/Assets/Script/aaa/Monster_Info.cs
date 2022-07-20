using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Info : Info
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Set_Info()
    {
        name = "Monster";
        Level = 1;
        Max_Hp = 50;
        Hp = Max_Hp;
        Attack_Min = 2;
        Attack_Max = 5;
        Defense = 1;

        Exp = 10;
        Reward_Money = Random.Range(10, 31);
        Is_Dead = false;
    }

    protected override void Update_After_Receive_Attack()
    {
        base.Update_After_Receive_Attack();
    }

    public string Name;
    public int Exp { get; set; }
    public int Reward_Money { get; set; }
}
