using UnityEngine;

namespace Scenes.scripts
{
    public class InstantDeath : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider != null)
            {
                var player = collision.collider.GetComponent<Player>();
                if (player != null)
                {
                    player.Die();
                }
            }
        }
    }
}