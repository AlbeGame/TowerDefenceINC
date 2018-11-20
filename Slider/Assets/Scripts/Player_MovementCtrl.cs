using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace GameCore {
    public class Player_MovementCtrl : MonoBehaviour
    {
        private void Start()
        {
            GameManager.I.UI_Ctrl.AddListenerToBtn_Left(() => MoveLeft());
            GameManager.I.UI_Ctrl.AddListenerToBtn_Right(() => MoveRight());
        }

        public void Move(float _xAxisFactor)
        {
            transform.position = new Vector3(transform.position.x + _xAxisFactor, transform.position.y, transform.position.z);
        }

        public void MoveRight()
        {
            Move(0.01f);
        }

        public void MoveLeft()
        {
            Move(-0.01f);
        }
    }
}
