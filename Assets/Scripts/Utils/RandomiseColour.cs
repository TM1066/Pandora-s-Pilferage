using UnityEngine;

public class RandomiseColour : MonoBehaviour
{
    public Renderer matRenderer;

    public float intensity = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        matRenderer.material.color = new Color(Random.Range(0f,1f), Random.Range(0f,1f),Random.Range(0f,1f), 1) * intensity;
    }
}
