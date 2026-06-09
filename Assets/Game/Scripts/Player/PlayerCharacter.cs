using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private InventoryManager _inventory;
    [SerializeField] private PlayerCharacterMovement _movement;
    [SerializeField] private PlayerCharacterStamina _stamina;
    [SerializeField] private InteractDetector _interactDetector;

    public InventoryManager Inventory => _inventory;
    public PlayerCharacterMovement Movement => _movement;
    public PlayerCharacterStamina Stamina => _stamina;
    public InteractDetector InteractDetector => _interactDetector;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
