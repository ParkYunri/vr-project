using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Btn : MonoBehaviour
{
    private float GaugeTimer;
    public Image CursorGaugeImage;
    private bool isTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 1000;
        CursorGaugeImage.fillAmount = GaugeTimer;

        if (Physics.Raycast(transform.position, forward, out hit))
        {
            GaugeTimer += 1.0f / 2.0f * Time.deltaTime;
            if (GaugeTimer >= 1.0f || isTriggered)
            {
                hit.transform.GetComponent<Button>().onClick.Invoke();
                GaugeTimer = 0.0f;
                isTriggered = false;
            }
        }
    }
}
