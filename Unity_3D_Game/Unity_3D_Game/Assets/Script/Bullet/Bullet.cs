using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Bullet()
    {
        Speed = 50f;

        Destroy_Time = 3f;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy_Bullet(Destroy_Time));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, 1f * Speed * Time.deltaTime);
    }

    IEnumerator Destroy_Bullet(float _Destroy_Time)
    {
        yield return new WaitForSeconds(_Destroy_Time);

        Bullet_Manager.Instance.Del_Bullet(gameObject);

        Destroy(gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Bullet_Manager.Instance.Del_Bullet(gameObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
    }

    private void OnTriggerExit(Collider other)
    {

    }

    float Speed;
    float Destroy_Time;
}
