using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerMovementSpeed = 35.0f;
    [SerializeField][Range(0.0f, 0.3f)] private float groundCheckDistance = 3.0f;

    private Collider playerCollider = null;

    private float horizontalInput = 0.0f;
    private float verticalInput = 0.0f;

    Vector3 direction = Vector3.zero;

    [SerializeField] private bool isGrounded = false;
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
            }
            return isGrounded;
        }
        private set
        {
            isGrounded = value;
        }
    }

    private void Awake() {
        playerCollider = GetComponent<Collider>();
    }


    private void Update()
    {
        SetInputs();
        direction = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (IsGrounded && IsDirectionSet())
        {
            SetNewPosition();
        }
        else if (IsGrounded)
        {
            GetComponent<Rigidbody>().Sleep();
        }
    }

    private void SetInputs()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private bool IsDirectionSet()
    {
        return !direction.Equals(Vector3.zero);
    }

    private void SetNewPosition()
    {
        Vector3 movement = transform.forward * direction.z + transform.right * direction.x;
        movement = movement.normalized;

        var newPosition = movement * playerMovementSpeed * Time.deltaTime;
        transform.position += newPosition;
    }

    private void OnCollisionExit(Collision other) {
        if (other.gameObject.CompareTag("Ground")){
            isGrounded = false;
        }
    }

}
