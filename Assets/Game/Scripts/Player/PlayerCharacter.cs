using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private InventoryManager _inventory;
    [SerializeField] private PlayerCharacterMovement _movement;
    [SerializeField] private PlayerCharacterStamina _stamina;
    [SerializeField] private InteractDetector _interactDetector;
    [SerializeField] private CameraManager _camera;
    [SerializeField] private InputManager _input;

    public bool IsHiding{get; private set;}

    public void SetIsHiding(bool isHiding)
    {
        IsHiding = isHiding;
    }

    public InventoryManager Inventory => _inventory;
    public PlayerCharacterMovement Movement => _movement;
    public PlayerCharacterStamina Stamina => _stamina;
    public InteractDetector InteractDetector => _interactDetector;
    public CameraManager Camera => _camera;
    public InputManager Input => _input;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
