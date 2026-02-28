using Pathfinding;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class NpcLogic : MonoBehaviour
{
    [SerializeField] private AILerp aiLerp;
    [SerializeField] private Collider2D visionCollider;
    [SerializeField] private UnityEvent OnFireOnNPCWakeUp;

    public void EnableAILerp()
    {
        aiLerp.enabled = true; 
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInput playerInput = collision.gameObject.GetComponent<PlayerInput>();

            if (playerInput.currentActionMap.name == "Night")
            {
                Debug.Log("PLAYEEEEEEEEEEEER");
                OnFireOnNPCWakeUp.Invoke();
            }
        }
    }



}
