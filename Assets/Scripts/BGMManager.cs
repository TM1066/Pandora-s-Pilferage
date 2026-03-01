using System.Collections;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioSource bgmSource;
    public float buildUp = 5;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartUp());
    }

    IEnumerator StartUp()
    {
        float originalVol = bgmSource.volume;
        bgmSource.volume = 0;
        float timeElapsed = 0;

        while (timeElapsed < buildUp)
        {
            bgmSource.volume = Mathf.Lerp(0, originalVol, timeElapsed / buildUp);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}
