using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenCtrl : MonoBehaviour
{
    public GameObject hitEffect;
    public GameObject[] target;
    public GameObject[] obstacle;
    private int numGridRow = 8;
    private int numGridCol = 10;
    private bool[,] isFilled;
    private int numTarget = 0;
    private int maxTarget = 4;
    private int maxObstacle = 9;

    

    void Start()
    {
        isFilled = new bool[numGridRow, numGridCol];
        for(int i = 0; i < numGridRow; i++)
        {
            for(int j = 0; j < numGridCol; j++)
                isFilled[i, j] = false;   
        }
        GenerateObstacle();
        GenerateTarget();
    }

    void Update()
    {   
        if (numTarget != 4)
        {
            GenerateTarget();
        }
    }

    void GenerateObstacle()
    {
        int row, col, numObstacle;
        Vector3 targetPosition;

        for(int i = 0; i < maxObstacle; i++)
        {
            numObstacle = 0;
            while(numObstacle < 3)
            {
                row = (int)Random.Range(0.0f, 8.0f);
                col = (int)Random.Range(0.0f, 10.0f);

                if(!isFilled[row, col])
                {
                    targetPosition.x = -25.0f + 5.0f * col + 2.5f;
                    targetPosition.z = 10.0f + 5.0f * row + 2.5f;
                    targetPosition.y = 10.0f;

                    Instantiate(obstacle[i], targetPosition, Quaternion.identity);

                    isFilled[row, col] = true;
                    numObstacle++;
                }
            }
        }
    }

    void GenerateTarget()
    {
        int row, col;
        Vector3 targetPosition;

        while (numTarget < maxTarget)
        {
            row = (int)Random.Range(0.0f, 8.0f);
            col = (int)Random.Range(0.0f, 10.0f);

            if (!isFilled[row, col])
            {
                targetPosition.x = -25.0f + 5.0f * col + 2.5f;
                targetPosition.z = 10.0f + 5.0f * row + 2.5f;
                targetPosition.y = 10.0f;

                Instantiate(target[(int)Random.Range(0.0f, 2.0f)], targetPosition, Quaternion.identity);

                isFilled[row, col] = true;
                numTarget++;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            Destroy(other.gameObject);
            GameObject hitObject = Instantiate(hitEffect, other.transform.position, other.transform.rotation);
            Destroy(hitObject, 1.0f);
            numTarget--;
        }
    }
}
