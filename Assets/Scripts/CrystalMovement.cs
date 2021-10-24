using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalMovement : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] float upDownSpeed;
    private float delta = 0.2f;              // The difference between min y to max y


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        MoveUpDown();
    }

    void MoveUpDown()
    {
        float y = Mathf.PingPong(upDownSpeed * Time.time, delta);
        Vector3 position = new Vector3(transform.position.x, y + 1, transform.position.z);  // +1 for correction to have it hover mid-air instead on the ground
        transform.position = position;
    }
}
