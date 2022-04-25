using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayClick : MonoBehaviour
{
    private float GaugeTimer = 0.0f;
    private bool isPlaying = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 1000;

        if (Physics.Raycast(transform.position, forward, out hit))
        {
            GaugeTimer += 1.0f / 2.0f * Time.deltaTime;

            if (GaugeTimer >= 1.0f)
            {
                if (isPlaying) //영상 재생중일때
                {
                    hit.transform.GetComponent<Button>().onClick.Invoke();
                    isPlaying = false;
                }
                else if(!isPlaying) //영상 일시정지일때
                {
                    hit.transform.GetComponent<Button>().onClick.Invoke();
                    isPlaying = true;
                }
                GaugeTimer = 0.0f;
            }
        }
    }
}
