using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCtrl : MonoBehaviour
{
    public Transform player;
    public GameObject target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (target.gameObject.transform.position.y < 0)
        {
            transform.LookAt(player);
        }
    }
}
