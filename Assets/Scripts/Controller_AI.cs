using UnityEngine;
using Pathfinding;
using UnityEngine.Events;

public class Controller_AI : MonoBehaviour
{
    [SerializeField] Transform dest1;
    [SerializeField] Transform dest2;
    [SerializeField] Transform playerPos;
    [SerializeField] UnityEvent onNpnWakeUP;

    [SerializeField] UnityEvent onGameEnd;

    bool npcWakeUp = false;

    [SerializeField] Vector3 lastPosition;
    [SerializeField] Transform visionTransform;
    [SerializeField] float gameOverDistance;



    AILerp ai;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ai = GetComponent<AILerp>();
        ai.destination = dest2.position;
        lastPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = transform.position - lastPosition; 
        lastPosition = transform.position;
        diff = diff.normalized;

        if (diff == Vector3.up)
        {
            visionTransform.eulerAngles = Vector3.zero;
        }
        else if (diff == Vector3.down)
        {
            visionTransform.eulerAngles = new Vector3(0, 0, 180); 
        }
        else if (diff == Vector3.right)
        {
            visionTransform.eulerAngles = new Vector3(0, 0, 270);
        }
        else if (diff == Vector3.left)
        {
            visionTransform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (diff.x > 0 && diff.y > 0) //Up Right
        {
            visionTransform.eulerAngles = new Vector3(0, 0, 315);
        }
        else if (diff.x < 0 && diff.y > 0) //Up Left
        {
            visionTransform.eulerAngles = new Vector3(0, 0, 45); 
        }else if(diff.x > 0 && diff.y < 0) //Down Right
        {
            visionTransform.eulerAngles = new Vector3(0, 0, 225); 
        }else if(diff.x < 0 && diff.y < 0) //Down Left
        {
            visionTransform.eulerAngles = new Vector3(0, 0, 135);
        }



        //Debug.Log("Distance from d1: " + (transform.position - dest1.position).magnitude);
        //Debug.Log("Distance from d2: " + (transform.position - dest2.position).magnitude);
        if (npcWakeUp)
        {
            ai.destination = playerPos.position;
            float distance = Vector3.Distance(playerPos.position, transform.position);

            if(distance <= gameOverDistance)
            {
                onGameEnd.Invoke();
            }
        }
        else
        {
            //Debug.Log("CHECKIIINGGG");

            if ((transform.position - dest2.position).magnitude < 0.6f)
            {
                ai.destination = dest1.position;
                //Debug.Log((transform.position - dest2.position).magnitude);
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
