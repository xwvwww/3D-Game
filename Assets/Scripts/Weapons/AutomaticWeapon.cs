using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticWeapon : Weapon
{
    [SerializeField] private InputHandler _inputHandler;

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
        if (_inputHandler.ShootPress && _currentClipSize > 0)
        {
            if (Time.time - _shootTime < _shootDelay)
                return;

            _shootTime = Time.time;
            Instantiate(_bullet, _shootPoint.transform.position, _shootPoint.transform.rotation);
        }
    }
}
