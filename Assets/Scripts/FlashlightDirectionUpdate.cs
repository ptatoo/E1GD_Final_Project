using UnityEngine;

public class FlashlightDirectionUpdate : MonoBehaviour
{
    private Vector3 lastPosition;
    [SerializeField] private Transform flashlightTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPosition = Vector3.zero;     
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = transform.position - lastPosition;
        lastPosition = transform.position;
        diff = diff.normalized;

        if (diff == Vector3.up)
        {
            flashlightTransform.eulerAngles = Vector3.zero;
        }
        else if (diff == Vector3.down)
        {
            flashlightTransform.eulerAngles = new Vector3(0, 0, 180);
        }
        else if (diff == Vector3.right)
        {
            flashlightTransform.eulerAngles = new Vector3(0, 0, 270);
        }
        else if (diff == Vector3.left)
        {
            flashlightTransform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (diff.x > 0 && diff.y > 0) //Up Right
        {
            flashlightTransform.eulerAngles = new Vector3(0, 0, 315);
        }
        else if (diff.x < 0 && diff.y > 0) //Up Left
        {
            flashlightTransform.eulerAngles = new Vector3(0, 0, 45);
        }
        else if (diff.x > 0 && diff.y < 0) //Down Right
        {
            flashlightTransform.eulerAngles = new Vector3(0, 0, 225);
        }
        else if (diff.x < 0 && diff.y < 0) //Down Left
        {
            flashlightTransform.eulerAngles = new Vector3(0, 0, 135);
        }
    }
}
