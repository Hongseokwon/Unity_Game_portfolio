﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Manager : MonoBehaviour
{
    private static Bullet_Manager instance = null;

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

    public static Bullet_Manager Instance
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

    Bullet_Manager()
    {
        Bullet_List = new LinkedList<GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add_Bullet(GameObject _Bullet)
    {
        Bullet_List.AddLast(_Bullet);
    }

    public void Del_Bullet(GameObject _Bullet)
    {
        Bullet_List.Remove(_Bullet);
        Destroy(_Bullet);
    }

    LinkedList<GameObject> Bullet_List;
}
