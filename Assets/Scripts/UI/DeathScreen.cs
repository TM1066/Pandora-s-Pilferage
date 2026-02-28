using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public TextMeshProUGUI deathText;

    bool playerDead = false;


    public void Die(string cause, int waitTime = 3)
    {
        if (playerDead) return;
        playerDead = true;
        this.gameObject.SetActive(true);
        deathText.text = "Cause of Death: " + cause;

        //GameObject.FindAnyObjectByType<GameManager>().ResetRigs();

        StartCoroutine(WaitAndReturn(waitTime));
    }

    IEnumerator WaitAndReturn(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        //Application.Quit();
        
        SceneManager.LoadScene("Main Menu");
    }
}
