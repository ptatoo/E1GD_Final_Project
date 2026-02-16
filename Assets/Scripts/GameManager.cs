using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.InputSystem; 

public class GameManager : MonoBehaviour
{

    [SerializeField] private int gamePhase; //0 day, 1 night
    
    [SerializeField] private UnityEvent phaseChangeEvent; 
    [SerializeField] private PlayerInput playerInput; 

    void Awake()
    {
        StartCoroutine(DayPhaseCoroutine(gamePhase)); 
    }

    IEnumerator DayPhaseCoroutine (int phase)
    {
        for(int i = 1; i <= 5; i ++)
        {
            yield return new WaitForSeconds(1.0f); 
            Debug.Log(i); 
        }
        phaseChangeEvent.Invoke(); 
        playerInput.SwitchCurrentActionMap("Night"); 
    }
}
