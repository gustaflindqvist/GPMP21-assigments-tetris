using Gustaf.Scripts;
using UnityEngine;

namespace Inventory
{
    class Inventory : MonoBehaviour
    {
        [SerializeField] private GameObject  inventoryItemPrefab;
        [SerializeField] private RectTransform layout;

        public static Inventory Instance;

        private void Awake()
        {
            Instance = this;
        }

        // public void AddItem(PickupTypesEnum ofType)
        // {
        //     Instantiate(inventoryItemPrefab, layout).GetComponent<InventoryItem>().Setup(ofType);
        // }
        //
        // public void RemoveItem(PickupTypesEnum ofType)
        // {
        //
        // }
    }
}
