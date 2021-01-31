using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCalculate : MonoBehaviour
{

    private float timer = 5f;
    private int P1Clicks;
    private int P2Clicks;

    public GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer < 1)
        {
            if (Input.GetKeyDown("l")) P1Clicks++;
            if (Input.GetKeyDown("k")) P2Clicks++;
        }
        else
        {
            Debug.Log("I had " + P1Clicks + " in that last second.");
            Debug.Log("I had " + P2Clicks + " in that last second.");

            int speedAddative = P1Clicks - P2Clicks;
            Debug.Log(speedAddative);
            gameController.speed = speedAddative/2;

            P2Clicks = 0;
            P1Clicks = 0;
            timer = 0f;
        }
    }
}
