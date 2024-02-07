using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRandomizer : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;
    int randomNumber;
    int limit;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(20, 0, 0);
        limit = levels.Length;
        randomNumber = Random.Range(0, limit);
        Debug.Log(randomNumber);
        Instantiate(levels[randomNumber], transform.position, Quaternion.identity);
    }

    
}
