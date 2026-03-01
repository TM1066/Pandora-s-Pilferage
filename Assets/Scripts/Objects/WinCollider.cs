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

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("EXIT HIT");
        if (collision.gameObject.CompareTag("Player"))
        {
            FindAnyObjectByType<GameManager>().WinGame();
            winScreen.SetActive(true);
        }
    }
}
