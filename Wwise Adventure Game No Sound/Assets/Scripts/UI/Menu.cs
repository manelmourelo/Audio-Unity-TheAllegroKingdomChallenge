////////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2018 Audiokinetic Inc. / All Rights Reserved
//
////////////////////////////////////////////////////////////////////////

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public delegate void MenuStateEvent(bool state);
public class Menu : MonoBehaviour
{
    public static bool isOpen = false;
    public static MenuStateEvent OnMenuStateChange;

    [Header("Other")]
    public AnimatedObjectActiveHandler ControlsBox;
    public AnimatedObjectActiveHandler QuestBox;
    public bool GetMouseWithP = false;

    public MenuEvent OnMenuDown;

    private bool menuOpen = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && GetMouseWithP) {
            PlayerManager.Instance.cameraScript.FreezeAndShowCursor(true, gameObject);
        }
    }

    private void OnEnable()
    {
        InputManager.OnMenuDown += ToggleMenu;
    }

    private void OnDisable()
    {
        InputManager.OnMenuDown -= ToggleMenu;
    }

    public void ToggleMenu()
    {
        if (isOpen || !DialogueManager.DialogueActive)
        {
            menuOpen = !menuOpen;
            isOpen = menuOpen;
            if (menuOpen)
            {
                // HINT: Play menu open sound here
                GameManager.Instance.gameSpeedHandler.PauseGameSpeed(gameObject.GetInstanceID());
                GameManager.Instance.BlurCam();

                QuestBox.EnableObject(0.5f);
#if UNITY_STANDALONE
                PlayerManager.Instance.cameraScript.FreezeAndShowCursor(true, gameObject);
                ControlsBox.EnableObject(0.5f);
#endif
            }
            else
            {
                // HINT: Play menu close sound here
                GameManager.Instance.gameSpeedHandler.UnPauseGameSpeed(gameObject.GetInstanceID());
                GameManager.Instance.UnBlurCam();
                QuestBox.DisableObject(0.25f);
#if UNITY_STANDALONE
                PlayerManager.Instance.cameraScript.FreezeAndShowCursor(false, gameObject);
                ControlsBox.DisableObject(0.25f);
#endif

            }

            if (OnMenuStateChange != null)
            {
                OnMenuStateChange(menuOpen);
            }

            OnMenuDown.Invoke(menuOpen);
        }
    }

    public void SetCameraSensitivity(float value)
    {
        PlayerManager.Instance.cameraScript.mouseSensitivity = value;
    }
}

[System.Serializable]
public class MenuEvent : UnityEvent<bool> { }