using UnityEngine;

public class HouseTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameManager gameManager;
    [SerializeField] private bool enterTrigger = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (enterTrigger) gameManager.enterHouseUpdate(true);
        else gameManager.exitHouseUpdate(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (enterTrigger) gameManager.enterHouseUpdate(false);
        else gameManager.exitHouseUpdate(false);
    }
}
