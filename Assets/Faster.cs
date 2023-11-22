using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Faster : MonoBehaviour
{
    public Transform head;
    public Transform feet;
    public AudioClip faster;
    public Camera cam;
    [SerializeField] private TextMeshProUGUI txt;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        if (head.position.x > -17.6 && head.position.x < -17.11)
        {
            Vector3 pos = cam.transform.position;
            AudioSource.PlayClipAtPoint(faster, pos);

            Time.timeScale = 0f;
            StartCoroutine(Countdown(5));
            txt.text = "Please cross the street before the light turns red\n \n Restarting Level";

        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
