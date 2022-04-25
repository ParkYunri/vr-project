using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    public Image cursorGaugeImage;
    public GameObject mainCam;
    public GameObject player;
    private float gaugeTimer = 0.0f;
    private float maxGauge = 5.0f;
    private bool isMouseHold = false;
    private Vector3 distance2Player;
    private bool isFired = false;
    private float zeroSpeed = 0.1f;
    public Vector3 initPlayerPosition;

    public Button success;
    public Button failed;
    public Text myScore;
    public int score = 5;

    private bool shooted = false;

    // Start is called before the first frame update
    void Start()
    {
        distance2Player = player.transform.position - this.transform.position;
        initPlayerPosition = player.transform.position;
        myScore = GameObject.Find("Score").GetComponent<Text>();
        success = GameObject.Find("Success").GetComponent<Button>();
        failed = GameObject.Find("Failed").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.rotation = mainCam.transform.rotation;
        myScore.text = "Score: " + score.ToString();

        if (Input.GetMouseButtonDown(0))
            isMouseHold = true;

        if (isMouseHold)
        {
            gaugeTimer += Time.deltaTime;
            if (gaugeTimer >= maxGauge)
            {
                isMouseHold = false;
                gaugeTimer = 0.0f;
            }
            if (Input.GetMouseButtonUp(0))
                Fire();
        }
        cursorGaugeImage.fillAmount = gaugeTimer / maxGauge;

        if (shooted)
        {
            score = score + 3;
            shooted = false;
        }

        if (score < 0)
            failed.gameObject.SetActive(true);
        if (score == 10)
            success.gameObject.SetActive(true);
        failed.onClick.Invoke();
        success.onClick.Invoke();

        if (isFired && player.gameObject.GetComponent<Rigidbody>().velocity.magnitude <= zeroSpeed)
            StartCoroutine(Restart());
        if (player.gameObject.transform.position.y <= -5)
            StartCoroutine(Restart());
    }
    
    IEnumerator TurnOnFire()
    {
        yield return new WaitForSeconds(3.0f);
        isFired = true;
        player.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(1.0f);

        player.gameObject.GetComponent<Rigidbody>().useGravity = false;
        player.transform.position = initPlayerPosition;
        player.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero; //속도0
        player.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; //회전각도0

        isFired = false;
    }

    void Fire()
    {
        player.gameObject.GetComponent<Rigidbody>().useGravity = true;
        player.gameObject.GetComponent<Rigidbody>().AddForce(mainCam.transform.TransformDirection(Vector3.forward) * gaugeTimer * 200.0f);
        score--;
        isMouseHold = false;
        gaugeTimer = 0.0f;
        StartCoroutine(TurnOnFire());
    }

    void LateUpdate()
    {
        this.transform.position = player.transform.position - mainCam.transform.TransformDirection(distance2Player);
    }
    
    public void RestartFailed()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Restart();
            failed.gameObject.SetActive(false);
        }
    }

    public void RestartSuccess()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Restart();
            success.gameObject.SetActive(false);
        }
    }
}
