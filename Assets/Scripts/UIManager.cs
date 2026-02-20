using UnityEngine;
using UnityEngine.Rendering.Universal;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Light2D globalLight; 
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Light2D playerLight; 

    public void ChangePhase()
    {
        globalLight.intensity = 0.0f;
        spriteRenderer.enabled = true; 
        playerLight.enabled = true; 
    }
}
