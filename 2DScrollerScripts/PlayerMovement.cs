using UnityEngine;

namespace Scenes.scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float jumpForce = 10f;
        private Rigidbody2D _rb;
        private bool _isGrounded;

        public Transform groundCheck;  // Transform object placed at the player's feet in the Unity Editor
        public float groundCheckRadius = 0.2f;  // Radius of the ground detection circle
        public LayerMask groundLayer;  // Set the Ground layer in the Unity Editor

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            // Check if the player is grounded by performing an OverlapCircle check
            _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

            // Main movement
            float move = Input.GetAxis("Horizontal");
            _rb.velocity = new Vector2(move * moveSpeed, _rb.velocity.y);

            // Jumping
            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                _rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
            
        }

        // Visualize the ground check in the editor
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}