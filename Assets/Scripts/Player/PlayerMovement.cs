using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody rig;

    [Header("Movement")]
    [SerializeField] float baseSpeed = 4f;
    // [SerializeField] float runMultiplier = 2f;

    [SerializeField] float airControlMultiplier = 0.5f;
    [SerializeField] float jumpForce = 6f;

    [Header("Grounding")]
    [SerializeField] float groundCheckRadius = 0.3f;
    [SerializeField] float groundCheckDistance = 0.4f;
    [SerializeField] LayerMask groundLayer;

    // [Header("Stairs")]
    // [SerializeField] float stepHeight = 0.35f;
    // [SerializeField] float stepForwardDistance = 0.4f;
    // [SerializeField] float stepUpForce = 5f;
    

    Vector2 moveVector = Vector2.zero;
    bool grounded = true;

    public void ChangeSpeed(float newBaseSpeed)
    {
        baseSpeed = newBaseSpeed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (grounded) Jump();
    }

    void Start()
    {
        //rig.freezeRotation = true;
        rig.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void Update()
    {
        grounded = IsGrounded();
        if (!GameVariables.playerCanMove) return;

        Debug.Log("Player Grounded: " + grounded);
    }
    // Handle physics stuff here for
    // cohesion across frame rates
    void FixedUpdate()
    {
        //grounded = IsGrounded();

        if (!GameVariables.playerCanMove) return;

        HandleMovement();
        //HandleExtraGravity();
        //HandleSteps();
    }

    void HandleMovement()
    {
        Transform cam = Camera.main.transform;

        Vector3 camForward = cam.forward;
        camForward.y = 0f;
        camForward.Normalize();

        Vector3 camRight = cam.right;
        camRight.y = 0f;
        camRight.Normalize();

        Vector3 inputDir = camForward * moveVector.y + camRight * moveVector.x;

        inputDir = inputDir.normalized;

        //float targetSpeed = baseSpeed * (Input.GetKey(KeyCode.LeftShift) ? runMultiplier : 1f);

        Vector3 targetVelocity = inputDir * baseSpeed;

        if (!GameVariables.cursesActive["Icy"])
        {
            rig.linearVelocity = new Vector3(
                targetVelocity.x,
                rig.linearVelocity.y,
                targetVelocity.z
            );
        }
        else
        {
            // Keep existing momentum, only add player input
            Vector3 currentVelocity = rig.linearVelocity;

            Vector3 addedVelocity = new Vector3(
                targetVelocity.x,
                0f,
                targetVelocity.z
            );

            rig.linearVelocity = new Vector3(
                currentVelocity.x + addedVelocity.x,
                currentVelocity.y,
                currentVelocity.z + addedVelocity.z
            );

            float maxSpeed = 10f;

            Vector3 horizontal = new Vector3(rig.linearVelocity.x, 0f, rig.linearVelocity.z);
            horizontal = Vector3.ClampMagnitude(horizontal, maxSpeed);

            rig.linearVelocity = new Vector3(horizontal.x, rig.linearVelocity.y, horizontal.z);
        }
    }


    void Jump()
    {
        rig.linearVelocity = new Vector3(rig.linearVelocity.x, 0f, rig.linearVelocity.z);
        rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        grounded = false;
    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Ground")) grounded = true;
    // }

    // void HandleExtraGravity()
    // {
    //     if (!grounded && rig.linearVelocity.y < 0)
    //     {
    //         rig.linearVelocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1f) * Time.fixedDeltaTime;
    //     }
    // }

    // void HandleSteps()
    // {
    //     if (!grounded) return;

    //     Vector3 lowerRayOrigin = transform.position + Vector3.up * 0.05f;
    //     Vector3 upperRayOrigin = transform.position + Vector3.up * stepHeight;

    //     Vector3 moveDir = new Vector3(rig.linearVelocity.x, 0, rig.linearVelocity.z).normalized;
    //     if (moveDir == Vector3.zero) return;

    //     // lower ray hits step
    //     if (Physics.Raycast(lowerRayOrigin, moveDir, out RaycastHit lowerHit, stepForwardDistance, groundLayer))
    //     {
    //         // upper ray does NOT hit = climbable step
    //         if (!Physics.Raycast(upperRayOrigin, moveDir, stepForwardDistance, groundLayer))
    //         {
    //             rig.AddForce(Vector3.up * stepUpForce, ForceMode.VelocityChange);
    //         }
    //     }
    // }

    bool IsGrounded()
    {
        Vector3 origin = transform.position + Vector3.up * 0.1f;
        // return Physics.SphereCast(
        //     origin,
        //     groundCheckRadius,
        //     Vector3.down,
        //     out _,
        //     groundCheckDistance,
        //     groundLayer
        // );
    
        return Physics.Raycast(origin, Vector3.down, 2f);
    }

    void OnDrawGizmos()
    {
        Vector3 origin = transform.position + Vector3.up * 0.1f;
        Debug.DrawRay(origin, Vector3.down * groundCheckDistance, Color.red);
    }
}
