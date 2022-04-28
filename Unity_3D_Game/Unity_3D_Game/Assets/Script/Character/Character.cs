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
        Mouse_Check();
    }

    private void Key_Check()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            //Debug.Log(Mathf.Sin(transform.eulerAngles.y * Mathf.Deg2Rad));
            //Debug.Log(Mathf.Cos(transform.eulerAngles.y * Mathf.Deg2Rad));
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate((Forward_Vec * Move_Speed), Space.World);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate((-Forward_Vec * Move_Speed), Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate((Left_Vec * Move_Speed), Space.World);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate((-Left_Vec * Move_Speed), Space.World);
            //transform.Rotate(0, Rotate_Speed, 0);
        }


    }

    private void Mouse_Check()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log(Input.mousePosition);
            Debug.Log(Screen.height);
            Debug.Log(Screen.width);
        }

        if ((Input.mousePosition.x / Screen.width) > 0.98)
            transform.Rotate(0, Rotate_Speed, 0);
        else if ((Input.mousePosition.x / Screen.width) < 0.02)
            transform.Rotate(0, -Rotate_Speed, 0);
    }

    private void Forward_Vec_Find()
    {
        Forward_Vec.x = Mathf.Sin(transform.eulerAngles.y * Mathf.Deg2Rad);
        Forward_Vec.z = Mathf.Cos(transform.eulerAngles.y * Mathf.Deg2Rad);
        Forward_Vec.y = 0f;

        Left_Vec = new Vector3(-Forward_Vec.z, 0, Forward_Vec.x);

        Forward_Vec.Normalize();
        Left_Vec.Normalize();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //transform.Translate((-Forward_Vec * Move_Speed), Space.World);
    }

    private void OnCollisionStay(Collision collision)
    {
        //transform.Translate((-Forward_Vec * Move_Speed), Space.World);
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }

    public void Collision_Back()
    {
        transform.Translate((-Forward_Vec * Move_Speed), Space.World);
    }

    public Vector3 Get_Forward_Vec() { return Forward_Vec; }


    private float Rotate_Speed;
    private float Move_Speed;

    public Vector3 Forward_Vec;
    public Vector3 Left_Vec;

    new Rigidbody rigidbody;
}
