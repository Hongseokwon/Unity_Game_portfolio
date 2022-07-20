using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Manager : MonoBehaviour
{
    private static Input_Manager instance = null;

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

    public static Input_Manager Instance
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
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Key_Check();
    }

    private void Key_Check()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if(Physics.Raycast(ray,out hit))
            {
                if(hit.collider.gameObject.name == "Terrain")
                {
                    Player.GetComponent<Player>().MoveTo(hit.point);
                }
                else if (hit.collider.gameObject.tag == "Enemy")
                {
                    Player.GetComponent<Player>().Attack_Enemy(hit.collider.gameObject);
                }
            }

        }
    }

    private GameObject Player;
}
