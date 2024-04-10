using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDanceState : AIState
{

    public AIDanceState(AIStateAgent agent) : base(agent)
    {
		AIStateTransition transition = new AIStateTransition(nameof(AIPatrolState));
		transition.AddCondition(new FloatCondition(agent.timer, Condition.Predicate.LESS, 0));
		transitions.Add(transition);
	}

    public override void OnEnter()
    {
		agent.animator?.SetTrigger("Dance");
		agent.timer.value = 2f;
	}
    public override void OnUpdate()
    {
    }

    public override void OnExit()
    {
        Debug.Log("attack exit");
    }

}
