using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore { 
public class UI_InventoryItem : MonoBehaviour {

        [SerializeField]
        Sprite defaultIcon;

        Image img;
        Data_Item data;

        private void Start()
        {
            img = GetComponent<Image>();

            Clean();
        }

        public void Clean()
        {
            img.sprite = defaultIcon;
        }

        public void Item_Init(Data_Item _data)
        {
            data = _data;

            img.sprite = data.Icon;
        }
    }
}
