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

    public GameObject Create_Monster(Vector3 _Pos)
    {
        Debug.Log(_Pos);
        GameObject New_Monster = Instantiate(Monster);
        New_Monster.transform.position = _Pos;

        return New_Monster;
    }

    public GameObject Player;

    public GameObject Monster;

    public GameObject Bullter;
}
