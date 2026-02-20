using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class NoiseTransmitter : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private PlayerInput playerInput; 

    private int noiseLevel;

    public Action<int, Vector2> OnNoise;


    public void SetNoiseLevel(int newNoiseLevel)
    {
        noiseLevel = newNoiseLevel;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerInput.currentActionMap.name == "Night")
        {
            Debug.Log(noiseLevel);
            OnNoise?.Invoke(noiseLevel, new Vector2(playerTransform.position.x, playerTransform.position.y));
        }
    }


}
