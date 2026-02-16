using UnityEngine;

using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxThreshold; 
    [SerializeField] private float originalSpeed;
    [SerializeField] private float rotationSpeed;
    private bool isCrouching = false;
    private bool isRunning = false;
    private float speed;
    private Vector2 inputDirection; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = originalSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Debug.Log($"inputDirection = {inputDirection}");
        //Vector2 dPos = GetTranslationVector(); 
        float angleZ = transform.eulerAngles.z;
        if(isCrouching)
        {
            speed = originalSpeed / 2f;
        }
        else if(isRunning)
        {
            speed = originalSpeed * 2f;
        }
        else
        {
            speed = originalSpeed;
        }

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

        if (Mathf.Abs(transform.position.x + dPos.x) > maxThreshold)
        {
            dPos.x = 0f;
        }

        if (Mathf.Abs(transform.position.y + dPos.y) > maxThreshold)
        {
            dPos.y = 0f;
        }

        return dPos;
    }

    private void OnMove(InputValue value)
    {
        inputDirection = value.Get<Vector2>();
    }
    private void OnCrouch(InputValue value)
    {
        isCrouching = value.isPressed;
        Debug.Log($"isCrouching = {isCrouching}");
    }

    private void OnRun (InputValue value)
    {
        isRunning = value.isPressed;
        Debug.Log($"isRunning = {isRunning}");
    }

}
