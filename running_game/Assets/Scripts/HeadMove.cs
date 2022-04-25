using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadMove : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject text;
    private float moveSpeed = 10.0f;
    private float runSpeed = 13.0f;
    private float positionX = 0.0f;
    private float accel = 0.5f;

    private float time;
    private bool isTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpeedUp());
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        positionX = this.transform.position.x - mainCam.transform.rotation.z * moveSpeed / 90.0f;

        this.transform.position = new Vector3(positionX, this.transform.position.y, this.transform.position.z);
        Run();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        { 
            //moveSpeed = 0.0f;
            runSpeed = 0.0f;
            Time.timeScale = 0;
            text.gameObject.SetActive(true);
            StartCoroutine(SpeedDown());
        }
    } 

    void Run()
    {
        this.transform.position += this.transform.forward * runSpeed * Time.deltaTime;
    }

    IEnumerator SpeedUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);
            runSpeed += accel;
        }
    }

    IEnumerator SpeedDown()
    {
        yield return new WaitForSeconds(3.0f);
        time = 0.0f;
        Time.timeScale = 1;
        
        text.gameObject.SetActive(false);
        Run();
        Debug.Log(runSpeed);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(30, 10, 100, 20), time.ToString());
    }
}
