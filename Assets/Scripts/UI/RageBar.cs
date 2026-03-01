using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class RageBar : MonoBehaviour
{
    public Slider slider;

    bool rageActive = false;
    public GameObject rageScreen;
    public TextMeshProUGUI rageText;

    // Update is called once per frame
    void Update()
    {

        slider.value = GameVariables.playerRage;

        if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.V)) rageActive = !rageActive;

        if (rageActive)
        {
            rageText.enabled = false;
            rageScreen.SetActive(true);
        }
        else 
        {
            if (GameVariables.playerRage >= 1)
            {
                rageText.enabled = true;
            }
            rageScreen.SetActive(false);
        }
    }

    void OnEnable()
    {
        StartCoroutine(LowerHigherOverTime());
    }

    IEnumerator LowerHigherOverTime()
    {
        while (true)
        {
            if (rageActive)
            {
                GameVariables.playerRage -= 0.1f;
                if (GameVariables.playerRage <= 0)
                {
                    FindAnyObjectByType<DeathScreen>(FindObjectsInactive.Include).Die("Roid Rage");
                }
                yield return new WaitForSeconds(1 / GameVariables.playerRage);
            }
            else
            {
                GameVariables.playerRage = Mathf.Clamp01(GameVariables.playerRage + 0.1f);
                yield return new WaitForSeconds(5 / GameVariables.playerRage);
            }
        }
    }
}
