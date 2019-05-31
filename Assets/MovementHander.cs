using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHander : MonoBehaviour
{
    public float panSpeed = .01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MoveForward()
    {
        Vector3 pos = transform.position;
        pos.z += panSpeed * Time.deltaTime;
        transform.position = pos;
    }

    public void MoveBackward()
    {
        Vector3 pos = transform.position;
        pos.z -= panSpeed * Time.deltaTime;
        transform.position = pos;

    }

    public void MoveRight()
    {
        Vector3 pos = transform.position;
        pos.x += panSpeed * Time.deltaTime;
        transform.position = pos;

    }

    public void MoveLeft()
    {
        Vector3 pos = transform.position;
        pos.x -= panSpeed * Time.deltaTime;
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        transform.position = pos;
    }
}
