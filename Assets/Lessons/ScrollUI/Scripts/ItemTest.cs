using UnityEngine;

public class ItemTest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ItemDataProvider.Instance.DecreaseItemCount(ItemType.Pencil, 1);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            ItemDataProvider.Instance.DecreaseItemCount(ItemType.Camera, 1);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            ItemDataProvider.Instance.DecreaseItemCount(ItemType.Telephone, 1);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ItemDataProvider.Instance.DecreaseItemCount(ItemType.GamePad, 1);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            ItemDataProvider.Instance.IncreaseItemCount(ItemType.Pencil, 1);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            ItemDataProvider.Instance.IncreaseItemCount(ItemType.Camera, 1);
        }
    }
}
