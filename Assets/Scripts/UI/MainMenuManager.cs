using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    private void Start() {
        //ResetVariables
        GameVariables.cursesActive = new()
        {
            {"Hunger", false},
            {"Tired", false},
            {"Bouncy",false},
            {"Icy",false},
            {"Rage", false},
            {"Pitbull",false},
            {"Competition",false}
        };

        GameVariables.playerHunger = 1;
        GameVariables.playerEnergy = 1;
        GameVariables.playerScore = 0;
    }


    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
