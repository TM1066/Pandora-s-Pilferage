using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DrunkBar : MonoBehaviour
{
    public Slider slider;
    // Update is called once per frame
    void Update()
    {
        slider.value = GameVariables.playerDrunkenness;

        if (GameVariables.playerDrunkenness <= 0) FindAnyObjectByType<DeathScreen>(FindObjectsInactive.Include).Die("Sobriety");
    }

    void OnEnable()
    {
        StartCoroutine(LowerOverTime());
        StartCoroutine(MakeSoundGoAllWeird());
    }

    IEnumerator MakeSoundGoAllWeird()
    {
        var source = FindAnyObjectByType<BGMManager>().bgmSource;
        var originalPitch = source.pitch;
        while (true)
        {
            var targetWeirdPitch = Random.Range(0.1f, 0.5f);

            var timeElapsed = 0f;
            float weirdDuration = 10f;

            while (timeElapsed < weirdDuration / 2)
            {
                source.pitch = Mathf.Lerp(originalPitch, targetWeirdPitch, timeElapsed / (weirdDuration / 2));
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            while (timeElapsed < weirdDuration)
            {
                source.pitch = Mathf.Lerp(targetWeirdPitch, originalPitch, timeElapsed / weirdDuration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
        }
    }

    IEnumerator LowerOverTime()
    {
        while (true)
        {
            GameVariables.playerDrunkenness -= 0.1f;
            yield return new WaitForSeconds(10);
        }
    }
}
