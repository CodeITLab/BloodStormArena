using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScripts : MonoBehaviour
{
    public void PracticeMode()
    {
        SceneManager.LoadScene("PracticeBattle");
    }

    public void ArcadeMode()
    {
        SceneManager.LoadScene("ArcadeBattle");
    }
}
