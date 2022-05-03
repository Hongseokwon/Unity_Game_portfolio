using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefab_Manager : MonoBehaviour
{
    private static prefab_Manager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static prefab_Manager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject Create_Player(Vector3 _Pos)
    {
        GameObject New_Player = Instantiate(Player);
        New_Player.transform.position = _Pos;

        Player_Manager.Instance.Add_Player(New_Player);

        return New_Player;
    }

    public GameObject Create_Monster(Vector3 _Pos, int _Num)
    {
        GameObject New_Monster = Instantiate(Monster);
        New_Monster.transform.position = _Pos;
        New_Monster.GetComponent<Monster>().Index_Num = _Num;

        return New_Monster;
    }

    public GameObject Create_Bullet(Vector3 _Pos,Quaternion _Rotate)
    {
        GameObject New_Bullet = Instantiate(Bullet, _Pos,_Rotate);

        return New_Bullet;
    }


    public GameObject Player;
    public GameObject Monster;
    public GameObject Bullet;
}
