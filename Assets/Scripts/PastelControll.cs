using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastelControll : MonoBehaviour
{
    [SerializeField] private float pencilProp;

    private void MovePencil()
    {
        transform.position = new Vector3(Input.mousePosition.x,Input.mousePosition.y,transform.position.z);
    }
    private void Update()
    {
        MovePencil();    
    }
}
