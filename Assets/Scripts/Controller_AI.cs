using UnityEngine;
using Pathfinding;
using UnityEngine.Events;

public class Controller_AI : MonoBehaviour
{
    [SerializeField] Transform dest1;
    [SerializeField] Transform dest2;
    [SerializeField] Transform playerPos;
    [SerializeField] UnityEvent onNpnWakeUP;
    bool npcWakeUp = false;



    AILerp ai;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ai = GetComponent<AILerp>();
        ai.destination = dest2.position;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Distance from d1: "+(transform.position - dest1.position).magnitude);
                Debug.Log("Distance from d2: "+(transform.position - dest2.position).magnitude);
        if (npcWakeUp)
            ai.destination = playerPos.position;
        else
        {
            Debug.Log("CHECKIIINGGG");

            if ((transform.position - dest2.position).magnitude < 0.6f)
            {
                ai.destination = dest1.position;
                Debug.Log((transform.position - dest2.position).magnitude);
            }
            else if ((transform.position - dest1.position).magnitude < 0.6f)
            {
                ai.destination = dest2.position;

            }
            else
            {
            }
        }
  

    }
    public void NpnOn()
    {
        npcWakeUp = true;
    }
}
