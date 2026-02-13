using UnityEngine;
using UnityEngine.Rendering.Universal;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Light2D globalLight; 
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void ChangePhase()
    {
        globalLight.intensity = 0.1f;
        spriteRenderer.enabled = true; 
    }
}
