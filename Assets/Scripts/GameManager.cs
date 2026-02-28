using UnityEngine;

public class GameManager : MonoBehaviour
{

    public PhysicsMaterial bouncyMat;
    bool bouncied = false;

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
            foreach (var rig in GameObject.FindObjectsByType<Rigidbody>(FindObjectsInactive.Include, FindObjectsSortMode.None))
            {
                if (rig.isKinematic) rig.isKinematic = false;

                rig.AddForce(new Vector3(Random.Range(-5,5),Random.Range(-5,5),Random.Range(-5,5)) * 5);
            }

            foreach (var col in GameObject.FindObjectsByType<Collider>(FindObjectsInactive.Include, FindObjectsSortMode.None))
            {
                col.material = bouncyMat;
            }
        }
    }
}
