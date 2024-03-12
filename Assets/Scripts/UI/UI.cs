using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Slider _staminaSlider;
    [SerializeField] private PlayerController _playerController;

    private void Awake()
    {
        _playerController.OnStaminaChange += Stamina;
    }

    private void Start()
    {
        _staminaSlider.minValue = 0;
        _staminaSlider.maxValue = 100;
        _staminaSlider.value = _staminaSlider.maxValue;
    }

    private void Stamina(float stamina)
    {
        _staminaSlider.value = stamina;
    }
}
