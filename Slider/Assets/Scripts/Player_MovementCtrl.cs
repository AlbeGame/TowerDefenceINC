using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace GameCore {
    public class Player_MovementCtrl : MonoBehaviour
    {
        Rigidbody2D rigidB;
        public float JumpForce = 5;
        public float SlideForce = 5;


        private void Start()
        {
            rigidB = GetComponent<Rigidbody2D>();

            GameManager.I.UI_Ctrl.AddListenerToBtn(() => MoveLeft(), UI_CustomButton.ButtonType.Left);
            GameManager.I.UI_Ctrl.AddListenerToBtn(() => MoveRight(), UI_CustomButton.ButtonType.Right);
            GameManager.I.UI_Ctrl.AddListenerToBtn(() => Jump(), UI_CustomButton.ButtonType.Up);
        }

        private void FixedUpdate()
        {
            UpdateAirborneStatus();
        }

        //public void Move(float _xAxisFactor)
        //{
        //    transform.position = new Vector3(transform.position.x + _xAxisFactor, transform.position.y, transform.position.z);
        //}

        public void MoveRight()
        {
            rigidB.AddForce(Vector2.right * SlideForce, ForceMode2D.Force);
        }

        public void MoveLeft()
        {
            rigidB.AddForce(-Vector2.right * SlideForce, ForceMode2D.Force);
        }

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
                rigidB.AddForce(Vector2.up * JumpForce ,ForceMode2D.Impulse);
        }
    }
}
