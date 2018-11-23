using UnityEngine;

namespace GameCore { 
public class ProjectileBehaviour : MonoBehaviour {

        public float Lifetime = 1;

        private void Start()
        {
            Destroy(gameObject, Lifetime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Player_Manager player = collision.gameObject.GetComponent<Player_Manager>();
            if (player == null)
            {
                Destroy(gameObject);
            }
        }
    }
}
