using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spaceship : MonoBehaviour
{
    public GameObject head;
    public GameObject mainCam;
    public GameObject ship;
    float cur_angle;
    float prev_angle;
    float delta_angle;
    public float gameTime;

    // Start is called before the first frame update
    void Update()
    {
        gameTime += Time.deltaTime;

        MoveForward();
    }

    // Update is called once per frame
    void MoveForward()
    {
        head.transform.Translate(mainCam.transform.forward * 0.3f);

        cur_angle = mainCam.transform.eulerAngles.y;
        delta_angle = cur_angle - prev_angle;
        prev_angle = cur_angle;

        if(delta_angle < 0)
        {
            ship.transform.rotation = Quaternion.Lerp(ship.transform.rotation,
                Quaternion.Euler(ship.transform.eulerAngles.x, ship.transform.eulerAngles.y, 45), Time.deltaTime);
        }
        else if (delta_angle > 0)
        {
            ship.transform.rotation = Quaternion.Lerp(ship.transform.rotation,
                Quaternion.Euler(ship.transform.eulerAngles.x, ship.transform.eulerAngles.y, -45), Time.deltaTime);
        }
        else
        {
            ship.transform.rotation = Quaternion.Lerp(ship.transform.rotation,
                Quaternion.Euler(ship.transform.eulerAngles.x, ship.transform.eulerAngles.y, 0), Time.deltaTime);
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(30, 10, 100, 20), gameTime.ToString());
    }
}
