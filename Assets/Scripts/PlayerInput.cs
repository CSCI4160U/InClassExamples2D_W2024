using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float runSpeed = 10f;

    private CharacterController2D controller;
    public Animator animator;

    private float horizontalMove = 0f;
    private bool jump = false;

    private void Start() {
        controller = GetComponent<CharacterController2D>();
    }

    private void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(controller.speed));

        if (Input.GetButtonDown("Jump")) {
            jump = true;

            animator.SetTrigger("Jump");
        }
    }

    private void FixedUpdate() {
        // movement
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        jump = false;
    }
}
