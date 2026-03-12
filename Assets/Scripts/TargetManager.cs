using System.Collections;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField] private Transform targets;
    [SerializeField] private Transform goal1;
    [SerializeField] private Transform goal2;
    [SerializeField] private Transform goal3;


    private Transform[] targetArray; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(targets == null)
        {
            Debug.Log("Targets is Null");
            return;
        }

        int childCount = targets.childCount;
        targetArray = new Transform[childCount];

        for (int i = 0; i < childCount; i++)
        {
            targetArray[i] = targets.GetChild(i).transform; 
        }

        StartCoroutine(UpdateDestinations()); 
    }

    IEnumerator UpdateDestinations()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);

            goal1.position = targetArray[Random.Range(0, targetArray.Length)].position;
            goal2.position = targetArray[Random.Range(0, targetArray.Length)].position;
            goal3.position = targetArray[Random.Range(0, targetArray.Length)].position;

            Debug.Log("Destinations Updated");

        }
    }
}
