using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayClick : MonoBehaviour
{
    public Image cursorGaugeImage;
    public GameObject mainCam;
    private float gaugeTimer = 0.0f;
    private float gazeTime = 2.0f;
    private float walkSpeed = 6.0f;
    private bool isMoving = false;
    private Vector3 goalPosition;
    private int isLanding = 0;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 forward = mainCam.transform.TransformDirection(Vector3.forward) * 1000;
        Debug.DrawRay(this.transform.position, forward, Color.green);
        cursorGaugeImage.fillAmount = gaugeTimer;

        if (Physics.Raycast(this.transform.position, forward, out hit) && hit.transform.name.Equals("Refrigerator") || hit.transform.name.Equals("Sofa.1") || hit.transform.name.Equals("Sofa") || hit.transform.name.Equals("BathSink") || hit.transform.name.Equals("Bathtub") || hit.transform.name.Equals("Bookshelf") || hit.transform.name.Equals("BigDrawer"))
        {
            gaugeTimer += 1.0f / gazeTime * Time.deltaTime;

            if (gaugeTimer >= 1.0f)
            {
                gaugeTimer = 0.0f;
                goalPosition = new Vector3(hit.transform.position.x, this.transform.position.y, hit.transform.position.z);
                isMoving = true;
                StartCoroutine(MoveForward());
            } 
        }
        else
            gaugeTimer = 0.0f;
    }

    IEnumerator MoveForward()
    {
        while (isMoving)
        {
           
            this.transform.position = Vector3.MoveTowards(this.transform.position, goalPosition, Time.deltaTime * walkSpeed);
            gaugeTimer = 0.0f;

            yield return null;
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.name.Equals("Refrigerator") || other.transform.name.Equals("Sofa.1") || other.transform.name.Equals("BathSink") || other.transform.name.Equals("Bathtub") || other.transform.name.Equals("Sofa") || other.transform.name.Equals("Bookshelf") || other.transform.name.Equals("BigDrawer")) 
            isMoving = false;  
    }
}
