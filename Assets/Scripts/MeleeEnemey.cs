using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Transform target;

    [SerializeField] private float minimumDistance; 
    private float distance;
    public float distance_t;

    public Transform[] patrolPoints;
    public float waitTime;
    private int currentPointIndex;
    bool once;

    [SerializeField] private GameObject porjectile;
    [SerializeField] private float timeBetweeenShots;
    private float nextShotTime;


    // Update is called once per frame
    void Update()
    {
        // Update is called once per frame

        distance = Vector3.Distance(transform.position, target.position);

        if (distance < minimumDistance)
        {
            Follow();
        }
        else
        {
            //transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);
            Patrol();
        }
    }
    
    void Follow()
    {
        if (Vector2.Distance(transform.position, target.position) > distance_t)
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
    /*IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);

        if (currentPointIndex + 1 < patrolPoints.Length)
        {
            currentPointIndex++;
        }
        else
        {
            currentPointIndex = 0;
        }
        once = false;

    }*/
}




