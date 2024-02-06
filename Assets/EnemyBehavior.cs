using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBehavior : MonoBehaviour {
    [SerializeField] private Transform player;
    [SerializeField] private float distance;
    [SerializeField] private Component MyComponent;
    
    // Update is called once per frame
    void Update()
    {
        if (player.position.x > distance || player.position.y > distance)
        {
            
        }
    }
}
