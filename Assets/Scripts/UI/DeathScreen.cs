using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public TextMeshProUGUI deathText;

    bool playerDead = false;


    public void Die(string cause)
    {
        if (playerDead) return;
        playerDead = true;
        this.gameObject.SetActive(true);
        deathText.text = "Cause of Death: " + cause;
    }

    IEnumerator WaitAndReturn()
    {
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => Input.anyKeyDown);
        SceneManager.LoadScene("Main Menu");
    }
}
