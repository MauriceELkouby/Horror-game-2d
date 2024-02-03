using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePlayer : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Transform target;
    [SerializeField] private float minimumDistance;

    [SerializeField] private GameObject projectile;
    [SerializeField] private float timeBetweeenShots;
    private float nextShotTime;
    

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextShotTime)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            nextShotTime = Time.time + timeBetweeenShots;
        }
        if (Vector2.Distance(transform.position, target.position) < minimumDistance)
        {
        transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        } else
        {
            //Attack
        }
    }
}
