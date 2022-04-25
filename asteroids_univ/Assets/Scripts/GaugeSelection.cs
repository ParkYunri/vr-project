using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GaugeSelection : MonoBehaviour
{
    float timeElapsed;
    public Image CursorGaugeImage;
    private bool isTriggered = false;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 forward = this.transform.TransformDirection(Vector3.forward) * 1000;
        CursorGaugeImage.fillAmount = timeElapsed;

        if (Physics.Raycast(this.transform.position, forward, out hit))
        {
            timeElapsed += 1.0f/ 2.0f * Time.deltaTime;

            if (timeElapsed >= 1.0f || isTriggered)
            {
                if (hit.collider.tag == "Ship01")
                    PlayerPrefs.SetInt("ship", 1);
                else if (hit.collider.tag == "Ship02")
                    PlayerPrefs.SetInt("ship", 2);
                else if (hit.collider.tag == "Ship03")
                    PlayerPrefs.SetInt("ship", 3);
                else if (hit.collider.tag == "Ship04")
                    PlayerPrefs.SetInt("ship", 4);
                else if (hit.collider.tag == "Ship05")
                    PlayerPrefs.SetInt("ship", 5);

                PlayerPrefs.Save();

                SceneManager.LoadScene("SampleScene");

                timeElapsed = 0.0f;
                isTriggered = false;
            }
                
        }
            
        else
            timeElapsed = 0.0f;

        Debug.Log(PlayerPrefs.GetInt("ship"));
    }
}
