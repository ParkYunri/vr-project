using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public Transform playerPosition;
    public GameObject[] maps = new GameObject[3];
    private int numSpawnedMap;

    // Start is called before the first frame update
    void Start()
    {
        numSpawnedMap = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerPosition.position.z >= 50 * (numSpawnedMap - 2))
        {
            Vector3 nextSpawn = new Vector3(0, 0, 50 * numSpawnedMap);
            Instantiate(maps[Random.Range(0, 3)], nextSpawn, transform.rotation);
            numSpawnedMap++;
           
        }
        Destroy(this.transform.gameObject);
    }
}
