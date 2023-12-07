using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ButtonControler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string hoverAnimation;
    [SerializeField] private string idleAnimation;

    private void OnEnable()
    {
        Play(idleAnimation);
    }

    public void Play(string anim)
    {
        GetComponent<Animation>().CrossFade(anim,0.5f);
    }
    
    public void Stop(string anim)
    {
        GetComponent<Animation>().CrossFade(anim,0.5f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Play(hoverAnimation);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Stop(idleAnimation);
    }
}
