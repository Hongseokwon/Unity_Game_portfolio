using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Manager : MonoBehaviour
{
    public struct MONSTER_INFO
    {
        public MONSTER_INFO(Vector3 _Pos)
        {
            Live_Check = false;
            Monster_Pos = _Pos;
        }

        public bool Live_Check;
        public Vector3 Monster_Pos;
    }

    public Monster_Manager()
    {
        Monster_List = new LinkedList<GameObject>();
        Monster_Info = new List<MONSTER_INFO>();

        Monster_Max_Num = 9;
        Monster_Regen_Time = 0f;
        Monster_Regen_Cycle_Time = 5f;
    }
        

    // Start is called before the first frame update
    void Start()
    {
        Monster_Pos_Set();
    }

    // Update is called once per frame
    void Update()
    {
        Monster_Regen();
    }

    public void Add_Monster(GameObject _Monster)
    {
        Monster_List.AddLast(_Monster);
    }

    public void Del_Monster(GameObject _Monster)
    {
        Monster_List.Remove(_Monster);
    }

    public bool Is_Monster(GameObject _Obj)
    {
        if(Monster_List.Find(_Obj) == null)
        {
            return false;
        }
        return true;
    }

    private Vector3 Random_Pos(Vector3 _Pre_Pos)
    {
        Vector3 Pos;

        Pos = _Pre_Pos;

        return Pos;//////////////////////////////////////////수정
    }

    private void Monster_Regen()
    {
        Monster_Regen_Time += Time.deltaTime;

        if(Monster_Regen_Time > Monster_Regen_Cycle_Time)
        {
            Monster_Regen_Time = 0f;

            Monster_Create();
        }
    }

    private void Monster_Create()
    {
        for (int i = 0; i < Monster_Info.Count; ++i)
        {
            Vector3 New_Monster_Pos = Random_Pos(Monster_Info[i].Monster_Pos);

            if (Player_Manager.Instance.Monster_Dis_Check(New_Monster_Pos))
            {
                MONSTER_INFO Temp_Info = Monster_Info[i];
                Temp_Info.Live_Check = true;
                Monster_Info[i] = Temp_Info;
                Add_Monster(prefab_Manager.Instance.Create_Monster(New_Monster_Pos));
            }
        }
    }

    private void Monster_Pos_Set()
    {
        for (int i = 0; i < Monster_Max_Num; ++i)
        {
            Monster_Info.Add(new MONSTER_INFO(new Vector3(-60f + ((i/3) * 60), 2.5f, -60f + ((i % 3) * 60))));
            Debug.Log(new Vector3(-60f + ((i / 3) * 60), 2.5f, -60f + ((i % 3) * 60)));
        }
    }

    List<MONSTER_INFO> Monster_Info;
    LinkedList<GameObject> Monster_List;

    int Monster_Max_Num;

    float Monster_Regen_Time;
    float Monster_Regen_Cycle_Time;
}
