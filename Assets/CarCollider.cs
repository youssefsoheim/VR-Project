using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarCollider : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txt;
    public AudioClip[] rando;
    
    private AudioClip shootClip;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        int index = Random.Range(0, rando.Length);
        shootClip = rando[index];
        Vector3 pos = cam.transform.position;

        AudioSource.PlayClipAtPoint(shootClip, pos);
        
        Time.timeScale = 0f;
        StartCoroutine(Countdown(5));
        txt.text = "You collided with a car \n Please look both ways before crossing the street\n \n Restarting Level";

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
