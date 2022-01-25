using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using DG.Tweening;
public class AIController : MonoBehaviour
{
    private int Run = Animator.StringToHash("Running");
    private int Hit = Animator.StringToHash("Hit");
    private int Fall = Animator.StringToHash("Fall");
    public SplineFollower splineFollower; 
    private Animator animAi;
    private Rigidbody rigidBody;
     
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        animAi = GetComponent<Animator>();
    }
    private void Start()
    {
        animAi.CrossFade(Run, .5f);
    }
     
    private void AIResetWay()
    {
        splineFollower.Restart();
    }
    WaitForSeconds duration = new WaitForSeconds(1);
    private IEnumerator WaitForAnim()
    {
        yield return duration;
        AIResetWay(); 
        animAi.CrossFade(Run, .1f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        { 
            animAi.CrossFade(Fall, .1f);
            StartCoroutine(WaitForAnim());

        }
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("AI"))
        {
            gameObject.transform.DOMove((gameObject.transform.position), .5f).OnStart(() => animAi.CrossFade(Hit, Time.deltaTime)).OnComplete(() => animAi.CrossFade(Run, .1f));
        }
    }
}