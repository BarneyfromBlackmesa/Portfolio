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
            // check
            _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

            // update the animator
            _animator.SetBool("isGrounded", _isGrounded);

            // if grounded, reset
            if (_isGrounded)
            {
                _animator.SetBool("isJumping", false);
            }
        }

        // Call this update once per frame to check for ground
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
