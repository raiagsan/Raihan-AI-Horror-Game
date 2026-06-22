using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Validate NavMesh from AI", story: "Validate NavMesh from [AI]", category: "Action", id: "857c53e3415e8e651466b2b7467471c0")]
public partial class ValidateNavMeshFromAiAction : Action
{
    [SerializeReference] public BlackboardVariable<GhostAIController> AI;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (AI.Value == null)
        {
            return Status.Failure;
        }

        if (AI.Value.NavMeshAgent == null)
        {
            return Status.Failure;
        }

        if (AI.Value.NavMeshAgent.isActiveAndEnabled == false)
        {
            return Status.Failure;
        }

        if (AI.Value.NavMeshAgent.isOnNavMesh == false)
        {
            return Status.Failure;
        }

        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

