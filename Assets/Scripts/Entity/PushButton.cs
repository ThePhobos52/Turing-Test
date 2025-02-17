using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButton : MonoBehaviour, ISelectable
{
    //[SerializeField] private Material defaultColour, hoverColour;
    //[SerializeField] private MeshRenderer buttonRenderer;

    public UnityEvent onPush;

    public UnityEvent onHoverEnter, onHoverExit;
    public void OnHoverEnter()
    {
        onHoverEnter?.Invoke();
    }

    public void OnHoverExit()
    {
        onHoverExit?.Invoke();
    }

    public virtual void OnSelect()
    {
        onPush?.Invoke();
    }

}
