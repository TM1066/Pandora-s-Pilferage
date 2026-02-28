using UnityEngine;
using System.Collections;

public class RotateOverTime : MonoBehaviour
{
    [Header("Time to make full rotation in seconds")]
    [SerializeField] float spinTime = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Spin());
    }
    void OnEnable()
    {
        StartCoroutine(Spin());
    }

    IEnumerator Spin()
    {
        while (true)
        {
            float startY = transform.eulerAngles.y;
            float endY = startY + 180f;

            // Clean target rotation
            Quaternion startRot = Quaternion.Euler(0, startY, 0);
            Quaternion endRot = Quaternion.Euler(0, endY, 0);

            // Lerp over time - unscaled because it's in UI visible when the game is paused
            float t = 0;
            while (t < 1f)
            {
                t += Time.unscaledDeltaTime / (spinTime / 2);
                transform.rotation = Quaternion.Lerp(startRot, endRot, t);
                yield return null;
            }

            // lock final rotation (helps precision)
            transform.rotation = endRot;
        }
    }
}
