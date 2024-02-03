using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 targetPosition;
    public float speed;

    private void Start()
    {
        targetPosition = FindAnyObjectByType<PlayerMovement>().transform.position;

    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        
        if (transform.position == targetPosition)
        {
            Destroy(gameObject);
        }
    }
}
