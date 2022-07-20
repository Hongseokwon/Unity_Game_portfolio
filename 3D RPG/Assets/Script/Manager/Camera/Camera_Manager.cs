using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Manager : MonoBehaviour
{
    private static Camera_Manager instance = null;

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

    public static Camera_Manager Instance
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
        Offset = Player.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.position - Offset;
    }

    public Transform Player;

    Vector3 Offset;
}
