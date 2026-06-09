using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour, IInteractable
{

    [SerializeField] private string _name;
    [SerializeField] protected Transform _doorTransform;
    [SerializeField] protected float _duration = 1f;
    [SerializeField] protected bool _isLocked;
    [SerializeField] protected string _keyID;
    public string Name => _name;
    protected bool _isAnimating;
    protected bool _isOpen;
    protected bool IsAnimating => _isAnimating;

    public UnityEvent OnDoorOpen;
    public UnityEvent OnDoorClose;

    [ContextMenu("Interact Door")]
    public void Interact(PlayerCharacter character)
    {  
        if (_isLocked == true)
        {
            bool hasKey = character.Inventory.CheckItem(_keyID);
            if (hasKey == true)
            {
                _isLocked = false;
                Open();
            }
        }
        else
        {
            if (_isOpen == true)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }

    public virtual void Open()
    {
        _isOpen = true;
        OnDoorOpen?.Invoke();
    }

    public virtual void Close(){

        _isOpen = false;
        OnDoorClose?.Invoke();
    }

    protected Coroutine _animatingDoorCoroutine;
}
