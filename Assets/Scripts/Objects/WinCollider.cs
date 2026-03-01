using UnityEngine;

public class WinCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindAnyObjectByType<GameManager>().WinGame();
        }
    }
}
