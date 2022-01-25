using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] protected float rotateSpeed; 
    [SerializeField] private float tossSize; 


    private void FixedUpdate()
    {
        RotatePlat();
    }
    public void RotatePlat()
    { 
            transform.Rotate(Vector3.forward, Time.deltaTime * rotateSpeed);
    }

    private void OnCollisionStay(Collision collision)
    {
            collision.transform.position += new Vector3(-tossSize * Time.deltaTime,0,0);
    }

}
