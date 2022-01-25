using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerMovement : MonoBehaviour
{

    private Rigidbody playerRigidbody;
    private Animator animator;
    public static bool canMove = true;
    private int Idle = Animator.StringToHash("Idle");
    private int Run = Animator.StringToHash("Running");
    private int Fall = Animator.StringToHash("Fall");
    private Joystick joystick;
    [SerializeField] private float speedSens;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();
    }
    private void Movement()
    {
        float XAxis =  joystick.Horizontal *  speedSens;
        float ZAxis =  joystick.Vertical *  speedSens;
        playerRigidbody.velocity = new Vector3(XAxis, playerRigidbody.velocity.y, ZAxis);
        if (Input.GetMouseButton(0))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(joystick.Horizontal
                  , joystick.Vertical) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }
        if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.sqrMagnitude == 0)
            animator.CrossFade(Idle, .1f);
        if (Input.GetMouseButtonDown(0))
            animator.CrossFade(Run, .1f);
    }
    private void Update()
    {
        Movement();   
    }
    private void PositionReset()
    {
        transform.position = Vector3.zero;
        transform.eulerAngles = Vector3.zero;
    }
    WaitForSeconds duration = new WaitForSeconds(2f);

    private IEnumerator WaitForAnim()
    {
        canMove = false;
        yield return duration;
        PositionReset();
        animator.CrossFade(Idle, .1f);
        canMove = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            animator.CrossFade(Fall, .1f);
            StartCoroutine(WaitForAnim());

        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            canMove = false;
            transform.DOMove(collision.transform.position, 1f);
            GameManager.state = GameManager.State.End;
        }
    }
}
