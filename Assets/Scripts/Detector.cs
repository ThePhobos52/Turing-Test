using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Events;

public class Detector : MonoBehaviour
{
    [SerializeField] int[] affectedLayers;
    [SerializeField] int targetNum;
    public UnityEvent ObjectDetected;
    public UnityEvent ObjectNotDetected;
    private int num;

    private void OnTriggerEnter(Collider other)
    {
        if (affectedLayers.Contains(other.gameObject.layer))
        {
            ObjectDetected?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (affectedLayers.Contains(other.gameObject.layer))
        {
            num++;
            if(num >= targetNum)
            {
                ObjectNotDetected?.Invoke();
            }
        }
    }
}
