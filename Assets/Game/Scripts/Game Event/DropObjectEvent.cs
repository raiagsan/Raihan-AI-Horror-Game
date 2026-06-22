using UnityEngine;

public class DropObjectEvent : GameEventBase
{
    [SerializeField] private Rigidbody _dropObject;
    [SerializeField] private BoxCollider _mirrorCollider;
    public override void Trigger()
    {
        _mirrorCollider.enabled = true;
        _dropObject.useGravity = true;
        base.Trigger();
    }
}
