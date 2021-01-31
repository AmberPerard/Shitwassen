using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject MoveTshirt;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      MoveTshirt.transform.Translate(Vector3.right * speed/100);

     if (MoveTshirt.transform.position.x >= 4.2)
        {
            MoveTshirt.transform.position = new Vector3(4.2f, MoveTshirt.transform.position.y, MoveTshirt.transform.position.z );
        }
     if (MoveTshirt.transform.position.x <= -4.2)
        {
            MoveTshirt.transform.position = new Vector3(-4.2f, MoveTshirt.transform.position.y, MoveTshirt.transform.position.z );
        }
    }
}