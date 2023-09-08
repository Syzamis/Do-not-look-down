using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ButtonControler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string animation;
    
    public void Play(string s)
    {
        GetComponent<Animation>().Play(s);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Play(animation);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Play("Button Anim");
    }
}
