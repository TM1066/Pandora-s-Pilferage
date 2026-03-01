using UnityEngine;

public class WinCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindAnyObjectByType<GameManager>().WinGame();
        }
    }
}
