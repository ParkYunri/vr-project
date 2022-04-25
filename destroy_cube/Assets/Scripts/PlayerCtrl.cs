using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public Image CursorGaugeImage;
    private Vector3 ScreenCenter;
    private float GaugeTimer;

    // Start is called before the first frame update
    void Start()
    {
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter);
        RaycastHit hit;
        CursorGaugeImage.fillAmount = GaugeTimer;

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.collider.CompareTag("cube"))
            {
                GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                if (GaugeTimer >= 1.0f)
                {
                    hit.transform.gameObject.SetActive(false);
                    GaugeTimer = 0.0f;
                }
            }
        }
        else
            GaugeTimer = 0.0f;
    }
}
