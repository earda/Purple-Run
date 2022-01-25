using UnityEngine;
using DG.Tweening;

public class HorizontalNav : MonoBehaviour
{
    [SerializeField] private Vector3 EndPosition;
    [SerializeField] private float duration;


    private void Start()
    {
        transform.DOMove(EndPosition, duration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InQuad);
    }
}
