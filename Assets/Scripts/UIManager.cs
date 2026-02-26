using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Light2D globalLight; 
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Light2D playerLight; 
    [SerializeField] TextMeshProUGUI cashText;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI phaseText;

    public void UpdateCash(int cash)
    {
        cashText.text = "Total Cash: $" + cash;
    }

    public void UpdateDayTimer(string time)
    {
        timerText.text = "Time Remaining: " + time;
    }

    public void UpdateNightTimer(string time)
    {
        timerText.text = "Time Elapsed: " + time;
    }
    
    public void ChangePhase()
    {
        globalLight.intensity = 0.0f;
        spriteRenderer.enabled = true; 
        playerLight.enabled = true;
        phaseText.text = "Robbing Phase";
    }
}
