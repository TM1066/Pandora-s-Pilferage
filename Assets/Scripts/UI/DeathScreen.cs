using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public TextMeshProUGUI deathText;


    public void Die(string cause)
    {
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
