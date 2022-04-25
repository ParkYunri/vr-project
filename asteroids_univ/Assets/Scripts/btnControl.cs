using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnControl : MonoBehaviour
{
    public Text btn;
    private float time;
    Spaceship sh;

    void Awake()
    {
        sh = GameObject.Find("ship").GetComponent<Spaceship>();
    }

    void Update()
    {
        time = sh.gameTime;
        btn.GetComponent<Text>().text = time.ToString();
    }
}
