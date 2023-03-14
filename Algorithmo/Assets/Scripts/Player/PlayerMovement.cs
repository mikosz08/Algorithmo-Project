using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerMovementSpeed = 35.0f;
    [SerializeField][Range(0.0f, 0.3f)] private float groundCheckDistance = 3.0f;

    private Collider playerCollider = null;
    private Rigidbody playerRigidbody = null;

    private float horizontalInput = 0.0f;
    private float verticalInput = 0.0f;

    private Vector3 direction = Vector3.zero;

    [SerializeField] public bool isDirectionSet { get; private set; } = false;
    [SerializeField] public bool isGrounded = false;
    public bool IsGrounded
    {
        get
        {
            var bottomY = playerCollider.bounds.min.y + 0.1f;
            var bottom = transform.position;
            bottom.y = bottomY;
            if (Physics.Raycast(bottom, Vector3.down, out RaycastHit hitInfo, groundCheckDistance))
            {
                isGrounded = true;
                Debug.DrawRay(bottom, Vector3.down * hitInfo.distance, Color.green);
            }
            else
            {
                Debug.DrawRay(bottom, Vector3.down * groundCheckDistance, Color.blue);
                isGrounded = false;
            }
            return isGrounded;
        }
        private set
        {
            isGrounded = value;
        }
    }

    private void Awake()
    {
        playerCollider = GetComponent<Collider>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        SetInputs();
        if (IsGrounded && isDirectionSet)
        {
            Move();
        }
    }

    private void SetInputs()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        direction = new Vector3(horizontalInput, 0, verticalInput).normalized;
        isDirectionSet = !direction.Equals(Vector3.zero);
    }

    private void Move()
    {
        Vector3 movement = (transform.forward * verticalInput) + (transform.right * horizontalInput);
        playerRigidbody.velocity = movement * playerMovementSpeed;

        if (movement.magnitude == 0f)
        {
            playerRigidbody.velocity = Vector3.zero;
        }
    }

}
