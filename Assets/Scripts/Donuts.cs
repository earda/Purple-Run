using UnityEngine;
using DG.Tweening;
public class Donuts : MonoBehaviour
{
    [SerializeField] private Vector3 vector;
    void Start()
    {
        MovingStick();
    }
     
    private void MovingStick()
    {
        transform.DOLocalMove(vector, 2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutExpo);
    }
}
