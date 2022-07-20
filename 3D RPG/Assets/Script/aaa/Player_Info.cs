using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Info : Info
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

    public override void Set_Info()
    {
        Name = "SYW";
        Level = 1;
        Max_Hp = 100;
        Hp = Max_Hp;
        Attack_Min = 5;
        Attack_Max = 8;
        Defense = 1;

        Cur_Exp = 0;
        Exp_To_NextLevel = 100 * Level;
        Money = 0;

        Is_Dead = false;

    }

    protected override void Update_After_Receive_Attack()
    {
        base.Update_After_Receive_Attack();
    }

    public string Name { get; set; }
    public int Cur_Exp { get; set; }
    public int Exp_To_NextLevel { get; set; }
    public int Money { get; set; }
}
