using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonCameraMover : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 200f;
    public Transform playerBody;

    [Header("Drunk Cam")]
    [SerializeField] float swayStrength = 2f;
    [SerializeField] float swaySpeed = 1.5f;

    float xRotation = 0f;
    private Vector2 lookVector = Vector2.zero;

    float swayTime;

    public void OnLook(InputAction.CallbackContext context)
    {
        lookVector = context.ReadValue<Vector2>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (GameVariables.playerCanLook) HandleCam();
    }

    void HandleCam()
    {
        float horizontalRot = 0;
        float verticalRot = 0;

        if (Input.GetKey(KeyCode.A)) horizontalRot = -1; 
        if (Input.GetKey(KeyCode.D)) horizontalRot = 1; 
        if (Input.GetKey(KeyCode.W)) verticalRot = 1; 
        if (Input.GetKey(KeyCode.S)) verticalRot = -1; 

        float mouseX = horizontalRot * mouseSensitivity * GameVariables.mouseSensitivityMulti * Time.deltaTime;
        float mouseY = verticalRot * mouseSensitivity * GameVariables.mouseSensitivityMulti * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -65f, 65f);

        float drunkX = 0f;
        float drunkY = 0f;

        if (GameVariables.cursesActive["Drunk"])
        {
            var variableSwayStrength = swayStrength * GameVariables.playerDrunkenness;

            swayTime += Time.deltaTime * swaySpeed;

            drunkX = (Mathf.PerlinNoise(swayTime, 0f) - 0.5f) * variableSwayStrength;
            drunkY = (Mathf.PerlinNoise(0f, swayTime) - 0.5f) * variableSwayStrength;
        }

        transform.localEulerAngles = new Vector3(
            xRotation + drunkY,
            0f,
            drunkX
        );

        playerBody.Rotate(Vector3.up * mouseX);
    }
}