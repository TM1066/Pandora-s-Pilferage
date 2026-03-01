using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void OnEnable()
    {
        scoreText.text = $"Score: {GameVariables.playerScore}\nHigh Score: {GameVariables.highScore}";
    }

    IEnumerator WaitAndLeave()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Main Menu");
    }
}
