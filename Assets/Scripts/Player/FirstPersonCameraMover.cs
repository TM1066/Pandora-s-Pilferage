using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonCameraMover : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 200f;

    public Transform playerBody;

    float xRotation = 0f;

    private Vector2 lookVector = Vector2.zero;
    public void OnLook(InputAction.CallbackContext context)
    {
        lookVector = context.ReadValue<Vector2>();
    }

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
{
    Debug.Log("Local rot: " + transform.localEulerAngles);
    Debug.Log("World rot: " + transform.eulerAngles);
    HandleCam();
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

        transform.localEulerAngles = new Vector3(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
