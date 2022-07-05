using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Switch to main scene
    public void SwitchToMain()
    {
        SceneManager.LoadScene(1);
    }
}
