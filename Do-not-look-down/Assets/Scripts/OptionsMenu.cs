using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    [SerializeField] private Slider volumeSlider = null;
    
    public void VolumeChange()
    {
        Debug.Log(volumeSlider.value);    
    }
}
