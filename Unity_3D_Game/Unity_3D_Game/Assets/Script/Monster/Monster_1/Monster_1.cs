using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_1 : Monster
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Monster_Rotation();
    }
    
    


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Character")
        {
            Player_Manager.Instance.Get_Player().GetComponent<Character>().Collision_Back();
        }
        else if(other.tag == "Bullet")
        {
            Bullet_Manager.Instance.Del_Bullet(other.gameObject);

            Monster_Manager.Instance.Del_Monster(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Character")
        {
            Player_Manager.Instance.Get_Player().GetComponent<Character>().Collision_Back();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    

    private void Monster_Rotation()
    { 
        Vector3 temp;
        temp = Player_Manager.Instance.Get_Player().transform.position - transform.position;
        temp.y = 0;
        transform.rotation = Quaternion.LookRotation(temp);
    }


}