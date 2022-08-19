using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScrene : MonoBehaviour
{
    public void MoveScreen(int ScrenID)
    {
        SceneManager.LoadScene(ScrenID);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
