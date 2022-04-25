using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject asteroid;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAsteroid());
    }

   IEnumerator SpawnAsteroid()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);

            Vector3 pos = this.transform.position +
                new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), Random.Range(-4, 4));
            Instantiate(asteroid, pos, Quaternion.identity);
        }
    }
}
