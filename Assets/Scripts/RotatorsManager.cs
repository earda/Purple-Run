using UnityEngine;
using DG.Tweening;
public class RotatorsManager : MonoBehaviour
{
    public float leftSpeed = 10f;
   // public float rightSpeed = -10f;
    private void FixedUpdate()
    {
        transform.DOLocalRotate(new Vector3(0, leftSpeed, 0), .5f, RotateMode.LocalAxisAdd);
    }
}
