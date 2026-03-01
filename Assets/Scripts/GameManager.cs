using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public PhysicsMaterial bouncyMat;
    bool bouncied = false;

    //List<bool> rigKinematics = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameVariables.cursesActive["Bouncy"] && !bouncied)
        {
            bouncied = true;
            foreach (var rig in GameObject.FindObjectsByType<Rigidbody>(FindObjectsInactive.Include, FindObjectsSortMode.InstanceID))
            {
                if (rig.isKinematic)
                {
                    //rigKinematics.Add(true);
                    rig.isKinematic = false;
                }
                //else rigKinematics.Add(false);

                rig.AddForce(new Vector3(Random.Range(-5,5),Random.Range(-5,5),Random.Range(-5,5)) * 5);
            }

            foreach (var col in GameObject.FindObjectsByType<Collider>(FindObjectsInactive.Include, FindObjectsSortMode.None))
            {
                col.material = bouncyMat;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
        }

    }

    public void WinGame()
    {
        GameVariables.highScore = System.Math.Max(GameVariables.highScore, GameVariables.playerScore);
        FindAnyObjectByType<DeathScreen>().Die("Winning!!");
    }

    // public void ResetRigs()
    // {
    //     var rigs = GameObject.FindObjectsByType<Rigidbody>(FindObjectsInactive.Include, FindObjectsSortMode.InstanceID);
    //     for (int i = 0; i < rigs.Length; i++)
    //     {
    //         rigs[i].isKinematic = rigKinematics[i];
    //     }
    // }
}
