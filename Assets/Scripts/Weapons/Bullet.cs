using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _transform;



    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}
