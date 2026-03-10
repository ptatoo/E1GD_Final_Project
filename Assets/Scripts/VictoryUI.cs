using UnityEngine;
using TMPro;

public class VictoryUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI cashText;
    [SerializeField] TextMeshProUGUI elapsedTimeText;

    void Start()
    {
        cashText.text = "Your Cash: $" + UIManager.m_cash;
        elapsedTimeText.text = "Elapsed Time: " + UIManager.m_time;
    }
}
