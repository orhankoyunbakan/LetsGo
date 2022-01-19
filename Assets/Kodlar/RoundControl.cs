using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundControl : MonoBehaviour
{

    float hiz=20;
    int can = 3;
    PlaneControl planeControl;
    // Start is called before the first frame update
    void Start()
    {
        planeControl = GameObject.FindGameObjectWithTag("PlayerPlane").GetComponent<PlaneControl>();
        hiz += planeControl.score / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, 0, 2);

        
        transform.Translate(0, -hiz * Time.deltaTime, 0);
        Debug.Log("can:" + planeControl.can);
    }

     void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="sınır")
        {
            planeControl.can--;
            Destroy(gameObject);
        }
    }
}
