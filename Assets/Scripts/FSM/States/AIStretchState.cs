using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStretchState : AIState
{

    public AIStretchState(AIStateAgent agent) : base(agent)
    {
		AIStateTransition transition = new AIStateTransition(nameof(AIPatrolState));
		transition.AddCondition(new FloatCondition(agent.timer, Condition.Predicate.LESS, 0));
		transitions.Add(transition);
	}

	public override void OnEnter()
	{
		agent.animator?.SetTrigger("Stretching");
		agent.timer.value = 2f;
	}
	public override void OnUpdate()
    {
    }

    public override void OnExit()
    {
        Debug.Log("stretching exit");
    }

}
