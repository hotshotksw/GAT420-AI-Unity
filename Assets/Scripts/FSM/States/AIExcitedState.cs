using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIExcitedState : AIState
{
	float timer;

	public AIExcitedState(AIStateAgent agent) : base(agent)
	{
	}

	public override void OnEnter()
	{
		agent.animator?.SetTrigger("Excited");
		timer = Time.time + 2;
	}

	public override void OnExit()
	{
	}

	public override void OnUpdate()
	{
		if (Time.time > timer)
		{
			agent.stateMachine.SetState(nameof(AIIdleState));
		}

		var enemies = agent.enemyPerception.GetGameObjects();
		if (enemies.Length > 0)
		{
			agent.stateMachine.SetState(nameof(AIAttackState));
		}
	}
}
