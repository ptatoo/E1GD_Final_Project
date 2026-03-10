using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Light2D globalLight; 
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Light2D playerLight;
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] TextMeshProUGUI cashText;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI phaseText;
    [SerializeField] GameObject noiseLevelBarBackground;
    [SerializeField] GameObject noiseLevelBarForeground;
    public static int m_cash = 0;
    public static string m_time = "0:00";

    void Awake()
    {
        m_cash = 0;
    }

    public void UpdateCash(int cash)
    {
        cashText.text = "Total Cash: $" + cash;
    }

    public void AddCash(int cash)
    {
        m_cash += cash;
        UpdateCash(m_cash);
    }

    public void UpdateDayTimer(string time)
    {
        timerText.text = "Time Remaining: " + time;
    }

    public void UpdateNightTimer(string time)
    {
        m_time = time;
        timerText.text = "Time Elapsed: " + time;
    }

    public void UpdateNoiseLevelSliderValue(float noiseLevel)
    {
        noiseLevelBarForeground.transform.localScale = new Vector3(noiseLevel/100f, 1, 1);
    }
    
    public void UpdateNoiseLevelSliderPosition(Vector3 position)
    {
        noiseLevelBarBackground.transform.position = position;
    }

    public void ChangePhase()
    {
        globalLight.intensity = 0.0f;
        spriteRenderer.enabled = true; 
        playerLight.enabled = true;
        phaseText.text = "Robbing Phase";
        playerCollider.enabled = true;
    }
}
