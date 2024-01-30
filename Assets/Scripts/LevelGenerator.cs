using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class LevelGenerator : MonoBehaviour
{
    public NavMeshSurface surface;
    
    public int width = 20;
    public int height = 20;

    public GameObject wall;
    public GameObject player;

    private bool playerSpawned = false;

    // Use this for initialization
    void Start()
    {
        GenerateLevel();

        surface.BuildNavMesh();

    }

    void GenerateLevel()
    {
        for (int x = 0; x <= width; x++)
        {
            for (int y = 0; y <= height; y++)
            {
                // Should we place a wall
                if (Random.value > 0.7f)
                {
                    // Spawn a wall
                    Vector3 pos = new Vector3(x - width / 2f, 1f, y - height / 2f);
                    Instantiate(wall, pos, Quaternion.identity, transform);
                } else if (!playerSpawned)
                {
                    // Spawn the player
                    Vector3 pos = new Vector3(x - width / 2f, 1.25f, y - height / 2f);
                    Instantiate(player, pos, Quaternion.identity);
                    playerSpawned = true;
                }
            }
        }
    }
}
