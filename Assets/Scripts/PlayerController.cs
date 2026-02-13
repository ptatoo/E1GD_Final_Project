using UnityEngine;

using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxThreshold; 
    [SerializeField] private float speed; 
    private Vector2 inputDirection; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log($"inputDirection = {inputDirection}");
        Vector2 dPos = GetTranslationVector(); 

        transform.Translate(dPos); 
    }

    private Vector2 GetTranslationVector()
    {
        Vector2 dPos = inputDirection * speed * Time.deltaTime;

        if(Mathf.Abs(transform.position.x + dPos.x) > maxThreshold)
        {
            dPos.x = 0f; 
        }

        if(Mathf.Abs(transform.position.y + dPos.y) > maxThreshold)
        {
            dPos.y = 0f; 
        }

        return dPos; 
    }

    private void OnMove(InputValue value)
    {
        inputDirection = value.Get<Vector2>(); 
    }
}
