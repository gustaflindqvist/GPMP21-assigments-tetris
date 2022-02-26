using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryItem
    {
        [SerializeField] private Image background;
        [SerializeField] private TextMeshProUGUI text;

        // public void Setup(PickupTypesEnum ofType)
        // {
        //     text.text = ofType.ToString();
        //     switch (ofType)
        //     {
        //         case PickupTypesEnum.GoldKey:
        //             background.color = Color.yellow;
        //             break;
        //         case PickupTypesEnum.RedKey:
        //             background.color = Color.red;
        //             break;
        //         default:
        //             background.color = Color.grey;
        //             break;
        //     }
        // }
    }
}
