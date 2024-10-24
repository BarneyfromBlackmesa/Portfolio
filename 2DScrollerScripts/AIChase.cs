using UnityEngine;

namespace Scenes.scripts
{
    public class AIChase : MonoBehaviour
    {

        public float chaseSpeed;
        public GameObject target;
        private float _distance;
        private bool _isGrounded;

        private Collider2D _collider;
        private Animator _animator;
        private Rigidbody2D _rb;

        public LayerMask groundLayer;
        public Transform groundCheck;
        public float groundCheckRadius = 0.2f;



        void enemyGroundCheck()
        {
            // Check if the character is on the ground
            _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

            // Update the Animator with the ground state
            _animator.SetBool("isGrounded", _isGrounded);

            // If grounded, reset isJumping to false
            if (_isGrounded)
            {
                _animator.SetBool("isJumping", false);
            }
        }

        // Update is called once per frame
        void Update()
        {
            enemyGroundCheck();
            _distance = Vector2.Distance(transform.position, target.transform.position);
            Vector2 direction = (target.transform.position - transform.position).normalized;
            transform.position =
                Vector2.MoveTowards(transform.position, target.transform.position, chaseSpeed * Time.deltaTime);
        }
    }
}
