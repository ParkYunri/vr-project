using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndBtn : MonoBehaviour
{
    public Image CursorGaugeImage;
    private float gaugeTimer = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
       
        RaycastHit hit;
        Vector3 forward = this.transform.TransformDirection(Vector3.forward) * 1000;
        CursorGaugeImage.fillAmount = gaugeTimer;

        if (Physics.Raycast(this.transform.position, forward, out hit))
        {
            gaugeTimer += 1.0f / 2.0f * Time.deltaTime;
            if (gaugeTimer >= 1.0f)
            {
                hit.transform.GetComponent<Button>().onClick.Invoke();
                gaugeTimer = 0.0f;
            }
        }
        else
            gaugeTimer = 0.0f;
    }
}
