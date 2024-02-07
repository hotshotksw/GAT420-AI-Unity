using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIState
{
    protected AIStateAgent agent;
    public AIState(AIStateAgent agent)
    {
        this.agent = agent;
    }

    public string name { get { return GetType().Name; } }
    
    abstract public void OnEnter();
    abstract public void OnUpdate();
    abstract public void OnExit();
}
