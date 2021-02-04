using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject MoveTshirt;
    public float speed;

    // The popscreens for the info
    public GameObject beginScreen;
    public GameObject endScreen;

    public float startTimer = 10f;
    public Text StartTimer;

    private float endTimer = 100f;

    public bool gameIsActive = false;

    private string WinnerName;
    public Text winnerText;

    public RectTransform PositionP1;
    public RectTransform PositionP2;

    public RectTransform WonImage;
    public RectTransform LosImage;

    // Start is called before the first frame update
    void Start()
    {
        // start with a clean score
        PlayerPrefs.DeleteAll();

        // start the game timer
        beginScreen.SetActive(true);
        endScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        startTimer -= Time.deltaTime;
        int seconds = Mathf.FloorToInt(startTimer);
        StartTimer.text = seconds.ToString();

        if (startTimer <= 0)
        {
            beginScreen.SetActive(false);
            gameIsActive = true;
        }

        if (gameIsActive == true)
         {
            MoveTshirt.transform.Translate(Vector3.right * speed * Time.deltaTime);
            //MoveTshirt.transform.position = Vector3.MoveTowards(MoveTshirt.transform.position, Vector3.right, speed * Time.deltaTime);
            //Vector3 destination = Vector3.up * speed * Time.deltaTime;
            //MoveTshirt.transform.transform.position = Vector3.Lerp(MoveTshirt.transform.position, destination, speed * Time.deltaTime);
        }

     if (MoveTshirt.transform.position.x >= 4.2)
        {
            gameIsActive = false;
            WinnerName = "SPELER 2";
            winnerText.text =  WinnerName;
            WonImage.position = PositionP2.position;
            LosImage.position = PositionP1.position;
            endScreen.SetActive(true);
            MoveTshirt.transform.position = new Vector3(4.2f, MoveTshirt.transform.position.y, MoveTshirt.transform.position.z );
        }

     if (MoveTshirt.transform.position.x <= -4.2)
        {
            gameIsActive = false;
            WinnerName = "SPELER 1";
            winnerText.text = WinnerName;
            WonImage.position = PositionP1.position;
            LosImage.position = PositionP2.position;
            endScreen.SetActive(true);
            MoveTshirt.transform.position = new Vector3(-4.2f, MoveTshirt.transform.position.y, MoveTshirt.transform.position.z );
        }
     if (endScreen.activeSelf == true)
        {
            endTimer -= Time.deltaTime;

            if (endTimer <= 0 ^ Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene(sceneName: "StartScene");
            }
        }
    }
}