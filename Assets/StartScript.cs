using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartScript : MonoBehaviour

{
    public Camera cam;
    public GameObject Glight;
    public GameObject Ylight;
    public GameObject Rlight;
    public AudioClip red;
    public AudioClip yellow;
    public AudioClip green;
    // Start is called before the first frame update
    void Start()
    {
        Glight.SetActive(false);
        Ylight.SetActive(false);
        Rlight.SetActive(false);
        StartCoroutine(PlayRed());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayRed()
    {
        yield return new WaitForSeconds(2f);
        Rlight.SetActive (true);
        Vector3 pos = cam.transform.position;
        AudioSource.PlayClipAtPoint(red, pos);

        yield return new WaitForSeconds(red.length);

        StartCoroutine(PlayGreen());
    }
    IEnumerator PlayGreen()
    {
        yield return new WaitForSeconds(2f);
        Rlight.SetActive (false);
        Glight.SetActive(true);
        Ylight.SetActive(false);
        Vector3 pos = cam.transform.position;
        AudioSource.PlayClipAtPoint(green, pos);
        yield return new WaitForSeconds(green.length);
        StartCoroutine(PlayYellow());
    }


    IEnumerator PlayYellow()
    {
        yield return new WaitForSeconds(2f);
        Rlight.SetActive (false);
        Ylight.SetActive(true);
        Glight .SetActive(false);
        Vector3 pos = cam.transform.position;
        AudioSource.PlayClipAtPoint(yellow, pos);
        yield return new WaitForSeconds(yellow.length);
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("VR");

    }
}
