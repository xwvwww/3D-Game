using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticWeapon : Weapon
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Transform _crosshair;

    private int _currentClipSize;
    private float _shootTime;


    void Start()
    {
        _currentClipSize = _clipSize;
    }

    void Update()
    {
        Shoot();
    }

    protected override void Shoot()
    {
        if (_inputHandler.ShootPress && _currentClipSize > 0
            && !_animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            if (Time.time - _shootTime < _shootDelay)
                return;

            _animator.Play("Shoot", 1);
            _shootTime = Time.time;
            Instantiate(_bullet, _shootPoint.transform.position, 
                        _shootPoint.transform.rotation);
        }
    }
}
