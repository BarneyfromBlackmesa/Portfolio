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
            
            _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

            
            animator.SetBool("isGrounded", _isGrounded);

            
            if (_isGrounded)
            {
                animator.SetBool("isJumping", false);
            }
        }

        void Movement()
        {
            
            float horizontal = Input.GetAxis("Horizontal");
            Vector2 direction = new Vector2(horizontal * speed, rb.velocity.y);
            rb.velocity = direction;

            
            bool isRunning = Mathf.Abs(horizontal) > 0;
            animator.SetBool("isRunning", isRunning);

            
            animator.SetBool("isGrounded", _isGrounded);
        }

        void Jump()
        {
            
            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                animator.SetBool("isJumping", true); 
            }

            
            if (_isGrounded)
            {
                animator.SetBool("isJumping", false); 
            }
        }

        private void MiniJump()
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce / 2);
        }
    }
}

