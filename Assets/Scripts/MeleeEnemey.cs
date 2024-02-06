using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Transform target;
    [SerializeField] private float minimumDistance;
    [SerializeField] private float distance;

    public Transform[] patrolPoints;
    public float waitTime;
    private int currentPointIndex = 0;
    bool once;

    [SerializeField] private GameObject porjectile;
    [SerializeField] private float timeBetweeenShots;
    private float nextShotTime;

    

    // Update is called once per frame
    void Update()
    {
        // Update is called once per frame

        if (target.position.x > distance || target.position.y > distance)
        {
            Patrol();
        }
        else
        {
            Follow();
        }
    }
    
    void Follow()
    {
        if (Vector2.Distance(transform.position, target.position) > minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            //Attack
        }
    }

    void Patrol()
    {
        if (Vector2.Distance(patrolPoints[currentPointIndex].transform.position, transform.position) < .1f)
        {
            currentPointIndex++;
            if (currentPointIndex >= patrolPoints.Length)
            {
                currentPointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].transform.position, Time.deltaTime * speed);

    }
}




