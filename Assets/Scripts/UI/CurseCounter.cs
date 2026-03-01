using TMPro;
using UnityEngine;

public class CurseCounter : MonoBehaviour
{
    public TextMeshProUGUI textMesh;

    // Update is called once per frame
    void Update()
    {
        int curseAmount = 0;
        foreach (bool curse in GameVariables.cursesActive.Values)
        {
            if (curse) curseAmount++;
        }

        textMesh.text = $"Curses Collected\n{curseAmount}/{GameVariables.cursesActive.Count}";
    }
}
