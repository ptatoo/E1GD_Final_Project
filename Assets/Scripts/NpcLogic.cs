using Pathfinding;
using UnityEngine;

public class NpcLogic : MonoBehaviour
{
    [SerializeField] AILerp aiLerp; 

    public void EnableAILerp()
    {
        aiLerp.enabled = true; 
    }
}
