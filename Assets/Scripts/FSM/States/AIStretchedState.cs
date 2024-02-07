using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStretchedState : AIState
{
	float timer;

	public AIStretchedState(AIStateAgent agent) : base(agent)
	{
	}

	public override void OnEnter()
	{
		agent.animator?.SetTrigger("Stretched");
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
