using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Move_Speed = 15f;
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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            X += 1f;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            X -= 1f;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Y += 1f;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Y -= 1f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.A))
            {
                Vector3 vectemp = Forward_Vec + Left_Vec;
                vectemp.Normalize();

                transform.Translate((vectemp * Move_Speed * Time.deltaTime), Space.World);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Vector3 vectemp = Forward_Vec - Left_Vec;
                vectemp.Normalize();

                transform.Translate((vectemp * Move_Speed * Time.deltaTime), Space.World);
            }
            else
            {
                transform.Translate((Forward_Vec * Move_Speed * Time.deltaTime), Space.World);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.A))
            {
                Vector3 vectemp = new Vector3(0f, 0f, -1f) + new Vector3(-1f, 0f, 0f);
                vectemp.Normalize();

                transform.Translate((vectemp * Move_Speed * Time.deltaTime));
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Vector3 vectemp = new Vector3(0f, 0f, -1f) + new Vector3(1f, 0f, 0f);
                vectemp.Normalize();

                transform.Translate((vectemp * Move_Speed * Time.deltaTime));
            }
            else
            {
                transform.Translate(0f, 0f, -1f * Move_Speed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate((Left_Vec * Move_Speed * Time.deltaTime), Space.World);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate((-Left_Vec * Move_Speed * Time.deltaTime), Space.World);
        }

        Camera_Manager.Instance.Main_Camera_Obj.GetComponent<Main_Camera>().Camera_Move();
    }

    private void Mouse_Check()
    {
        float Rate_X = Input.mousePosition.x / Screen.width;
        float Rate_Y = Input.mousePosition.y / Screen.height;

        if (Input.GetMouseButtonUp(0))
        {
            Create_Bullet(Rate_X, Rate_Y);
        }

        if (Rate_X > 0.98)
            transform.Rotate(0, Rotate_Speed, 0);
        else if (Rate_X < 0.02)
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
        transform.Translate((-Forward_Vec * Move_Speed * Time.deltaTime), Space.World);
    }

    private void Create_Bullet(float _Rate_X , float _Rate_Y)
    {
        if (_Rate_X > 1)
            _Rate_X = 1f;
        if (_Rate_Y > 1)
            _Rate_Y = 1f;

        if (_Rate_X < 0)
            _Rate_X = 0f;
        if (_Rate_Y < 0)
            _Rate_Y = 0f;

        _Rate_X -= 0.5f;
        _Rate_Y -= 0.5f;

        Vector3 Bullet_Pos = transform.position + Forward_Vec;
        Bullet_Pos.y += 2f;

        Vector3 vecTemp = transform.rotation.eulerAngles;
        vecTemp.x -= 5f;

        Debug.Log(_Rate_X);

        vecTemp.x -= _Rate_Y * 30f;
        vecTemp.y += _Rate_X * 100f;


        Bullet_Manager.Instance.Add_Bullet(prefab_Manager.Instance.Create_Bullet(Bullet_Pos, Quaternion.Euler(vecTemp)));
    }

    public Vector3 Get_Forward_Vec() { return Forward_Vec; }

    
    private float Rotate_Speed;
    private float Move_Speed;

    public Vector3 Forward_Vec;
    public Vector3 Left_Vec;

    new Rigidbody rigidbody;

    float X = 0f;
    float Y = 0f;
}
