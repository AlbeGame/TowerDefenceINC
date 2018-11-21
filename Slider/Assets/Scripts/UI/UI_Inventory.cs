using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace GameCore { 
public class UI_Inventory : MonoBehaviour {

        List<UI_InventoryItem> items = new List<UI_InventoryItem>();
        RectTransform rTransf;

        public float HideOffSet = 300;

        private void Start()
        {
            rTransf = GetComponent<RectTransform>();

            items = GetComponentsInChildren<UI_InventoryItem>().ToList();

            Clean();
            Hide();
        }

        public void Clean()
        {
            foreach (UI_InventoryItem item in items)
            {
                item.Clean();
            }
        }

        public void Hide()
        {
            rTransf.DOAnchorPosY(-HideOffSet, 0.5f);
        }

        public void Show()
        {
            rTransf.DOAnchorPosY(0, 0.5f);
        }
    }
}
