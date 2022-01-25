using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{
    public GameObject pastel;
    public float pastelSize = 0.1f;
    [SerializeField] private GameObject pencil;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit))
            {
                var color = Instantiate(pastel, hit.point - Vector3.forward * .01f, Quaternion.Euler(Vector3.zero), transform);
                color.transform.eulerAngles = new Vector3(-90, 0, 0);
                color.transform.localScale += Vector3.one * pastelSize;
                pencil.transform.position = new Vector3(color.transform.position.x, color.transform.position.y - .5f, pencil.transform.position.z);
            }
        }
    }
}
