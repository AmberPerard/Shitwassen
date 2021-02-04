using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCalculate : MonoBehaviour
{

    //private float timer = 5f;
    //private int P1Clicks;
    //private int P2Clicks;

    private float timerL;
    private float timerK;
    //private float speedL;
    //private float speedK;
    //private float clicksPerSecL;
    //private float clicksPerSecK;

    private  float speedAddative;

    public GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetKeyDown("l")) {
            Debug.Log("L had " + timerL + " seconds sinds the last click.");
            timerL = 0;
        }

        if(Input.GetKeyDown("k")) {
            Debug.Log("K had " + timerK + " seconds sinds the last click.");
            timerK = 0;
        }

        timerL += Time.deltaTime;
        timerK += Time.deltaTime;
            
        speedAddative = (1/timerL) - (1/timerK);
        Debug.Log("speed: "+ speedAddative);
        gameController.speed = -(speedAddative/10);
}
}
