////////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2018 Audiokinetic Inc. / All Rights Reserved
//
////////////////////////////////////////////////////////////////////////

﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SliderControlledRTPC : MonoBehaviour
{

    

    //public AK.Wwise.RTPC RTPC;
    private Slider slider;
    public AudioMixer masterMixer;
    public bool isMusicSlider = false;


    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void SetRTPC(float value)
    {
        if (Menu.isOpen)
        {
            //RTPC.SetGlobalValue(value);
            if (isMusicSlider)
            {
                masterMixer.SetFloat("musicVol", slider.value);
            }
            else
            {
                masterMixer.SetFloat("masterVol", slider.value);
            }

            
        }
    }

}
