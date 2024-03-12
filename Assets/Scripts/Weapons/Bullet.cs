using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * _speed, ForceMode.Impulse); 
    }


    void Update()
    {
        
    }
}
