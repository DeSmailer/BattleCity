using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ResultGame
{
    public static void Win()
    {
        SceneManager.LoadScene("WinScene");
    }

    public static void Lose()
    {
        SceneManager.LoadScene("LoseScene");
    }
}
