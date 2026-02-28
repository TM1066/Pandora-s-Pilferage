using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;

    // Update is called once per frame
    void Update()
    {
        slider.value = GameVariables.playerEnergy;
    }

    void OnEnable()
    {
        StartCoroutine(LowerOverTime());
    }

    IEnumerator LowerOverTime()
    {
        while (true)
        {
            GameVariables.playerEnergy -= 0.1f;
            yield return new WaitForSeconds(3);
        }
    }
}
