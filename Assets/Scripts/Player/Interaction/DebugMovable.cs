using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMovable : MonoBehaviour
{
    public Rigidbody thisgameobject;
    public Vector3 velocity2;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        velocity2 = thisgameobject.velocity;
        
    }
}
