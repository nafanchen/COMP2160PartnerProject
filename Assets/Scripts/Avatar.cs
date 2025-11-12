using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Avatar : MonoBehaviour
{
    private float moveSpeed = 7f;
    private float jumpForce = 5.5f;
    public Rigidbody RB;

    public PlayerInput controls;
    private bool isGrounded;

    [SerializeField] private LayerMask groundLayer;

    private float coyoteTime = 0.1f;
    private float jumpBufferTime = 0.1f;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;

    private Vector3 lastJumpPosition;
    private List<Vector3> positionHistory = new();
    private float historyDuration = 10f;

    private List<ContactPoint> contactPoints = new();

    [SerializeField] private TimerController timerController;
    [SerializeField] private LevelSelector levelSelector;
    [SerializeField] private ScoreManager scoreManager;

    [SerializeField] private float boostSpeed = 10f;
    [SerializeField] private float boostTime = 0.1f;
    [SerializeField] private float decelerationTime = 0.1f;
    private float boostTimer;
    private float decelerationTimer;
    private Vector3 boostDirection;
    private bool onPad = false;
    private bool levelCompleted = false;
    private bool isBoosted = false;

    private void Awake()
    {
        controls = new PlayerInput();
    }

    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        controls.GameWorld.Enable();
        controls.GameMovement.Enable();
    }

    void OnDisable()
    {
        controls.GameWorld.Disable();
        controls.GameMovement.Disable();
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        CheckIfGrounded();

        if (!isGrounded)
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        if (jumpBufferCounter > 0)
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        positionHistory.Add(transform.position);
        if (positionHistory.Count > historyDuration / Time.deltaTime)
        {
            positionHistory.RemoveAt(0);
        }
    }

    private void HandleMovement()
    {
        Vector2 moveInput = controls.GameMovement.Movement.ReadValue<Vector2>();
        Vector3 move = (transform.right * moveInput.x + transform.forward * moveInput.y).normalized * moveSpeed;

        if (isBoosted)
        {
            if (boostTimer > 0)
            {
                boostTimer -= Time.deltaTime;
                move += boostDirection * (boostSpeed / boostTime) * Time.deltaTime;
            }
            else
            {
                move += boostDirection * boostSpeed;
            }
        }
        else if (decelerationTimer > 0)
        {
            decelerationTimer -= Time.deltaTime;
            float decelerationFactor = decelerationTimer / decelerationTime;
            move += boostDirection * boostSpeed * decelerationFactor;
        }

        RB.velocity = new Vector3(move.x, RB.velocity.y, move.z);
    }

    private void HandleJump()
    {
        if (controls.GameMovement.Jump.triggered)
        {
            jumpBufferCounter = jumpBufferTime;
            lastJumpPosition = transform.position;
        }

        if (jumpBufferCounter > 0 && (isGrounded || coyoteTimeCounter > 0))
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            RB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            coyoteTimeCounter = 0;
        }
    }

    private void CheckIfGrounded()
    {
        Vector3 spherePosition = transform.position + Vector3.down * 0.99f;
        float sphereRadius = 0.5f;

        bool wasGrounded = isGrounded;
        isGrounded = Physics.CheckSphere(spherePosition, sphereRadius, groundLayer);

        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
            jumpBufferCounter = 0;

            if (isBoosted && !wasGrounded && !onPad)
            {
                isBoosted = false;
                decelerationTimer = decelerationTime;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        contactPoints.Clear();
        contactPoints.AddRange(collision.contacts);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (ContactPoint contact in contactPoints)
        {
            Gizmos.DrawWireSphere(contact.point, 0.2f);
            Gizmos.DrawLine(contact.point, contact.point + contact.normal);
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(lastJumpPosition, 0.3f);

        Gizmos.color = Color.green;
        for (int i = 0; i < positionHistory.Count - 1; i++)
        {
            Gizmos.DrawLine(positionHistory[i], positionHistory[i + 1]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Death"))
        {
            timerController.timerRunning = false;
            controls.GameMovement.Disable();
            scoreManager.UpdateLastTime(levelSelector.currentLevel, 0f);
            levelSelector.ShowMenuUI();
        }
        if (other.CompareTag("Jump"))
        {
            onPad = true;
            RB.velocity = new Vector3(RB.velocity.x, jumpForce * 2, RB.velocity.z);
            isGrounded = false;
        }
        if (other.CompareTag("Speed"))
        {
            onPad = true;
            isBoosted = true;
            boostTimer = boostTime;
            boostDirection = other.transform.forward;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Goal") && !levelCompleted)
        {
            if (IsAvatarBaseFullyWithinGoal(other))
            {
                levelCompleted = true;
                timerController.timerRunning = false;
                controls.GameMovement.Disable();
                scoreManager.UpdateLastTime(levelSelector.currentLevel, timerController.levelTime);
                levelSelector.ShowMenuUI();
            }
        }
    }

    private bool IsAvatarBaseFullyWithinGoal(Collider goalCollider)
    {
        Bounds goalBounds = goalCollider.bounds;
        Collider avatarCollider = GetComponent<Collider>();
        Bounds avatarBaseBounds = new Bounds(
            new Vector3(avatarCollider.bounds.center.x, goalBounds.center.y, avatarCollider.bounds.center.z),
            new Vector3(avatarCollider.bounds.size.x, 0.1f, avatarCollider.bounds.size.z)
        );
        return goalBounds.Contains(avatarBaseBounds.min) && goalBounds.Contains(avatarBaseBounds.max);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Jump"))
        {
            onPad = false;
        }
        if (other.CompareTag("Speed"))
        {
            onPad = false;
        }
    }
}