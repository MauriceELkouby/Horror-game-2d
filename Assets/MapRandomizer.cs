using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRandomizer : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;
    int randomNumber;
    int limit;
    private Transform target;
    private Vector3 spamlocation;
    float x = 21.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        limit = levels.Length;
        
        Debug.Log(randomNumber);
        
        for (int i=0;  i < limit; i++)
        {
            spamlocation = new Vector3(x, 0, 0);
            randomNumber = Random.Range(0, limit);
            Instantiate(levels[randomNumber], spamlocation, Quaternion.identity);
            x = x + 20;
        }

    }

    
}
