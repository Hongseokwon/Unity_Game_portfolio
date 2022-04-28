using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    private static Player_Manager instance = null;

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

    public static Player_Manager Instance
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

    public void Add_Player(GameObject _Player)
    {
        if (My_Player == null)
            My_Player = _Player;
    }

    public bool Monster_Dis_Check(Vector3 _Monster_Pos)
    {
        return true;
    }

    public GameObject Get_Player() { return My_Player; }

    public GameObject My_Player;
}
