using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnamenuControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GelenButtonDeger(int deger)
    {
        if(deger==1)
        {
            SceneManager.LoadScene("PlaneGame");
        }
        else if (deger == 2)
        {
            SceneManager.LoadScene("TrainGame");
        }
        if (deger == 3)
        {
            SceneManager.LoadScene("ShipGame");
        }
    }
}
