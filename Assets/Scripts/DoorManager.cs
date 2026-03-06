using UnityEngine;

public class DoorManager : MonoBehaviour
{

    [SerializeField] private Transform doors;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenAllDoors()
    {
        foreach (Transform child in doors)
        {
            var rotateDoor = child.GetComponent<RotateDoor>();

            if (rotateDoor.GetIsOpen()) continue;

            rotateDoor.rotate();
            rotateDoor.SetCanOpen(false); 

        }
    }
}
