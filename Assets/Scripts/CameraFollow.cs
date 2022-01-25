using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    private Vector3 offset;
    private float smooth = 1;
    private void Start()
    {
        offset = transform.position - player.position;
    }

    private void Update()
    {
        CameraFollower();
    }
    private void CameraFollower()
    {
         
            Vector3 targetPos = player.position + offset;
            Vector3 smoothie = Vector3.Lerp(transform.position, targetPos, smooth);
            transform.position = new Vector3(smoothie.x, smoothie.y, smoothie.z); ;
  
 
    }
}
