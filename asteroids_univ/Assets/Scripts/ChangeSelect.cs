using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSelect : MonoBehaviour
{
    // Update is called once per frame
    public void ChangeSc()
    {
        SceneManager.LoadScene("SelectScene");
    }

    public void StartSc()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
