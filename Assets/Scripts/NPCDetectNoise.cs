using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class NPCDetectNoise : MonoBehaviour
{
    public float alertness;

    private float totalNoise;
    private float noiseReceived;
    [SerializeField] private float noiseLost;
    [Range(0, 1)] private float noiseDetectionRatio;

    private float distance; 

    private bool isReceiving;

    [SerializeField] UnityEvent OnNPCWakeUp;
    
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        alertness = 0;
        noiseDetectionRatio = 1f; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        totalNoise = 0f; 
        if (!isReceiving)
        {
            noiseReceived = 0f;
            distance = 1f; 
        }
        totalNoise = noiseReceived + noiseLost;
        //Debug.Log(totalNoise); 
        alertness += 10 * totalNoise / (distance) * Time.deltaTime;

        if (alertness < 0) alertness = 0f;
        else if (alertness > 100)
        {
            alertness = 100f;
            OnNPCWakeUp.Invoke(); 
        }

        Debug.Log(alertness);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ENTER");
        var tx = collision.GetComponent<NoiseTransmitter>();

        if (tx == null) return;

        tx.OnNoise += UpdateNoiseLevel;
        isReceiving = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("EXIT");
        var tx = collision.GetComponent <NoiseTransmitter>();

        if (tx == null) return;

        tx.OnNoise -= UpdateNoiseLevel;
        isReceiving = false;
    }

    private void UpdateNoiseLevel(int noise, Vector2 pos)
    {
        //Debug.Log(noise);
        noiseReceived = 0; 
        distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), pos);
        noiseReceived += noise;

        //if (alertness > 100) alertness = 100f; 
    }


    public void FireOnNPCWakeUp()
    {
        OnNPCWakeUp.Invoke(); 
    }
    
}
