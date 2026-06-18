using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Unity.Behavior;
using UnityEngine.Events;

public class GhostAIController : MonoBehaviour
{
    [SerializeField] private BehaviorGraphAgent _behaviorGraphAgent;
    [SerializeField] private NavMeshAgent _navmeshAgent;
    [SerializeField] private PlayerCharacter _target;
    [SerializeField] private SightPerception _sightPerception;

    public BehaviorGraphAgent BehaviorGraphAgent => _behaviorGraphAgent;
    public NavMeshAgent NavMeshAgent => _navmeshAgent;
    public PlayerCharacter Target => _target;
    public SightPerception SightPerception => _sightPerception;

    public UnityEvent OnDespawn;

    public void Despawn()
    {
        StartCoroutine(DespawnAfterEndOfFrame());
    }

    private IEnumerator DespawnAfterEndOfFrame()
    {
        if (_behaviorGraphAgent == null)
        {
            _behaviorGraphAgent.SetVariableValue("CanSeeTarget", false);
            _behaviorGraphAgent.enabled = false;
        }

        if (_navmeshAgent != null && _navmeshAgent.isOnNavMesh == true)
        {
            _navmeshAgent.ResetPath();
            _navmeshAgent.enabled = false;
        }

        OnDespawn?.Invoke();
        yield return new WaitForEndOfFrame();
        gameObject.SetActive(false);
    }
}
