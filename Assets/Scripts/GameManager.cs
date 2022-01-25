using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static State state;
    [SerializeField] private GameObject InGame;
    [SerializeField] private GameObject Paint;
    [SerializeField] private  GameObject  newCamPosition;
    [SerializeField] private Camera cameraControll;
    [SerializeField] private GameObject startPanel;

    public enum State
    {
        Start,Run,End,Paint
    }
    private void Awake()
    {
        InGame.SetActive(false);
        state = State.Start;
        cameraControll = FindObjectOfType<Camera>();
    }
    
    private void Update()
    {
        EndState();
        PaintingState();
    }
    private void EndState()
    {
        if (state==State.End)
        {
            StartCoroutine(WaitForFinish());
        }
    }

    private void PaintingState()
    {
        
        if (state == State.Paint)
        {
            PlayerRanking.Instance.rank.enabled = false;
            cameraControll.transform.DOMove(newCamPosition.transform.position, 1f).SetEase(Ease.Linear);
        }
    }
    
    WaitForSeconds duraiton = new WaitForSeconds(2.5f);
    private IEnumerator WaitForFinish()
    {
        yield return duraiton;
        InGame.SetActive(false);
        Paint.SetActive(true);
        newCamPosition = GameObject.FindGameObjectWithTag("PainterPosition");
        cameraControll.orthographic = true;
        state = State.Paint;
    }
    public void StartButton()
    {
        state = State.Start;
        startPanel.SetActive(false);
        InGame.SetActive(true);
    }
    public void Restart()
    {
        state = State.Start;
        PlayerMovement.canMove = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
