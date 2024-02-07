using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBehavior : MonoBehaviour
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
    public AIPath pathfinder;

    [SerializeField] private GameObject porjectile;
    [SerializeField] private float timeBetweeenShots;
    private float nextShotTime;

    private void Start()
    {
        pathfinder.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        // Update is called once per frame
        //pathfinder.target = null;
        distance = Vector3.Distance(transform.position, target.position);

        if (distance < minimumDistance)
        {
            //Follow();
            if (distance <= distance_t)
            {
                pathfinder.enabled = false;
            }
            else
            {
                pathfinder.enabled = true;
            }
            

        }
        else
        {
            if(pathfinder.enabled == true)
            {
                transform.position = new Vector3(patrolPoints[0].position.x, patrolPoints[0].position.y, 0);
            }
            pathfinder.enabled = false;
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




