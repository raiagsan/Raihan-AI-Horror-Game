using UnityEngine;
using UnityEngine.UI;

public class StaminaUI : MonoBehaviour
{
    [SerializeField] private Image _staminaFill;
    [SerializeField] private GameObject _uiObject;
    
    public void SetVisible(bool value)
    {
        _uiObject?.SetActive(value);
    }

    public void SetStaminaFill(float value, float maxValue)
    {
        if (_staminaFill != null)
        {
            _staminaFill.fillAmount = value/maxValue;
        }
    }
}
