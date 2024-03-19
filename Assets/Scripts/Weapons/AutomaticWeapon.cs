using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticWeapon : Weapon
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Transform _crosshair;
    [SerializeField] private Transform _weaponHolder;
    [SerializeField] private Vector3 _aimPosition;
    [SerializeField] private float _speedAim;

    private int _currentClipSize;
    private float _shootTime;
    private bool _isReloading;
    private Vector3 _origin;


    void Start()
    {
        _currentClipSize = _clipSize;
        _origin = _weaponHolder.localPosition;
    }

    void Update()
    {
        Shoot();
        Reload();
        Aim();
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

    protected override void Aim()
    {
        if (_inputHandler.AimPress && !_animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            _weaponHolder.localPosition = Vector3.Lerp(_weaponHolder.localPosition,
                                                       _aimPosition, _speedAim * Time.deltaTime);

            Camera.main.fieldOfView = 35;
        }
        else
        {
            _weaponHolder.localPosition = Vector3.Lerp(_weaponHolder.localPosition,
                                                       _origin, _speedAim * Time.deltaTime);

            Camera.main.fieldOfView = 60;
        }
        
    }

    public void EndReload()
    {
        _isReloading = false;
        _currentClipSize = _clipSize;
    }
}
