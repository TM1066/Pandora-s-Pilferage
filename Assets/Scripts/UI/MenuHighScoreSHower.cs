using TMPro;
using UnityEngine;

public class MenuHighScoreSHower : MonoBehaviour
{

    public TextMeshProUGUI highScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highScoreText.text = $"Current HighScore: {GameVariables.highScore}";   
    }
}
