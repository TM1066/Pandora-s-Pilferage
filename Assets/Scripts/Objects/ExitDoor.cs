using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    // should have a collider stopping player
    public GameObject gateBars;
    public GameObject winGameCollider;

    // Update is called once per frame
    void Update()
    {
        int cursesObtained = 0;
        foreach (var value in GameVariables.cursesActive.Values)
        {
            if (value) cursesObtained++;
        }
        if (cursesObtained >= 5)
        {
            gateBars.SetActive(false);
            winGameCollider.SetActive(true);
        }
    }
}
