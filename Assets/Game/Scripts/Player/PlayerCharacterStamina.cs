using System.Collections;
using UnityEngine;

public class PlayerCharacterStamina : MonoBehaviour
{
    [SerializeField]
    private float _maxStamina = 100;
    [SerializeField]
    private float _sprintStaminaCost = 20;
    [SerializeField]
    private float _staminaRegenValue = 20;
    private float _currentStamina;
    [SerializeField]
    private PlayerCharacterMovement _characterMovement;
    private Coroutine _stopRegenStaminaCoroutine;
    private bool _isWaitingStaminaRegen;

    private void Awake()
    {
        _currentStamina = _maxStamina;
        HUDManager.Instance.StaminaUI.SetStaminaFill(_currentStamina, _maxStamina);
    }

    public void CalculateStamina()
    {
        if (_characterMovement.IsSprint)
        {
            if (_stopRegenStaminaCoroutine != null)
            {
                StopCoroutine(_stopRegenStaminaCoroutine);
                _stopRegenStaminaCoroutine = null;
            }
            _isWaitingStaminaRegen = false;
            
            if (_currentStamina > 0)
            {
                _currentStamina = _currentStamina - _sprintStaminaCost * Time.deltaTime;
            }
            else
            {
                _characterMovement.SetSprint(false);
            }
        }
        else
        {
            if (_currentStamina < _maxStamina)
            {
                _currentStamina = _currentStamina + _staminaRegenValue * Time.deltaTime;
            }
            else if (_isWaitingStaminaRegen == false)
            {
                _stopRegenStaminaCoroutine = StartCoroutine(StopRegenStaminaWait());
                _isWaitingStaminaRegen = true;
            }
        }
        _currentStamina = Mathf.Clamp(_currentStamina, 0, _maxStamina);
        HUDManager.Instance.StaminaUI.SetStaminaFill(_currentStamina, _maxStamina);
    }

    private void Update()
    {
        CalculateStamina();
    }

    private IEnumerator StopRegenStaminaWait()
    {
        yield return new WaitForSeconds(1f);
        HUDManager.Instance.StaminaUI.SetVisible(false);
    }
}