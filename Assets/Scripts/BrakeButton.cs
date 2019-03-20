using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BrakeButton : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        AirPlaneControl.IsBraking = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        AirPlaneControl.IsBraking = false;
    }
}
