using UnityEngine;

public class ActiveIfCurse : MonoBehaviour
{
    public string curseName;

    // Update is called once per frame
    void Update()
    {
        if (GameVariables.cursesActive[curseName]) this.gameObject.SetActive(true);
        else this.gameObject.SetActive(false);
    }
}
