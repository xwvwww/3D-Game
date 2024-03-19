using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * _speed;
    }


    void Update()
    {
        
    }
}
