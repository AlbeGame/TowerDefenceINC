using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace GameCore {
    public class UI_Controller : MonoBehaviour
    {
        List<UI_CustomButton> buttons = new List<UI_CustomButton>();

        private void Start()
        {
            buttons = GetComponentsInChildren<UI_CustomButton>().ToList();
        }

        public void AddListenerToBtn(UI_CustomButton.CustomButtonDelegate _callBack, UI_CustomButton.ButtonType _type)
        {
            foreach (UI_CustomButton btn in buttons)
            {
                if (btn.BtnType == _type)
                    btn.OnBtnDown = _callBack;
            }
        }
    }
}
