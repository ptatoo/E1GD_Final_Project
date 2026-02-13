using UnityEngine;

using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxThreshold; 
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    private Vector2 inputDirection; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Debug.Log($"inputDirection = {inputDirection}");
        //Vector2 dPos = GetTranslationVector(); 
        float angleZ = transform.eulerAngles.z;
        //transform.Translate(dPos); 
        if (inputDirection.y > 0)
        {
            transform.position = new Vector2(transform.position.x + Mathf.Cos(angleZ * Mathf.PI / 180) * speed * Time.deltaTime, transform.position.y + Mathf.Sin(angleZ * Mathf.PI / 180) * speed * Time.deltaTime);
        }
        else if (inputDirection.y < 0)
        {
            transform.position = new Vector2(transform.position.x - Mathf.Cos(angleZ * Mathf.PI / 180) * speed * Time.deltaTime, transform.position.y - Mathf.Sin(angleZ * Mathf.PI / 180) * speed * Time.deltaTime);
        }
        if (inputDirection.x < 0)
        {
            transform.Rotate(new Vector3(0, 0,  rotationSpeed * Time.deltaTime));
        }
        else if (inputDirection.x > 0)
        {
            transform.Rotate(new Vector3(0, 0, - rotationSpeed * Time.deltaTime));
        }


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
