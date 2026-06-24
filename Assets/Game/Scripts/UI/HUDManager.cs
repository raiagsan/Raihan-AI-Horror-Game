using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private StaminaUI _staminaUI;
    [SerializeField] private BatteryUI _batteryUI;
    [SerializeField] private InteractionInfoUI _interactionInfoUI;

    private static HUDManager _instance;
    public static HUDManager Instance => _instance;
    public StaminaUI StaminaUI => _staminaUI;
    public BatteryUI BatteryUI => _batteryUI;
    public InteractionInfoUI InteractionInfoUI => _interactionInfoUI;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }
}
