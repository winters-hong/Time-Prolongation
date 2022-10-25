using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2Rotator : MonoBehaviour
{
    public float radius = 1f;
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * radius;
    }

    void Update()
    {
        
    }
}
