using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float jumpSpeed = 400f;

    [SerializeField] private Transform footPosition;
    [SerializeField] private bool isGrounded = false;

    [SerializeField] private GameObject sprite;
    [SerializeField] private bool isFacingRight = true;

    [SerializeField] private LayerMask groundMask;

    private Rigidbody2D body;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // collect the user inputs
        float movementX = Input.GetAxis("Horizontal");

        // check if we are on the ground
        RaycastHit2D hit = Physics2D.Raycast(footPosition.position, Vector2.down, 0.2f, groundMask);
        if (hit.collider != null) {
            isGrounded = true;
        } else {
            isGrounded = false;
        }
    }
}
