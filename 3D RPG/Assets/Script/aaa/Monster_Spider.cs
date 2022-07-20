using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Spider : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        Chase_Dis = 5f;
        Attack_Dis = 2.5f;
        Re_Chase_Dis = 3f;
        Angle_Per_Speed = 360f;
        Move_Speed = 1.3f;
        Attack_Delay = 2f;
        Attack_Timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
