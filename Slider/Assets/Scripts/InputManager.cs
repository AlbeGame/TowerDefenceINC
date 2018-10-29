using UnityEngine;

namespace GameCore
{
    public class InputManager : MonoBehaviour
    {
        Rigidbody2D rigidB;
        public float ForceMultiplier = 1;

        // Use this for initialization
        void Start()
        {
            Vector3 cameraPos = Camera.main.transform.position;
            rigidB = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
#if UNITY_ADROID
            if (Input.touchCount > 0)
                ApplyMovement(Input.touches[0].position);
#else
            if (Input.GetMouseButton(0))
                ApplyMovement(Input.mousePosition);
#endif
        }

        void ApplyMovement(Vector3 _inputPos)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(_inputPos);
            mousePos.z = transform.position.z;
            Vector2 dir = mousePos - transform.position;

            rigidB.AddForce(dir.normalized * ForceMultiplier);
        }
    }
}
