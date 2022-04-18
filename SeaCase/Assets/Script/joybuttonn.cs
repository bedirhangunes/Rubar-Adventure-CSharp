using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class joybuttonn : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    [HideInInspector]
    public bool press;
   public void OnPointerDown(PointerEventData eventData)
    {
        press = true;
    }

   public void OnPointerUp(PointerEventData eventData)
    {
        press = false;
    }
}
