using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BodyCollision : MonoBehaviour
{
    public Transform head;
    public Transform feet;
    [SerializeField] private TextMeshProUGUI txt;
    public AudioClip[] rando;
    int counter = 0;
    private AudioClip shootClip;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        counter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        gameObject.transform.position = new Vector3(head.position.x, feet.position.y, head.position.z);


        if(head.position.x > -17.1)
        {
            if(counter == 1)
            {
                counter++;
                int index = Random.Range(0, rando.Length);
                shootClip = rando[index];
                Vector3 pos = cam.transform.position;
                AudioSource.PlayClipAtPoint(shootClip, pos);
                
            }
           
            txt.text = "Congratulations you have successfully crossed the street";
            
            StartCoroutine(QuitGame());

        }

    }
    IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(5f);
        Application.Quit();
    }



}
