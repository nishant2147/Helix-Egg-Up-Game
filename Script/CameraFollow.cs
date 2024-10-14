using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
   
    public GameObject Egg;
    Vector3 offset;
    Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Egg.transform.position;
        lastPosition = Egg.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        pos.y = Egg.transform.position.y + offset.y;
        pos.y = Mathf.Max(pos.y, lastPosition.y);
        lastPosition = pos;
        transform.position = pos;
    }

}
