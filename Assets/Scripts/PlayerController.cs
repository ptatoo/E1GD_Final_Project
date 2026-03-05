using System;
using UnityEngine;

using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxThreshold; 
    [SerializeField] private float originalSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] GameObject flashlight;
    private bool isCrouching = false;
    private bool isRunning = false;
    private float speed;

    private Vector2 inputDirection; 
    private Vector2 mousePos;

    private int SCREEN_WIDTH = Screen.width;
    private int SCREEN_HEIGHT = Screen.height;
    [SerializeField] private float interactDistance;
    [SerializeField] private LayerMask interactLayer;


    [SerializeField] private NoiseTransmitter noiseTransmitter;
    [SerializeField] UIManager UIManager;

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
            noiseTransmitter.SetNoiseLevel(3);
        }
        else if(isRunning)
        {
            speed = originalSpeed * 1.5f;
            noiseTransmitter.SetNoiseLevel(15);
        }
        else
        {
            speed = originalSpeed;
            noiseTransmitter.SetNoiseLevel(6);
        }

        if(inputDirection == Vector2.zero)
        {
            noiseTransmitter.SetNoiseLevel(0);
        }

        //move player
        transform.position = new Vector2(transform.position.x + inputDirection.x * speed * Time.deltaTime, transform.position.y + inputDirection.y * speed * Time.deltaTime);
        float rotation = Mathf.Atan2(mousePos.y, mousePos.x);
        flashlight.transform.rotation = Quaternion.Euler(0, 0, rotation / Mathf.PI * 180 - 90);
        Debug.DrawRay(transform.position, mousePos.normalized * interactDistance, Color.green); // for debugging in scene view
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

    private void OnPoint(InputValue value)
    {
        //calculates mouse Position relative to Player
        Vector2 temp = value.Get<Vector2>();
        mousePos = new Vector2(temp.x - SCREEN_WIDTH / 2, temp.y - SCREEN_HEIGHT / 2);
    }

    private void OnInteract(InputValue value)
    {
        Vector2 rayDirection = mousePos.normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, interactDistance, interactLayer);
        if (hit.collider != null && hit.collider.CompareTag("Interactable"))
        {
            hit.collider.gameObject.SetActive(false);
            try
            {
                UIManager.addCash(hit.collider.gameObject.GetComponent<CoinScript>().getCash());
            }
            catch { UIManager.addCash(100); }
        }
        else if (hit.collider != null && hit.collider.CompareTag("Door"))
        {
            RotateDoor rotate = hit.collider.gameObject.GetComponent<RotateDoor>();
            rotate.rotate();
        }
    }
}
