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

    public GameObject WonImage;
    public GameObject LosImage;

    public Animator LeftAnimator;
    public Animator RightAnimator;

    // Start is called before the first frame update
    void Start()
    {
        // start with a clean score
        PlayerPrefs.DeleteAll();

        // start the game timer
        beginScreen.SetActive(true);
        endScreen.SetActive(false);

        LeftAnimator.SetFloat("DirtyLvl", 0);
        RightAnimator.SetFloat("DirtyLvl", 0);
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
            LeftAnimator.SetBool("GameActive", gameIsActive);
            RightAnimator.SetBool("GameActive", gameIsActive);
            MoveTshirt.transform.Translate(Vector3.right * speed * Time.deltaTime);

            float dirtyLvl =  Remap(MoveTshirt.transform.position.x, -5, 5, -1, 1);

            Debug.Log(dirtyLvl);
            LeftAnimator.SetFloat("DirtyLvl", -dirtyLvl);
            RightAnimator.SetFloat("DirtyLvl", dirtyLvl);
        }

     if (MoveTshirt.transform.position.x >= 4.2)
        {
            gameIsActive = false;
            WinnerName = "SPELER 2";
            winnerText.text =  WinnerName;
            WonImage.transform.position = PositionP2.position;
            LosImage.transform.position = PositionP1.position;
            endScreen.SetActive(true);
            MoveTshirt.transform.position = new Vector3(4.2f, MoveTshirt.transform.position.y, MoveTshirt.transform.position.z );
        }

     if (MoveTshirt.transform.position.x <= -4.2)
        {
            gameIsActive = false;
            WinnerName = "SPELER 1";
            winnerText.text = WinnerName;
            WonImage.transform.position = PositionP1.position;
            LosImage.transform.position = PositionP2.position;
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

    public float Remap( float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}