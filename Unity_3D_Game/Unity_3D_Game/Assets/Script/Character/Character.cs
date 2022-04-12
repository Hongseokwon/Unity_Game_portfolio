using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Move_Speed = 0.1f;
        Rotate_Speed = 1f;
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Forward_Vec_Find();
        Key_Check();
    }

    private void Key_Check()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Debug.Log(Forward_Vec);
            //Debug.Log(Mathf.Sin(transform.eulerAngles.y * Mathf.Deg2Rad));
            //Debug.Log(Mathf.Cos(transform.eulerAngles.y * Mathf.Deg2Rad));
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate((Forward_Vec * Move_Speed),Space.World);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate((-Forward_Vec * Move_Speed), Space.World);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -Rotate_Speed, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, Rotate_Speed, 0);
        }
    }

    private void Forward_Vec_Find()
    {
        Forward_Vec.x = Mathf.Sin(transform.eulerAngles.y * Mathf.Deg2Rad);

        Forward_Vec.z = Mathf.Cos(transform.eulerAngles.y * Mathf.Deg2Rad);

        Forward_Vec.y = 0f;

        Forward_Vec.Normalize();

        
    }


    public Vector3 Get_Forward_Vec() { return Forward_Vec; }


    private float Rotate_Speed;
    private float Move_Speed;

    public Vector3 Forward_Vec;

    new Rigidbody rigidbody;
}
