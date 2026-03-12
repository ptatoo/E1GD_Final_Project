using Pathfinding;
using UnityEngine;

public class MainMenuNPCController : MonoBehaviour
{
    [SerializeField] private Transform goal;
    private AILerp ai; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ai = GetComponent<AILerp>();
    }

    // Update is called once per frame
    void Update()
    {
        ai.destination = goal.position;
    }
}
