using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public class UI_InventoryButton : MonoBehaviour
    {

        bool isInventoryHidden = true;
        [SerializeField]
        UI_Inventory inventory;

        public void ToggleInventory()
        {
            isInventoryHidden = !isInventoryHidden;

            if (isInventoryHidden)
                inventory.Hide();
            else
                inventory.Show();
        }
    }
}
