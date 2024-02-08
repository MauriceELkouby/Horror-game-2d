using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePlayer : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Transform target;
    [SerializeField] private float minimumDistance;
    [SerializeField] private float safetydistance;
    private float distance;

    public Transform[] patrolPoints;
    public float waitTime;
    private int currentPointIndex;

    [SerializeField] private GameObject projectile;
    [SerializeField] private float timeBetweeenShots;
    private float nextShotTime;
    

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, target.position);

        if (distance < minimumDistance)
        {
             escape();

        }
        else
        {
            //pathfinder.enabled = false;
            //transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);
            Patrol();
        }
    }

    void escape()
    {
        if (Vector2.Distance(transform.position, target.position) < safetydistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
        else
        {
            shoot();
        }
    }

    void shoot()
    {
        if (Time.time > nextShotTime)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            nextShotTime = Time.time + timeBetweeenShots;
        }
    }

    void Patrol()
    {
        if (transform.position != patrolPoints[currentPointIndex].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);
            Debug.Log("First Patrol");
            Debug.Log(currentPointIndex);
            Debug.Log(patrolPoints.Length);
        }
        else
        {

            Debug.Log(currentPointIndex);
            if (currentPointIndex + 1 == patrolPoints.Length)
            {
                currentPointIndex = 0;
            }
            else
            {
                currentPointIndex++;
            }
        }

    }
}
