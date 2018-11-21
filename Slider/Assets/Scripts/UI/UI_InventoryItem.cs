using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore { 
public class UI_InventoryItem : MonoBehaviour {

        Image img;

        private void Start()
        {
            img = GetComponent<Image>();

            Clean();
        }

        public void Clean()
        {
            img.color = Color.clear;
        }
    }
}
