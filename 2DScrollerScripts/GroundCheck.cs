using UnityEngine;

namespace Scenes.scripts
{
    public class CharacterController : MonoBehaviour
    {
        private Animator animator;
        private Rigidbody2D rb;
        private bool _isGrounded;
        private Collider2D _collider;

        [Header("Ground Check")] public float speed = 5f;
        public LayerMask groundLayer;
        public Transform groundCheck;
        public float groundCheckRadius = 0.2f;

        [Header("Movement Variables")] public float jumpForce = 10f;
        private bool _active = true;

        void Start()
        {
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();
        }

        void Update()
        {
            GroundCheck();
            Movement();
            if (!_active)
            {
                return;
            }

            Jump();
        }

        void GroundCheck()
        {
            // Check if the character is on the ground
            _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

            // Update the Animator with the ground state
            animator.SetBool("isGrounded", _isGrounded);

            // If grounded, reset isJumping to false
            if (_isGrounded)
            {
                animator.SetBool("isJumping", false);
            }
        }

        void Movement()
        {
            // Get horizontal input and apply movement
            float horizontal = Input.GetAxis("Horizontal");
            Vector2 direction = new Vector2(horizontal * speed, rb.velocity.y);
            rb.velocity = direction;

            // Check if the character is running
            bool isRunning = Mathf.Abs(horizontal) > 0;
            animator.SetBool("isRunning", isRunning);

            // Ensure the character stays grounded when running
            animator.SetBool("isGrounded", _isGrounded);
        }

        void Jump()
        {
            // Jump if the character is grounded
            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                animator.SetBool("isJumping", true); // Set isJumping to true when jump is triggered
            }

            // Check if character is on the ground to reset jump animation
            if (_isGrounded)
            {
                animator.SetBool("isJumping", false); // Reset jumping when grounded
            }
        }

        private void MiniJump()
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce / 2);
        }
    }
}

