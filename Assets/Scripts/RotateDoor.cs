using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class RotateDoor : MonoBehaviour
{
    private bool isOpen = false;
    private bool isRotation = false;
    private bool canOpen = true;
    private float interp = 0f;
    private Vector3 initRotation;
    [SerializeField] private string rotationDirection = "counter-clockwise";

    [SerializeField] private AudioClip doorClip; 
    void Start()
    {
        initRotation = transform.rotation.eulerAngles;
    }
    
    public void SetIsOpen(bool isOpen)
    {
        this.isOpen = isOpen;
    }

    public bool GetIsOpen()
    {
        return isOpen;
    }

    public void SetCanOpen(bool canOpen)
    {
        this.canOpen = canOpen;
    }


    public void rotate()
    {
        if (!canOpen) return;

        if (isOpen && isRotation == false) { 
            isRotation = true;
            isOpen = false; 
            StartCoroutine(OpenDoor()); 
        }
        else if (isRotation == false)
        {
            isRotation = true;
            isOpen = true;  
            StartCoroutine(CloseDoor()); 
        }

        SFXManager.Instance.PlaySFX(doorClip);
    }

    IEnumerator OpenDoor()
    {
        while (interp < 1.0f)
        {
            interp += Time.deltaTime;
            float z;
            if (rotationDirection == "counter-clockwise")
            {
                z = initRotation.z + 180 - interp * 180;
            }
            else
            {
                z = initRotation.z + 180 + interp * 180;
            }
                transform.rotation = Quaternion.Euler(initRotation.x, initRotation.y, z);
            yield return null;
        }
        interp = 0.0f;
        isRotation = false;
    }
    IEnumerator CloseDoor()
    {
        while (interp < 1.0f)
        {
            interp += Time.deltaTime;
            float z;
            if (rotationDirection == "counter-clockwise")
            {
                z = initRotation.z + interp * 180;
            }
            else
            {
                z = initRotation.z - interp * 180;
            }
            transform.rotation = Quaternion.Euler(initRotation.x, initRotation.y, z);
            yield return null;
        }
        interp = 0.0f;
        isRotation = false;
    }
}
