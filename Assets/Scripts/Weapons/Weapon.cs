using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int _clipSize;
    [SerializeField] protected float _shootDelay;
    [SerializeField] protected float _damage;
    [SerializeField] protected GameObject _bullet;
    [SerializeField] protected Transform _shootPoint;

    protected Animator _animator;

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    protected virtual void Shoot()
    {

    }

    protected virtual void Reload()
    {

    }

    protected virtual void Aim()
    {

    }
}
