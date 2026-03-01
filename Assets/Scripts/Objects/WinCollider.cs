using UnityEngine;

public class WinCollider : MonoBehaviour
{
    public GameObject winScreen;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindAnyObjectByType<GameManager>().WinGame();
            winScreen.SetActive(true);
        }
    }
}
