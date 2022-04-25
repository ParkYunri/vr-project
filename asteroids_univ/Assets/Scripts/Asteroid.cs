using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Asteroid : MonoBehaviour
{
    public GameObject explosion;
    public AudioClip explosionSound;
    private int trig = 0;

    private void Awake()
    {
        trig = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Crash());
        trig = trig + 1;
        if (trig == 2)
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    IEnumerator Crash()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        //this.gameObject.GetComponent<Collider>().enabled = false;
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(explosionSound);
        explosion.SetActive(true);

        yield return new WaitForSeconds(1.0f);
        
        Destroy(this.gameObject);
    }
}
