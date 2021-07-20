using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Restart()
    {
        print("SampleScene");
        SceneManager.LoadScene("SampleScene");
    }
}
