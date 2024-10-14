using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixCylinderMOvement : MonoBehaviour
{
    public float rotatingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");
            transform.Rotate(transform.position.x, -mouseX * rotatingSpeed * Time.deltaTime, transform.position.z);
        }
    }
}
