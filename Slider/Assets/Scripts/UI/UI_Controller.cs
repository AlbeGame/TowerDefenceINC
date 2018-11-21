using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

namespace GameCore {
    public class UI_Controller : MonoBehaviour
    {

        [SerializeField]
        UI_CustomButton Btn_Right;
        [SerializeField]
        UI_CustomButton Btn_Left;

        public void AddListenerToBtn_Right(UI_CustomButton.CustomButtonDelegate _callBack)
        {
            Btn_Right.OnBtnDown = _callBack;
        }

        public void AddListenerToBtn_Left(UI_CustomButton.CustomButtonDelegate _callBack)
        {
            Btn_Left.OnBtnDown = _callBack;
        }
    }
}
