using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.InputSystem; 
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private int gamePhase; //0 day, 1 night
    [SerializeField] private UnityEvent phaseChangeEvent; 
    [SerializeField] private PlayerInput playerInput; 
    [SerializeField] private GameObject player;
    [SerializeField] Transform playerStartPos;

    [SerializeField] UIManager UIManager;
    [SerializeField] private int dayTimeLength = 5;
    private float timeRemainingDay;
    private float elapsedTimeNight;
    private bool isDayTimerRunning = false;
    private bool isNightTimerRunning = false;
    private Coroutine timerDayCoroutine;
    private Coroutine timerNightCoroutine;

    //detect the player entering and leaving the house
    private bool enter = false;
    private bool exit = false;
    private bool enteredHouse = false;
    void Awake()
    {
        StartCoroutine(DayPhaseCoroutine(gamePhase)); 
    }

    public void StartDayTimer()
    {
        if (isDayTimerRunning) return;

        isDayTimerRunning = true;
        timeRemainingDay = (float) dayTimeLength + 1;
        timerDayCoroutine = StartCoroutine(UpdateDayTimerRoutine()); 
    }

    public void StopDayTimer()
    {
        if (!isDayTimerRunning) return;

        isDayTimerRunning = false;
        if (timerDayCoroutine != null)
        {
            StopCoroutine(timerDayCoroutine);
        }
    }

    public void StartNightTimer()
    {
        if (isNightTimerRunning) return;

        isNightTimerRunning = true;
        elapsedTimeNight = 0f;
        timerNightCoroutine = StartCoroutine(UpdateNightTimerRoutine()); 
    }

    public void StopNightTimer()
    {
        if (!isNightTimerRunning) return;

        isNightTimerRunning = false;
        if (timerNightCoroutine != null)
        {
            StopCoroutine(timerNightCoroutine);
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over!!!!"); 
    }

    public void enterHouseUpdate(bool trigger)
    {
        if (isNightTimerRunning)
        {
            enter = trigger;
            playerPosUpdate();
        }
    }

    public void exitHouseUpdate(bool trigger)
    {
        if (isNightTimerRunning)
        {
            exit = trigger;
            playerPosUpdate();
        }
    }

    public void playerPosUpdate()
    {
        if (enter && !exit)
        {
            enteredHouse = true;
            Debug.Log("entered house");
        }
        if (exit && enteredHouse && !enter)
        {
            enteredHouse = false;
            Debug.Log("exit house");
            SceneTransitionManager.Instance.LoadScene("VictoryScene");
        }
    }

    IEnumerator DayPhaseCoroutine (int phase)
    {
        StartDayTimer();
        yield return new WaitForSeconds(dayTimeLength);
        StopDayTimer();
        yield return StartCoroutine(SceneTransitionManager.Instance.FadeOut());
        yield return new WaitForSeconds(2);
        phaseChangeEvent.Invoke(); 
        playerInput.SwitchCurrentActionMap("Night");

        var playerCollider = player.GetComponent<BoxCollider2D>();
        playerCollider.enabled = true;

        player.transform.position = playerStartPos.position;
        StartNightTimer();
        yield return StartCoroutine(SceneTransitionManager.Instance.FadeIn());
    }

    IEnumerator UpdateNightTimerRoutine ()
    {
        while (isNightTimerRunning)
        {
            elapsedTimeNight += Time.deltaTime;
            string elapsedTimeNightString = TimeSpan.FromSeconds(elapsedTimeNight).ToString("m':'ss");
            UIManager.UpdateNightTimer(elapsedTimeNightString);
            yield return null;
        }
    }

    IEnumerator UpdateDayTimerRoutine ()
    {
        while (isDayTimerRunning)
        {
            timeRemainingDay -= Time.deltaTime;
            string timeRemainingDayString = TimeSpan.FromSeconds(timeRemainingDay).ToString("m':'ss");
            UIManager.UpdateDayTimer(timeRemainingDayString);
            yield return null;
        }
    }
}
