using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrainControl : MonoBehaviour
{
    TrainControl TrainControl;
     float hiz=20;
    
    // Start is called before the first frame update
    void Start()
    {
        TrainControl = GameObject.FindGameObjectWithTag("PlayerTrain").GetComponent<TrainControl>();
        hiz += TrainControl.score/2;
    }

    // Update is called once per frame
    void Update()
    {
        
      if(transform.position.y<-30)
        {
            Destroy(this.gameObject);
        }
        
      transform.Translate(-hiz * Time.deltaTime, 0, 0);
      //Debug.Log("hız:"+hiz);
      //Debug.Log("bolum:" + TrainControl.score);
    }

    

 }
