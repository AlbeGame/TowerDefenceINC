using UnityEngine;

namespace GameCore {
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player_MovementCtrl : MonoBehaviour
    {
        Rigidbody2D rigidB;
        Player_Manager myMng;

        float jumpForce { get { return myMng.Data.JumpForce; }}
        float slideForce { get { return myMng.Data.SlideForce; }}

        private void FixedUpdate()
        {
            UpdateAirborneStatus();
        }

        public void Init(Player_Manager _mng)
        {
            rigidB = GetComponent<Rigidbody2D>();

            myMng = _mng;
        }

        #region Left-Right Movement
        public void MoveRight()
        {
            rigidB.AddForce(Vector2.right * slideForce, ForceMode2D.Force);
        }

        public void MoveLeft()
        {
            rigidB.AddForce(-Vector2.right * slideForce, ForceMode2D.Force);
        }
        #endregion
        #region Jump
        float yPosValue;
        bool isAirborne;
        void UpdateAirborneStatus()
        {
            if (yPosValue != transform.position.y)
                isAirborne = true;
            else
                isAirborne = false;

            yPosValue = transform.position.y;
        }

        public void Jump()
        {
            if(!isAirborne)
                rigidB.AddForce(Vector2.up * jumpForce ,ForceMode2D.Impulse);
        }
        #endregion
    }
}
