using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticWeapon : Weapon
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Transform _crosshair;

    private int _currentClipSize;
    private float _shootTime;
    private bool _isReloading;


    void Start()
    {
        _currentClipSize = _clipSize;
    }

    void Update()
    {
        Shoot();
        Reload();
    }

    protected override void Shoot()
    {
        if (_inputHandler.ShootPress && _currentClipSize > 0
            && !_animator.GetCurrentAnimatorStateInfo(0).IsName("Run") && !_isReloading)
        {
            if (Time.time - _shootTime < _shootDelay)
                return;

            _animator.Play("Shoot", 1);
            _currentClipSize--;
            _shootTime = Time.time;
            Instantiate(_bullet, _shootPoint.transform.position, 
                        _shootPoint.transform.rotation);
        }
    }

    protected override void Reload()
    {
        if (_inputHandler.ReloadPress && _currentClipSize < _clipSize)
        {
            _isReloading = true;
            if (_currentClipSize == 0)
            {
                _animator.Play("ReloadFull", 1);
            }
            else
            {
                _animator.Play("ReloadFast", 1);
            }
        }
    }

    public void EndReload()
    {
        _isReloading = false;
        _currentClipSize = _clipSize;
    }
}
