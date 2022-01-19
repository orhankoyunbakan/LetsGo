using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;//joyistik için



public class PlaneControl : MonoBehaviour
{
    Vector3 ilkPozisyon;

    public GameObject yuvarlak;
    public float zeminhiz;
    GameObject zemin1, zemin2;
    float olusmaZaman=1.5f;
    public int score = 0;
    public int can = 3;
    public GameObject Options;
    public Button oyunDurdurBtn;
    bool oyunDurum = false;
    public Text ScoreText;
    public GameObject can1, can2,can3;
    public Button ButtonSagaGit;
    public Button ButtonSolaGit;


    // Start is called before the first frame update
    void Start()
    {

        ilkPozisyon = Input.acceleration;

        oyunDurum = true;
        Time.timeScale = 1;
        StartCoroutine(olustur());
        zemin1 = GameObject.FindGameObjectWithTag("zemin1");
        zemin2 = GameObject.FindGameObjectWithTag("zemin2");
    }

    // Update is called once per frame
    void Update()
    {
        JoystickHareketi();
        if (can == 2)
        {
            can3.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 100);
        }
        else if (can==1)
        {
            can2.GetComponent<SpriteRenderer>().color= new Color32(255,255,255,100);
        }
        else if(can==0)
        {
            can1.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 100);

        }
        ScoreText.text = score.ToString();

        if (can==0)
        {
            
            Invoke("OyunDurdur",1);
            oyunDurum = false;
            
            zeminhiz = 0;
            olusmaZaman = 100;
        }

        //Tuş ile ucak Hareketleri
        if (Input.GetKey(KeyCode.D) && transform.position.x <= 10 && oyunDurum == true )
        {
            transform.position = new Vector3(transform.position.x + 0.4f, transform.position.y, transform.position.z);
            transform.eulerAngles=new Vector3(0, 30, -5);

        }
        
        else if (Input.GetKey(KeyCode.A) && transform.position.x >= -10 &&  oyunDurum == true )
        {
            transform.position = new Vector3(transform.position.x -0.4f, transform.position.y, transform.position.z);
            transform.eulerAngles = new Vector3(0, -30, 5);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }


        //zemin hareketi

        if (zemin2.transform.position.y < -48 && zemin2.transform.position.y > -49)
        {
            zemin1.transform.position = new Vector3(zemin1.transform.position.x,-15, zemin1.transform.position.z);
        }
        if (zemin1.transform.position.y < -57  && zemin1.transform.position.y > -58)
        {
            zemin2.transform.position = new Vector3(zemin2.transform.position.x, -1.5f, zemin2.transform.position.z);
        }

        zemin1.transform.Translate(0, -zeminhiz * Time.deltaTime, 0);
        zemin2.transform.Translate(0, -zeminhiz * Time.deltaTime, 0);

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="yuvarlak")
        {
            score++;
            Destroy(col.gameObject);
        }
    }

    



    IEnumerator olustur()
    {


        while (true)
        {

          

                Vector3 vec = new Vector3(Random.Range(-13,13), 33, 0);
                //instantiate oluşturma yapmak için örneğin patlama efekti oluşturmak için
                Instantiate(yuvarlak, vec, Quaternion.identity);

                

           


            yield return new WaitForSeconds(olusmaZaman);

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
        if (can <= 0)
        {
            Options.transform.GetChild(0).gameObject.GetComponent<Button>().interactable = false;
        }
    }


    public void GelenYonBtnDeger(int deger)
    {
        

        if (deger == 1 && transform.position.x <= 10 && oyunDurum == true)//sağa git
        {
            transform.position = new Vector3(transform.position.x + 0.4f, transform.position.y, transform.position.z);
            transform.eulerAngles = new Vector3(0, 30, -5);
        }
         if (deger == -1 && transform.position.x >= -10 && oyunDurum == true)//sola git
        {
            transform.position = new Vector3(transform.position.x - 0.4f, transform.position.y, transform.position.z);
            transform.eulerAngles = new Vector3(0, -30, 5);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    public void OptionsGelenBtnDeger(int deger)
    {

        if (deger == 1)
        {
            oyunDurum = true;
            Options.SetActive(false);
            oyunDurdurBtn.gameObject.SetActive(true);
           
            Time.timeScale = 1;
        }
        else if (deger == 2)
        {
            SceneManager.LoadScene("PlaneGame");
        }
        else if (deger == 3)
        {
            SceneManager.LoadScene("Anamenu");
        }



    }


    void JoystickHareketi()
    {
        float moveSpeed = 20;

        float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");
        Debug.Log(horizontalInput);


        if (horizontalInput>0 && transform.position.x <= 10 && oyunDurum == true)
        {
            transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
            transform.eulerAngles = new Vector3(0, 30, -5);

        }

        else if (horizontalInput<0 && transform.position.x >= -10 && oyunDurum == true)
        {
            transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
            transform.eulerAngles = new Vector3(0, -30, 5);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
      
    }
}
