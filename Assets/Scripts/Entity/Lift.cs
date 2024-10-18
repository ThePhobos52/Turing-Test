using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] private float moveDistance;
    [SerializeField] private bool isUp;
    [SerializeField] private float speed;
    [SerializeField] private Vector3[] destinationPoints;

    Vector3 destinationPoint;
    bool isMoving;

    private void Start()
    {
        for (int i = 0; i < destinationPoints.Length; i++) 
        {
            destinationPoints[i] = transform.localPosition + destinationPoints[i];
        }
    }

    public void ToggleLift()
    {
        if (isUp)
        {
            destinationPoint = destinationPoints[0];
            isUp = false;
        }
        else
        {
            destinationPoint = destinationPoints[1];
            isUp = true;
        }

        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, destinationPoint, speed * Time.deltaTime);
        }

        if(Vector3.Distance(transform.localPosition, destinationPoint) <= 0.05f)
        {
            isMoving = false;
        }
    }
}
