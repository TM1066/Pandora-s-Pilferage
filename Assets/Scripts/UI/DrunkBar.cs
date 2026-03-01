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
