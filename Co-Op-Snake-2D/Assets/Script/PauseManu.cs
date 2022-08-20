using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManu : MonoBehaviour
{

public static bool IsGameObjectPaused = false;
    public GameObject PauseButtonUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGameObjectPaused)
            {
               Resemu();
            }
            else
            {
                Paused();
            }
        }
    }

    private void Paused()
    {
        PauseButtonUI.SetActive(true);
        Time.timeScale = 0f;
        IsGameObjectPaused = true;
    }

    private void Resemu()
    {
      
        PauseButtonUI.SetActive(false);
        Time.timeScale = 1f;
        IsGameObjectPaused = false;
    }
}
