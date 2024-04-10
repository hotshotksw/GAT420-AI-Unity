using System.Collections.Generic;
using UnityEngine;

public class AIUtilityObject : MonoBehaviour
{
    // A struct to define an effector that can change a utility need
    [System.Serializable]
    public class Effector
    {
        public AIUtilityNeed.Type type; // The type of utility need this effector affects
        [Range(-2, 2)] public float change; // The amount of change this effector applies (-2 to 2 range)
    }

    [Header("Parameters")]
    [SerializeField] public Effector[] effectors; // Array of effectors that affect utility needs
    [SerializeField, Tooltip("Time to use object")] public float duration; // Time for which the object is used
    [SerializeField, Tooltip("Animation to play when using")] public string animationName; // Name of the animation to play when using the object

    [SerializeField] public Transform target;

    [Header("UI")]
    [SerializeField, Tooltip("Radius to detect agent")] float radius = 5; // Radius to detect nearby agents

    [SerializeField] LayerMask agentLayerMask; // Layer mask to filter agents
    [SerializeField] AIUIMeter meterPrefab; // Prefab of the UI meter for this object
    [SerializeField] Vector3 meterOffset; // Offset for the meter's position relative to the object

    public float score { get; set; } // The utility score of the object

    AIUIMeter meter; // Reference to the UI meter for this object
    Dictionary<AIUtilityNeed.Type, float> registry = new Dictionary<AIUtilityNeed.Type, float>(); // Dictionary to store effectors by utility need type

    void Start()
    {
        // Create the meter UI at runtime and set its properties
        meter = Instantiate(meterPrefab, GameObject.Find("Canvas").transform);
        meter.name = name;
        meter.text = name;
        meter.position = transform.position + meterOffset;

        // Set effectors array into dictionary for easy access
        foreach (var effector in effectors)
        {
            registry[effector.type] = effector.change;
        }
    }

    private void Update()
	{
		meter.visible = false; // hide meter by default
 
		// show object meter if near agent
		var colliders = Physics.OverlapSphere(transform.position, radius, agentLayerMask);
		if (colliders.Length > 0)
		{
			// check colliders for utility agent 
			foreach (var collider in colliders)
			{
				if (collider.TryGetComponent(out AIUtilityAgent agent))
				{
					// set meter alpha based on distance to agent (fade-in)
					float distance = 1 - Vector3.Distance(agent.transform.position, transform.position) / radius;
					score = agent.GetUtilityScore(this);
					meter.alpha = 0.25f;
					meter.visible = true;
				}
			}
		}
	}

    void LateUpdate()
    {
        // Update the meter's value and position
        meter.value = score;
        meter.position = transform.position + meterOffset;
    }

    // Get the change value for a specific utility need type
    public float GetNeedChange(AIUtilityNeed.Type type)
    {
        return registry.TryGetValue(type, out float value) ? value : 0f;
    }

    // Check if this object has a specific utility need type
    public bool HasNeedType(AIUtilityNeed.Type type)
    {
        return registry.ContainsKey(type);
    }
}
