using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnBehaviour : MonoBehaviour
{

    private PlayerInput input;
    [SerializeField] private float turnSpeed;


    // Start is called before the first frame update
    void Start()
    {
        input = PlayerInput.GetInstance();    
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
    }

    void RotatePlayer()
    {
        // Rotate the whole body left and right
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * input.mouseX);
    }
}
