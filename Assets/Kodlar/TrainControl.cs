using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TrainControl : MonoBehaviour
{
    public float score=0;
    public Text ScoreText;
    bool sag;
    bool sol;
    bool oyunDurum = false;
    public float zeminhiz;
    GameObject zemin1,zemin2;
    public GameObject train3, train4, train5, train6;
    public GameObject Options;
    public Button oyunDurdurBtn;
    public Button ButtonSagaGit;
    public Button ButtonSolaGit;




    int can = 1;

    float olusmaZaman = 1.3f;
    
    // Start is called before the first frame update
    void Start()
    {
        oyunDurum = true;
        Time.timeScale = 1;
        StartCoroutine(olustur());
        zemin1 = GameObject.FindGameObjectWithTag("zemin1");
        zemin2 = GameObject.FindGameObjectWithTag("zemin2");
          
    }

    // Update is called once per frame
    void Update()
    {
       

        //Debug.Log("can:"+can);

        ScoreText.text = score.ToString();


        if(zemin2.transform.position.y<0 && zemin2.transform.position.y >-1)
        {
            zemin1.transform.position= new Vector3(zemin1.transform.position.x,90,zemin1.transform.position.z);
        }
        if (zemin1.transform.position.y < 0 && zemin1.transform.position.y > -1)
        {
            zemin2.transform.position = new Vector3(zemin2.transform.position.x, 90, zemin2.transform.position.z);
        }



        zemin1.transform.Translate(0, -zeminhiz * Time.deltaTime, 0);
        zemin2.transform.Translate(0, -zeminhiz * Time.deltaTime, 0);
        if (Input.GetKeyDown(KeyCode.D) && transform.position.x <= 7 && oyunDurum==true)
        {
            transform.position = new Vector3(transform.position.x + 8, transform.position.y, transform.position.z);

        }
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x >= -7 && oyunDurum == true)
        {
            transform.position = new Vector3(transform.position.x - 8, transform.position.y, transform.position.z);

        }

        /*
        if ( Input.touchCount>0)
        {
            Touch parmak = Input.GetTouch(0);
            Debug.Log(parmak.position.x);
           // Debug.Log(parmak.deltaPosition.x);
            if (parmak.deltaPosition.x >100 && transform.position.x <= 7 && oyunDurum == true)
            {
               
                sag = true;
                sol = false;
                
            }
            else if (parmak.deltaPosition.x <-100 && transform.position.x >= -7 && oyunDurum == true)
            {
                
                sag = false;
                sol = true;
            }

            if (sag == true )
            {
               
                transform.position = new Vector3(transform.position.x+8, transform.position.y, transform.position.z);
               

            }

            if (sol == true )
            {
               
                transform.position = new Vector3(transform.position.x-8, transform.position.y, transform.position.z);
              
            }
        }
        */

        
    }




    IEnumerator olustur()
    {
        

        while (true)
        {
          
                int sayi = Random.Range(0, 4);
                
                if (sayi==1)
                {
                    Vector3 vec = new Vector3(-8, 35, 0);
                    //instantiate oluşturma yapmak için örneğin patlama efekti oluşturmak için
                    Instantiate(train6, vec, Quaternion.Euler(0, 0, 90));

                    Vector3 vec1 = new Vector3(8, 55, 0);
                    //instantiate oluşturma yapmak için örneğin patlama efekti oluşturmak için
                    Instantiate(train3, vec1, Quaternion.Euler(0, 0, 90));
                    score++;

                }

                if (sayi == 2)
                {
                    Vector3 vec = new Vector3(0, 35, 0);
                    //instantiate oluşturma yapmak için örneğin patlama efekti oluşturmak için
                    Instantiate(train4, vec, Quaternion.Euler(0, 0, 90));

                    Vector3 vec1 = new Vector3(8, 50, 0);
                    //instantiate oluşturma yapmak için örneğin patlama efekti oluşturmak için
                    Instantiate(train5, vec1, Quaternion.Euler(0, 0, 90));

                    score++;
                }
                if (sayi == 3)
                {
                    Vector3 vec = new Vector3(8, 35, 0);
                    //instantiate oluşturma yapmak için örneğin patlama efekti oluşturmak için
                    Instantiate(train5, vec, Quaternion.Euler(0, 0, 90));

                    Vector3 vec1 = new Vector3(0, 45, 0);
                    //instantiate oluşturma yapmak için örneğin patlama efekti oluşturmak için
                    Instantiate(train6, vec1, Quaternion.Euler(0, 0, 90));

                    score++;
                }


                yield return new WaitForSeconds(olusmaZaman);

            }



        }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "train3" || col.gameObject.tag == "train4" || col.gameObject.tag == "train5" || col.gameObject.tag == "train6")
        {
            can = 0;
            Invoke("OyunDurdur", 3);
            oyunDurum = false;
            transform.GetChild(0).gameObject.SetActive(true);
            zeminhiz = 0;
            this.GetComponent<SpriteRenderer>().color = new Color(0.60f, 0.42f, 0.42f);
            olusmaZaman = 100;
            
        }
       
    }

    public void OyunDurdur()
    {
        oyunDurum = false;
        Time.timeScale = 0;
        Options.SetActive(true);
        oyunDurdurBtn.gameObject.SetActive(false);
        ButtonSagaGit.gameObject.SetActive(false);
        ButtonSolaGit.gameObject.SetActive(false);
        if (can==0)
        {
            Options.transform.GetChild(0).gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public void GelenYonBtnDeger(int deger)
    {

        if (deger == 1 && transform.position.x <= 7 && oyunDurum == true)//sağa git
        {
            transform.position = new Vector3(transform.position.x + 8, transform.position.y, transform.position.z);

        }

        if (deger == -1 && transform.position.x >= -7 && oyunDurum == true)//sola git
        {
            transform.position = new Vector3(transform.position.x - 8, transform.position.y, transform.position.z);

        }
    }


    public void OptionsGelenBtnDeger(int deger)
    {

        if(deger==1)
        {
            oyunDurum = true;
            Options.SetActive(false);
            oyunDurdurBtn.gameObject.SetActive(true);
            Time.timeScale = 1;
        }
        else if (deger == 2)
        {
            SceneManager.LoadScene("TrainGame");
        }
        else if (deger == 3)
        {
            SceneManager.LoadScene("Anamenu");
        }

        

    }


}
