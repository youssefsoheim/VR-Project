using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Selectable : MonoBehaviour
{
    public Transform head;
    public Transform feet;
    [SerializeField] private string selectableTagL = "SelectableL";
    [SerializeField] private string selectableTagR = "SelectableR";
    [SerializeField] private TextMeshProUGUI txt;
  
    public GameObject Glight1;
    public GameObject Ylight1;
    public GameObject Rlight1;
    
    public GameObject Glight2;
    public GameObject Ylight2;
    public GameObject Rlight2;
    private int counter1 = 0;
    private int counter2 = 0;
    public int counter3 = 0;
    
    private bool traffic = false;
    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;
    public Camera cam;
    public AudioClip pass;
    
    // Start is called before the first frame update
    void Start()
    {
        car1.SetActive(true);
        car2.SetActive(true);
        car3.SetActive(false);
        car4.SetActive(false);

        txt.text = "Please wait until the light turns green";
       
        Glight1.SetActive(true);
        Ylight1.SetActive(false);
        Rlight1.SetActive(false);

      
        Glight2.SetActive(true);
        Ylight2.SetActive(false);
        Rlight2.SetActive(false);
        StartCoroutine(ChangeYellow());
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(head.position.x, feet.position.y, head.position.z);

        if (traffic)
        {
           
            if (counter3 == 0) {
                Vector3 pos = cam.transform.position;
                AudioSource.PlayClipAtPoint(pass, pos);
                counter3++;
            }
            
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
                if (selection.CompareTag(selectableTagL))
                {
                  txt.text = "Now please look right";
                  counter1++;
                  

                }
                else if (selection.CompareTag(selectableTagR))
                {
                    txt.text = "Now please look left";
                    counter2++;
                }
            }
            if (counter1 > 0 && counter2 > 0)
            {

                txt.text = "You may now cross the street";
               

            }
        }
        

    }
    
    IEnumerator ChangeYellow()
    {
        yield return new WaitForSeconds(20f);
        
        Glight1.SetActive(false);
        Ylight1.SetActive(true);
        Rlight1.SetActive(false);

       
        Glight2.SetActive(false);
        Ylight2.SetActive(true);
        Rlight2.SetActive(false);

        StartCoroutine(ChangeGreen());
    }

    IEnumerator ChangeGreen()
    {
        yield return new WaitForSeconds(5f);
        txt.text = "Please look both ways before crossing the street";
       
        Glight1.SetActive(false);
        Ylight1.SetActive(false);
        Rlight1.SetActive(true);

        
        Glight2.SetActive(false);
        Ylight2.SetActive(false);
        Rlight2.SetActive(true);
        car1.SetActive(false);
        car2.SetActive(false);
        car3.SetActive(true);
        car4.SetActive(true);

        traffic = true;
        StartCoroutine(ChangeRed());
    }
    IEnumerator ChangeRed() { 

        yield return new WaitForSeconds(20f);

        traffic = false;
        txt.text = "Please wait until the light turns green";
        counter1 = 0;
        counter2 = 0;
        counter3 = 0;
       
        Glight1.SetActive(true);
        Ylight1.SetActive(false);
        Rlight1.SetActive(false);

       
        Glight2.SetActive(true);
        Ylight2.SetActive(false);
        Rlight2.SetActive(false);
        car1.SetActive(true);
        car2.SetActive(true);
        car3.SetActive(false);
        car4.SetActive(false);

        StartCoroutine(ChangeYellow());
    }
    IEnumerator Countdown(int duration)
    {
        while (duration > 0)
        {
            duration--;
            yield return WaitForUnscaledSeconds(1f);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    IEnumerator WaitForUnscaledSeconds(float dur)
    {
        var cur = 0f;
        while (cur < dur)
        {
            yield return null;
            cur += Time.unscaledDeltaTime;
        }
    }
}

