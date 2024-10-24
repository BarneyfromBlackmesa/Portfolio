using UnityEngine;
using System.Collections.Generic;

namespace Scenes.scripts
{
    [System.Serializable]
    public class Item
    {
        public string itemName;
        public int itemID = 1;
        [SerializeField] private bool isDefault;
        [SerializeField] private float damageOnHit;
        [SerializeField] public bool inInventory;
        [SerializeField] private Sprite icon;

        public bool IsDefault => isDefault;
        public float DamageOnHit => damageOnHit;
        public bool InInventory => inInventory;
        public Sprite Icon => icon;
        public List<Item> inventory = new List<Item>();


        public Item GetItem(string searchItemName, int searchItemID)
        {
            foreach (Item i in inventory)
            {
                if (i.itemName == searchItemName && i.itemID == searchItemID)
                {
                    return i;
                }
            }
            return null; //if item is not found, return null
        }

    }
}
    
  