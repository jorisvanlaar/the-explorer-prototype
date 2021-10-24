using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictBoundaries : MonoBehaviour
{
    private float boundaryZ = 7.0f;
    private float boundaryX = 7.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position.z > boundaryZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, boundaryZ);
        }
        else if (transform.position.z < -boundaryZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -boundaryZ);
        }

        if (transform.position.x > boundaryX)
        {
            transform.position = new Vector3(boundaryX, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -boundaryX)
        {
            transform.position = new Vector3(-boundaryX, transform.position.y, transform.position.z);
        }
    }
}
