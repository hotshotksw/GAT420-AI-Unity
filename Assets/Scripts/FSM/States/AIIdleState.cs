using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdleState : AIState
{
    float timer;
    AIStateTransition transition = new AIStateTransition(nameof(AIPatrolState));
    
    public AIIdleState(AIStateAgent agent) : base(agent)
    {
        transition.AddCondition(new FloatCondition(agent.timer, Condition.Predicate.LESS, 0));
    }

    public override void OnEnter()
    {
		timer = Time.time + Random.Range(1, 2);
    }

    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {
        if (Time.time > timer)
        {
			float n = Random.Range(0f, 10f);

			if (n < 2f)
			{
				agent.stateMachine.SetState(nameof(AIDanceState));
			} else if (n < 3f)
            {
                agent.stateMachine.SetState(nameof(AIExcitedState));
            } else if (n < 4f)
            {
				agent.stateMachine.SetState(nameof(AIStretchedState));
			} else
            {
				agent.stateMachine.SetState(nameof(AIPatrolState));
			}
        }

        var enemies = agent.enemyPerception.GetGameObjects();
        if (enemies.Length > 0)
        {
            agent.stateMachine.SetState(nameof(AIAttackState));
        }
    }
}
