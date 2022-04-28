using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Character = Player_Manager.Instance.Get_Player();
        Camera_Move();
    }

    private void Camera_Move()
    {
        Move_Vec = Character.GetComponent<Character>().Get_Forward_Vec();
        //Debug.Log(Move_Vec * 3);
        transform.position = Character.GetComponent<Character>().transform.position - (Move_Vec * 3) + new Vector3(0f, 5f, 0f);

        transform.rotation = Character.GetComponent<Character>().transform.rotation;
        transform.Rotate(new Vector3(10f, 0f, 0f));
    }

    Vector3 Move_Vec;

    public GameObject Character;
}
