using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class StickKick : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        PlayerMovement.canMove = false;
        var direction = transform.position - collision.transform.position;
        Vector3 diffrences = new Vector3(direction.x, 0, direction.z);
        collision.gameObject.transform.DOMove((collision.gameObject.transform.position + diffrences * -2), 1f).OnComplete(() => PlayerMovement.canMove = true);
    }
}
