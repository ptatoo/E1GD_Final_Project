using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.InputSystem; 

public class GameManager : MonoBehaviour
{

    [SerializeField] private int gamePhase; //0 day, 1 night
    [SerializeField] private UnityEvent phaseChangeEvent; 
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject player;
    [SerializeField] UIManager UIManager;
    private int dayTimeLength = 5;
    private float timeRemainingDay;
    private float elapsedTimeNight;
    private bool isDayTimerRunning = false;
    private bool isNightTimerRunning = false;
    private Coroutine timerDayCoroutine;
    private Coroutine timerNightCoroutine;

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

    IEnumerator DayPhaseCoroutine (int phase)
    {
        StartDayTimer();
        for(int i = 0; i < dayTimeLength; i++)
        {
            yield return new WaitForSeconds(1.0f); 
        }
        phaseChangeEvent.Invoke(); 
        playerInput.SwitchCurrentActionMap("Night");

        var playerCollider = player.GetComponent<BoxCollider2D>();
        playerCollider.enabled = true;

        StopDayTimer();
        StartNightTimer();
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
