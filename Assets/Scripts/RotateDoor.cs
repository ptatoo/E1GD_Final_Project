using System.Collections;
using UnityEngine;

public class RotateDoor : MonoBehaviour
{
    private bool isOpen = false;
    private bool isRotation = false;
    private float interp = 0f;
    private Vector3 initRotation;
    [SerializeField] private string rotationDirection = "counter-clockwise";
    void Start()
    {
        initRotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rotate()
    {
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
