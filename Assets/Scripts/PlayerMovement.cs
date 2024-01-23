using UnityEditor.Tilemaps;
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
        // check if we are on the ground
        RaycastHit2D hit = Physics2D.Raycast(footPosition.position, Vector2.down, 0.2f, groundMask);
        if (hit.collider != null) {
            isGrounded = true;
        } else {
            isGrounded = false;
        }

        // if we are on the ground, we can jump
        if (Input.GetButtonDown("Jump") && isGrounded) {
            //body.AddForce(new Vector3(0f, jumpSpeed, 0f));
            body.AddForce(Vector3.up * jumpSpeed);
            Debug.Log("Jumping!");
        }

        // collect the user inputs
        float movementX = Input.GetAxis("Horizontal") * movementSpeed;

        // handle left/right movement
        Vector3 movement = new Vector3(movementX, 0f, 0f);
        transform.Translate(movement * Time.deltaTime);

        // handle which direction our character is facing
        if (movementX > 0f && !isFacingRight) {
            Flip();
        } else if (movementX < 0f && isFacingRight) {
            Flip();
        }
    }

    private void Flip() {
        isFacingRight = !isFacingRight;

        Vector3 theScale = sprite.transform.localScale;
        theScale.x *= -1;
        sprite.transform.localScale = theScale;
    }
}
