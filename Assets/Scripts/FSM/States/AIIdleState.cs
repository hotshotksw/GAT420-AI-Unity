using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdleState : AIState
{
    
    
    public AIIdleState(AIStateAgent agent) : base(agent)
    {
        AIStateTransition transition;


		int n = Random.Range(0, 10);
        
        if (n < 1)
        {
			transition = new AIStateTransition(nameof(AIDanceState));
			transition.AddCondition(new FloatCondition(agent.timer, Condition.Predicate.LESS, 0));
			transitions.Add(transition);
		} else if (n < 2)
        {
			transition = new AIStateTransition(nameof(AIExcitedState));
			transition.AddCondition(new FloatCondition(agent.timer, Condition.Predicate.LESS, 0));
			transitions.Add(transition);
		} else if (n < 3)
        {
			transition = new AIStateTransition(nameof(AIStretchState));
			transition.AddCondition(new FloatCondition(agent.timer, Condition.Predicate.LESS, 0));
			transitions.Add(transition);
		} else
        {
			transition = new AIStateTransition(nameof(AIPatrolState));
			transition.AddCondition(new FloatCondition(agent.timer, Condition.Predicate.LESS, 0));
			transitions.Add(transition);
		}

        transition = new AIStateTransition(nameof(AIChaseState));
        transition.AddCondition(new BoolCondition(agent.enemySeen));
        transitions.Add(transition);
    }

    public override void OnEnter()
    {
		agent.timer.value = Random.Range(1, 3);
    }

    public override void OnExit()
    {
        Debug.Log(agent.timer.value);
    }

    public override void OnUpdate()
    {
    }
}
