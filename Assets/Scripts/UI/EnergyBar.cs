using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;
    public Rigidbody playerRig;

    // Update is called once per frame
    void Update()
    {
        slider.value = GameVariables.playerEnergy;

        if (GameVariables.playerEnergy <= 0) FindAnyObjectByType<DeathScreen>(FindObjectsInactive.Include).Die("Tired.........zzzzzz");
    }

    void OnEnable()
    {
        StartCoroutine(LowerOverTime());
    }

    IEnumerator LowerOverTime()
    {
        while (true)
        {
            if (playerRig.linearVelocity.sqrMagnitude > 0.01f)
            {
                GameVariables.playerEnergy -= 0.1f;
            }
            else GameVariables.playerEnergy += 0.1f;
            
            yield return new WaitForSeconds(3 / GameVariables.playerEnergy);
        }
    }
}
