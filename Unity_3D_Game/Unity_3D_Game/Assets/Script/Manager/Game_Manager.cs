using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{

    private static Game_Manager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static Game_Manager Instance
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
        Player_Manager.Instance.Add_Player(prefab_Manager.Instance.Create_Player(new Vector3(0f, 0f, 0f)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
