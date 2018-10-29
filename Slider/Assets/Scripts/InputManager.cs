using UnityEngine;

namespace GameCore
{
    public class InputManager : MonoBehaviour
    {

        [SerializeField]
        Rigidbody2D rigidFather;
        CircleCollider2D myCollider;
        public float ForceMultiplier;

        // Use this for initialization
        void Start()
        {
            //rigidFather = GetComponentInParent<Rigidbody2D>();
            myCollider = GetComponent<CircleCollider2D>();

            Vector3 cameraPos = Camera.main.transform.position;
            transform.position = new Vector3(transform.position.x, transform.position.y, cameraPos.z + 1);
        }

        private void OnMouseDrag()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = rigidFather.transform.position.z;
            Vector2 dir = mousePos - rigidFather.transform.position;

            rigidFather.AddForce(dir.normalized * Mathf.Floor(1 / dir.magnitude));

            Debug.DrawLine(rigidFather.transform.position, dir.normalized);
        }
    }
}
