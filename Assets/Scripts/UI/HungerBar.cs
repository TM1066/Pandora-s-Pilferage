using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public Slider slider;

    // Update is called once per frame
    void Update()
    {
        slider.value = GameVariables.playerHunger;
    }

    void OnEnable()
    {
        StartCoroutine(LowerOverTime());
    }

    IEnumerator LowerOverTime()
    {
        while (true)
        {
            GameVariables.playerHunger -= 0.1f;
            yield return new WaitForSeconds(9);
        }
    }
}
